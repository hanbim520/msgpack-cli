#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2010-2012 FUJIWARA, Yusuke
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
#endregion -- License Terms --

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

// FIXME: Unify collection/dictionary handling between emit and expression tree to improve quality and reduce maintenance costs.

namespace MsgPack.Serialization.ExpressionSerializers
{
	/// <summary>
	///		Implements expression tree based serializer for general object.
	/// </summary>
	/// <typeparam name="T">The type of target object.</typeparam>
	internal abstract class ObjectExpressionMessagePackSerializer<T> : MessagePackSerializer<T>
#if !SILVERLIGHT
, IExpressionMessagePackSerializer
#endif
	{
		private readonly Func<T, object>[] _memberGetters;

		protected Func<T, object>[] MemberGetters
		{
			get { return this._memberGetters; }
		}

		private readonly MemberSetter[] _memberSetters;

		private readonly IMessagePackSerializer[] _memberSerializers;

		protected IMessagePackSerializer[] MemberSerializers
		{
			get { return this._memberSerializers; }
		}

		private readonly NilImplication[] _nilImplications;
		private readonly bool[] _isCollection;
		private readonly string[] _memberNames;

		protected string[] MemberNames
		{
			get { return this._memberNames; }
		}

		private readonly Dictionary<string, int> _indexMap;

		private readonly Func<T> _createInstance;

		protected ObjectExpressionMessagePackSerializer( SerializationContext context, SerializingMember[] members )
		{
			this._createInstance =
				Expression.Lambda<Func<T>>(
					typeof( T ).IsValueType
					? Expression.Default( typeof( T ) ) as Expression
					: Expression.New( typeof( T ).GetConstructor( ReflectionAbstractions.EmptyTypes ) )
				).Compile();
			this._memberSerializers = members.Select( m => m.Member == null ? NullSerializer.Instance : context.GetSerializer( m.Member.GetMemberValueType() ) ).ToArray();
			this._indexMap =
				members
				.Zip( Enumerable.Range( 0, members.Length ), ( m, i ) => new KeyValuePair<SerializingMember, int>( m, i ) )
				.Where( kv => kv.Key.Member != null )
				.ToDictionary( kv => kv.Key.Contract.Name, kv => kv.Value );

			var targetParameter = Expression.Parameter( typeof( T ), "target" );
			this._isCollection = members.Select( m => m.Member == null ? CollectionTraits.NotCollection : m.Member.GetMemberValueType().GetCollectionTraits() ).Select( t => t.CollectionType != CollectionKind.NotCollection ).ToArray();
			this._nilImplications = members.Select( m => m.Contract.NilImplication ).ToArray();
			this._memberNames = members.Select( m => m.Contract.Name ).ToArray();
			this._memberGetters =
				members.Select(
					m =>
						m.Member == null
						? Expression.Lambda<Func<T, object>>(
							Expression.Constant( null ),
							targetParameter
							).Compile()
						: Expression.Lambda<Func<T, object>>(
							Expression.Convert(
								Expression.PropertyOrField(
									targetParameter,
									m.Member.Name
								),
								typeof( object )
							),
							targetParameter
						).Compile()
				).ToArray();
			var valueParameter = Expression.Parameter( typeof( object ), "value" );
			var refTargetParameter = Expression.Parameter( typeof( T ).MakeByRefType(), "target" );
			this._memberSetters =
				members.Select(
					m =>
						m.Member == null
						? Expression.Lambda<MemberSetter>(
							Expression.Empty(),
							refTargetParameter,
							valueParameter
							).Compile()
						: m.Member.CanSetValue()
						? Expression.Lambda<MemberSetter>(
							Expression.Assign(
								Expression.PropertyOrField(
									refTargetParameter,
									m.Member.Name
								),
								m.Member.GetMemberValueType().GetIsValueType() && Nullable.GetUnderlyingType( m.Member.GetMemberValueType() ) == null
								? Expression.Condition(
									Expression.ReferenceEqual( valueParameter, Expression.Constant( null ) ),
									Expression.Throw(
										Expression.Call(
											null,
											SerializationExceptions.NewValueTypeCannotBeNull3Method,
											Expression.Constant( m.Member.Name ),
											Expression.Call( // Using RuntimeTypeHandle to avoid WinRT expression tree issue.
												null,
												Metadata._Type.GetTypeFromHandle,
												Expression.Constant( m.Member.GetMemberValueType().TypeHandle )
											),
											Expression.Call( // Using RuntimeTypeHandle to avoid WinRT expression tree issue.
												null,
												Metadata._Type.GetTypeFromHandle,
												Expression.Constant( m.Member.DeclaringType.TypeHandle )
											)
										),
										m.Member.GetMemberValueType()
									),
									Expression.Convert( valueParameter, m.Member.GetMemberValueType() )
								) as Expression
								: Expression.Convert( valueParameter, m.Member.GetMemberValueType() )
							),
							refTargetParameter,
							valueParameter
						).Compile()
						: UnpackHelpers.IsReadOnlyAppendableCollectionMember( m.Member )
						? default( MemberSetter )
						: ThrowGetOnlyMemberIsInvalid( m.Member )
				).ToArray();
		}

		private static MemberSetter ThrowGetOnlyMemberIsInvalid( MemberInfo member )
		{
			var asProperty = member as PropertyInfo;
			if ( asProperty != null )
			{
				throw new SerializationException( String.Format( CultureInfo.CurrentCulture, "Cannot set value to '{0}.{1}' property.", asProperty.DeclaringType, asProperty.Name ) );
			}
			else
			{
				Contract.Assert( member is FieldInfo, member.ToString() + ":" + member.MemberType );
				throw new SerializationException(
					String.Format(
						CultureInfo.CurrentCulture, "Cannot set value to '{0}.{1}' field.", member.DeclaringType, member.Name
					)
				);
			}
		}

		protected internal override T UnpackFromCore( Unpacker unpacker )
		{
			// FIXME: Redesign missing element handling
			if ( unpacker.IsArrayHeader && unpacker.ItemsCount != this._memberSerializers.Length )
			{
				throw SerializationExceptions.NewUnexpectedArrayLength( this._memberSerializers.Length, unchecked( ( int )unpacker.ItemsCount ) );
			}

			// Assume subtree unpacker
			var instance = this._createInstance();
			if ( unpacker.IsArrayHeader )
			{
				this.UnpackFromArray( unpacker, ref instance );
			}
			else
			{
				this.UnpackFromMap( unpacker, ref instance );
			}

			return instance;
		}

		private void UnpackFromArray( Unpacker unpacker, ref T instance )
		{
			for ( int i = 0; i < this.MemberSerializers.Length; i++ )
			{
				if ( !unpacker.Read() )
				{
					throw SerializationExceptions.NewUnexpectedEndOfStream();
				}

				if ( unpacker.Data.Value.IsNil )
				{
					switch ( this._nilImplications[ i ] )
					{
						case NilImplication.Null:
						{
							if ( this._memberSetters[ i ] == null )
							{
								throw SerializationExceptions.NewReadOnlyMemberItemsMustNotBeNull( this._memberNames[ i ] );
							}

							this._memberSetters[ i ]( ref instance, null );
							break;
						}
						case NilImplication.MemberDefault:
						{
							break;
						}
						case NilImplication.Prohibit:
						{
							throw SerializationExceptions.NewNullIsProhibited( this._memberNames[ i ] );
						}
					}

					continue;
				}

				if ( unpacker.IsArrayHeader || unpacker.IsMapHeader )
				{
					using ( var subtreeUnpacker = unpacker.ReadSubtree() )
					{
						this.UnpackMemberInArray( subtreeUnpacker, ref instance, i );
					}
				}
				else
				{
					this.UnpackMemberInArray( unpacker, ref instance, i );
				}
			}
		}

		private void UnpackMemberInArray( Unpacker unpacker, ref T instance, int i )
		{
			if ( this._memberSetters[ i ] == null )
			{
				// Use null as marker because index mapping cannot be constructed in the constructor.
				this._memberSerializers[ i ].UnpackTo( unpacker, this._memberGetters[ i ]( instance ) );
			}
			else
			{
				this._memberSetters[ i ]( ref instance, this._memberSerializers[ i ].UnpackFrom( unpacker ) );
			}
		}

		private void UnpackFromMap( Unpacker unpacker, ref T instance )
		{
			while ( unpacker.Read() )
			{
				var memberName = GetMemberName( unpacker );
				int index;
				if ( !this._indexMap.TryGetValue( memberName, out index ) )
				{
					// Drains unused value.
					if ( !unpacker.Read() )
					{
						throw SerializationExceptions.NewUnexpectedEndOfStream();
					}

					// TODO: unknown member handling.

					continue;
				}

				// Fetches value
				if ( !unpacker.Read() )
				{
					throw SerializationExceptions.NewUnexpectedEndOfStream();
				}

				if ( unpacker.Data.Value.IsNil )
				{
					switch ( this._nilImplications[ index ] )
					{
						case NilImplication.Null:
						{
							if ( this._memberSetters[ index ] == null )
							{
								throw SerializationExceptions.NewReadOnlyMemberItemsMustNotBeNull( this._memberNames[ index ] );
							}

							this._memberSetters[ index ]( ref instance, null );
							continue;
						}
						case NilImplication.MemberDefault:
						{
							continue;
						}
						case NilImplication.Prohibit:
						{
							throw SerializationExceptions.NewNullIsProhibited( this._memberNames[ index ] );
						}
					}
				}

				if ( unpacker.IsArrayHeader || unpacker.IsMapHeader )
				{
					using ( var subtreeUnpacker = unpacker.ReadSubtree() )
					{
						this.UnpackMemberInMap( subtreeUnpacker, ref instance, index );
					}
				}
				else
				{
					this.UnpackMemberInMap( unpacker, ref instance, index );
				}
			}
		}

		private static string GetMemberName( Unpacker unpacker )
		{
			try
			{
				return unpacker.Data.Value.AsString();
			}
			catch ( InvalidOperationException ex )
			{
				throw new InvalidMessagePackStreamException( "Cannot get a member name from stream.", ex );
			}
		}

		private void UnpackMemberInMap( Unpacker unpacker, ref T instance, int index )
		{
			if ( this._memberSetters[ index ] == null )
			{
				// Use null as marker because index mapping cannot be constructed in the constructor.
				this._memberSerializers[ index ].UnpackTo( unpacker, this._memberGetters[ index ]( instance ) );
			}
			else
			{
				this._memberSetters[ index ]( ref instance, this._memberSerializers[ index ].UnpackFrom( unpacker ) );
			}
		}

#if !SILVERLIGHT
		public override string ToString()
		{
			var buffer = new StringBuilder( Int16.MaxValue );
			using ( var writer = new StringWriter( buffer ) )
			{
				this.ToStringCore( writer, 0 );
			}

			return buffer.ToString();
		}

		void IExpressionMessagePackSerializer.ToString( TextWriter writer, int depth )
		{
			this.ToStringCore( writer ?? TextWriter.Null, depth < 0 ? 0 : depth );
		}

		private void ToStringCore( TextWriter writer, int depth )
		{
			var name = this.GetType().Name;
			int indexOfAgusam = name.IndexOf( '`' );
			int nameLength = indexOfAgusam < 0 ? name.Length : indexOfAgusam;
			for ( int i = 0; i < nameLength; i++ )
			{
				writer.Write( name[ i ] );
			}

			writer.Write( "For" );
			writer.WriteLine( typeof( T ) );

			for ( int i = 0; i < this._memberSerializers.Length; i++ )
			{
				ExpressionDumper.WriteIndent( writer, depth + 1 );
				writer.Write( this._memberNames[ i ] );
				writer.Write( " : " );
				var expressionSerializer = this._memberSerializers[ i ] as IExpressionMessagePackSerializer;
				if ( expressionSerializer != null )
				{
					expressionSerializer.ToString( writer, depth + 2 );
				}
				else
				{
					writer.Write( this._memberSerializers[ i ] );
				}

				writer.WriteLine();
			}
		}
#endif

		private sealed class NullSerializer : IMessagePackSerializer
		{
			public static readonly NullSerializer Instance = new NullSerializer();

			private NullSerializer()
			{
			}

			public void PackTo( Packer packer, object objectTree )
			{
				if ( packer == null )
				{
					throw new ArgumentNullException( "packer" );
				}

				Contract.EndContractBlock();

				packer.PackNull();
			}

			public object UnpackFrom( Unpacker unpacker )
			{
				if ( unpacker == null )
				{
					throw new ArgumentNullException( "unpacker" );
				}

				Contract.Ensures( Contract.Result<object>() == null );

				if ( !unpacker.Data.HasValue )
				{
					throw SerializationExceptions.NewEmptyOrUnstartedUnpacker();
				}

				// Always returns null.
				return null;
			}

			public void UnpackTo( Unpacker unpacker, object collection )
			{
				if ( unpacker == null )
				{
					throw new ArgumentNullException( "unpacker" );
				}

				if ( collection == null )
				{
					throw new ArgumentNullException( "collection" );
				}

				if ( !( collection is T ) )
				{
					throw new ArgumentException( String.Format( CultureInfo.CurrentCulture, "'{0}' is not compatible for '{1}'.", collection.GetType(), typeof( T ) ), "collection" );
				}

				if ( !unpacker.Data.HasValue )
				{
					throw SerializationExceptions.NewEmptyOrUnstartedUnpacker();
				}

				throw new NotSupportedException( String.Format( CultureInfo.CurrentCulture, "This operation is not supported by '{0}'.", this.GetType() ) );
			}
		}

		protected delegate void MemberSetter( ref T target, object memberValue );
	}
}