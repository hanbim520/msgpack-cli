﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MsgPack.Serialization.GeneratedSerializers {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MsgPack.Serialization.CodeDomSerializers.CodeDomSerializerBuilder", "0.7.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class MsgPack_Serialization_VersioningTestTargetSerializer : MsgPack.Serialization.MessagePackSerializer<MsgPack.Serialization.VersioningTestTarget> {
        
        private MsgPack.Serialization.MessagePackSerializer<int> _serializer0;
        
        private System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget> this_PackValueOfField1Delegate;
        
        private System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget> this_PackValueOfField2Delegate;
        
        private MsgPack.Serialization.MessagePackSerializer<string> _serializer1;
        
        private System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget> this_PackValueOfField3Delegate;
        
        private System.Collections.Generic.IList<System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>> _packOperationList;
        
        private System.Collections.Generic.IDictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>> _packOperationTable;
        
        private System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task> this_PackValueOfField1AsyncDelegate;
        
        private System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task> this_PackValueOfField2AsyncDelegate;
        
        private System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task> this_PackValueOfField3AsyncDelegate;
        
        private System.Collections.Generic.IList<System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>> _packOperationListAsync;
        
        private System.Collections.Generic.IDictionary<string, System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>> _packOperationTableAsync;
        
        private System.Action<MsgPack.Serialization.VersioningTestTarget, int> this_SetUnpackedValueOfField1Delegate;
        
        private System.Func<MsgPack.Unpacker, System.Type, string, int> MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueDelegate;
        
        private System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int> this_UnpackValueOfField1Delegate;
        
        private System.Action<MsgPack.Serialization.VersioningTestTarget, int> this_SetUnpackedValueOfField2Delegate;
        
        private System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int> this_UnpackValueOfField2Delegate;
        
        private System.Action<MsgPack.Serialization.VersioningTestTarget, string> this_SetUnpackedValueOfField3Delegate;
        
        private System.Func<MsgPack.Unpacker, System.Type, string, string> MsgPack_Serialization_UnpackHelpers_UnpackStringValueDelegate;
        
        private System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int> this_UnpackValueOfField3Delegate;
        
        private System.Collections.Generic.IList<string> _memberNames;
        
        private System.Collections.Generic.IList<System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>> _unpackOperationList;
        
        private System.Collections.Generic.IDictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>> _unpackOperationTable;
        
        private System.Func<MsgPack.Unpacker, System.Type, string, System.Threading.CancellationToken, System.Threading.Tasks.Task<int>> MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueAsyncDelegate;
        
        private System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task> this_UnpackValueOfField1AsyncDelegate;
        
        private System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task> this_UnpackValueOfField2AsyncDelegate;
        
        private System.Func<MsgPack.Unpacker, System.Type, string, System.Threading.CancellationToken, System.Threading.Tasks.Task<string>> MsgPack_Serialization_UnpackHelpers_UnpackStringValueAsyncDelegate;
        
        private System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task> this_UnpackValueOfField3AsyncDelegate;
        
        private System.Collections.Generic.IList<System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>> _unpackOperationListAsync;
        
        private System.Collections.Generic.IDictionary<string, System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>> _unpackOperationTableAsync;
        
        public MsgPack_Serialization_VersioningTestTargetSerializer(MsgPack.Serialization.SerializationContext context) : 
                base(context) {
            MsgPack.Serialization.PolymorphismSchema schema0 = default(MsgPack.Serialization.PolymorphismSchema);
            schema0 = null;
            this._serializer0 = context.GetSerializer<int>(schema0);
            MsgPack.Serialization.PolymorphismSchema schema1 = default(MsgPack.Serialization.PolymorphismSchema);
            schema1 = null;
            this._serializer1 = context.GetSerializer<string>(schema1);
            System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>[] packOperationList = default(System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>[]);
            packOperationList = new System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>[3];
            packOperationList[0] = new System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>(this.PackValueOfField1);
            packOperationList[1] = new System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>(this.PackValueOfField2);
            packOperationList[2] = new System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>(this.PackValueOfField3);
            this._packOperationList = packOperationList;
            System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>[] packOperationListAsync = default(System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>[]);
            packOperationListAsync = new System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>[3];
            packOperationListAsync[0] = new System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfField1Async);
            packOperationListAsync[1] = new System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfField2Async);
            packOperationListAsync[2] = new System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfField3Async);
            this._packOperationListAsync = packOperationListAsync;
            System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>> packOperationTable = default(System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>>);
            packOperationTable = new System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>>(3);
            packOperationTable["Field1"] = new System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>(this.PackValueOfField1);
            packOperationTable["Field2"] = new System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>(this.PackValueOfField2);
            packOperationTable["Field3"] = new System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>(this.PackValueOfField3);
            this._packOperationTable = packOperationTable;
            System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>> packOperationTableAsync = default(System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>>);
            packOperationTableAsync = new System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>>(3);
            packOperationTableAsync["Field1"] = new System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfField1Async);
            packOperationTableAsync["Field2"] = new System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfField2Async);
            packOperationTableAsync["Field3"] = new System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfField3Async);
            this._packOperationTableAsync = packOperationTableAsync;
            System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>[] unpackOperationList = default(System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>[]);
            unpackOperationList = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>[3];
            unpackOperationList[0] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>(this.UnpackValueOfField1);
            unpackOperationList[1] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>(this.UnpackValueOfField2);
            unpackOperationList[2] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>(this.UnpackValueOfField3);
            this._unpackOperationList = unpackOperationList;
            System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>[] unpackOperationListAsync = default(System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>[]);
            unpackOperationListAsync = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>[3];
            unpackOperationListAsync[0] = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfField1Async);
            unpackOperationListAsync[1] = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfField2Async);
            unpackOperationListAsync[2] = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfField3Async);
            this._unpackOperationListAsync = unpackOperationListAsync;
            System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>> unpackOperationTable = default(System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>>);
            unpackOperationTable = new System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>>(3);
            unpackOperationTable["Field1"] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>(this.UnpackValueOfField1);
            unpackOperationTable["Field2"] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>(this.UnpackValueOfField2);
            unpackOperationTable["Field3"] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>(this.UnpackValueOfField3);
            this._unpackOperationTable = unpackOperationTable;
            System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>> unpackOperationTableAsync = default(System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>>);
            unpackOperationTableAsync = new System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>>(3);
            unpackOperationTableAsync["Field1"] = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfField1Async);
            unpackOperationTableAsync["Field2"] = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfField2Async);
            unpackOperationTableAsync["Field3"] = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfField3Async);
            this._unpackOperationTableAsync = unpackOperationTableAsync;
            this._memberNames = new string[] {
                    "Field1",
                    "Field2",
                    "Field3"};
            this.this_PackValueOfField1Delegate = new System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>(this.PackValueOfField1);
            this.this_PackValueOfField2Delegate = new System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>(this.PackValueOfField2);
            this.this_PackValueOfField3Delegate = new System.Action<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget>(this.PackValueOfField3);
            this.this_PackValueOfField1AsyncDelegate = new System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfField1Async);
            this.this_PackValueOfField2AsyncDelegate = new System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfField2Async);
            this.this_PackValueOfField3AsyncDelegate = new System.Func<MsgPack.Packer, MsgPack.Serialization.VersioningTestTarget, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfField3Async);
            this.this_SetUnpackedValueOfField1Delegate = new System.Action<MsgPack.Serialization.VersioningTestTarget, int>(this.SetUnpackedValueOfField1);
            this.MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueDelegate = new System.Func<MsgPack.Unpacker, System.Type, string, int>(MsgPack.Serialization.UnpackHelpers.UnpackInt32Value);
            this.this_UnpackValueOfField1Delegate = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>(this.UnpackValueOfField1);
            this.this_SetUnpackedValueOfField2Delegate = new System.Action<MsgPack.Serialization.VersioningTestTarget, int>(this.SetUnpackedValueOfField2);
            this.this_UnpackValueOfField2Delegate = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>(this.UnpackValueOfField2);
            this.this_SetUnpackedValueOfField3Delegate = new System.Action<MsgPack.Serialization.VersioningTestTarget, string>(this.SetUnpackedValueOfField3);
            this.MsgPack_Serialization_UnpackHelpers_UnpackStringValueDelegate = new System.Func<MsgPack.Unpacker, System.Type, string, string>(MsgPack.Serialization.UnpackHelpers.UnpackStringValue);
            this.this_UnpackValueOfField3Delegate = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int>(this.UnpackValueOfField3);
            this.MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueAsyncDelegate = new System.Func<MsgPack.Unpacker, System.Type, string, System.Threading.CancellationToken, System.Threading.Tasks.Task<int>>(MsgPack.Serialization.UnpackHelpers.UnpackInt32ValueAsync);
            this.this_UnpackValueOfField1AsyncDelegate = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfField1Async);
            this.this_UnpackValueOfField2AsyncDelegate = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfField2Async);
            this.MsgPack_Serialization_UnpackHelpers_UnpackStringValueAsyncDelegate = new System.Func<MsgPack.Unpacker, System.Type, string, System.Threading.CancellationToken, System.Threading.Tasks.Task<string>>(MsgPack.Serialization.UnpackHelpers.UnpackStringValueAsync);
            this.this_UnpackValueOfField3AsyncDelegate = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.VersioningTestTarget, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfField3Async);
        }
        
        private void PackValueOfField1(MsgPack.Packer packer, MsgPack.Serialization.VersioningTestTarget objectTree) {
            this._serializer0.PackTo(packer, objectTree.Field1);
        }
        
        private void PackValueOfField2(MsgPack.Packer packer, MsgPack.Serialization.VersioningTestTarget objectTree) {
            this._serializer0.PackTo(packer, objectTree.Field2);
        }
        
        private void PackValueOfField3(MsgPack.Packer packer, MsgPack.Serialization.VersioningTestTarget objectTree) {
            this._serializer1.PackTo(packer, objectTree.Field3);
        }
        
        protected internal override void PackToCore(MsgPack.Packer packer, MsgPack.Serialization.VersioningTestTarget objectTree) {
            if ((this.OwnerContext.SerializationMethod == MsgPack.Serialization.SerializationMethod.Array)) {
                MsgPack.Serialization.PackHelpers.PackToArray(packer, objectTree, this._packOperationList);
            }
            else {
                MsgPack.Serialization.PackHelpers.PackToMap(packer, objectTree, this._packOperationTable);
            }
        }
        
        private System.Threading.Tasks.Task PackValueOfField1Async(MsgPack.Packer packer, MsgPack.Serialization.VersioningTestTarget objectTree, System.Threading.CancellationToken cancellationToken) {
            return this._serializer0.PackToAsync(packer, objectTree.Field1, cancellationToken);
        }
        
        private System.Threading.Tasks.Task PackValueOfField2Async(MsgPack.Packer packer, MsgPack.Serialization.VersioningTestTarget objectTree, System.Threading.CancellationToken cancellationToken) {
            return this._serializer0.PackToAsync(packer, objectTree.Field2, cancellationToken);
        }
        
        private System.Threading.Tasks.Task PackValueOfField3Async(MsgPack.Packer packer, MsgPack.Serialization.VersioningTestTarget objectTree, System.Threading.CancellationToken cancellationToken) {
            return this._serializer1.PackToAsync(packer, objectTree.Field3, cancellationToken);
        }
        
        protected internal override System.Threading.Tasks.Task PackToAsyncCore(MsgPack.Packer packer, MsgPack.Serialization.VersioningTestTarget objectTree, System.Threading.CancellationToken cancellationToken) {
            if ((this.OwnerContext.SerializationMethod == MsgPack.Serialization.SerializationMethod.Array)) {
                return MsgPack.Serialization.PackHelpers.PackToArrayAsync(packer, objectTree, this._packOperationListAsync, cancellationToken);
            }
            else {
                return MsgPack.Serialization.PackHelpers.PackToMapAsync(packer, objectTree, this._packOperationTableAsync, cancellationToken);
            }
        }
        
        private void SetUnpackedValueOfField1(MsgPack.Serialization.VersioningTestTarget unpackingContext, int unpackedValue) {
            unpackingContext.Field1 = unpackedValue;
        }
        
        private void UnpackValueOfField1(MsgPack.Unpacker unpacker, MsgPack.Serialization.VersioningTestTarget unpackingContext, int indexOfItem, int itemsCount) {
            MsgPack.Serialization.UnpackHelpers.UnpackValueTypeValue(unpacker, unpackingContext, this._serializer0, itemsCount, indexOfItem, typeof(int), "Field1", MsgPack.Serialization.NilImplication.MemberDefault, this.MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueDelegate, this.this_SetUnpackedValueOfField1Delegate);
        }
        
        private void SetUnpackedValueOfField2(MsgPack.Serialization.VersioningTestTarget unpackingContext, int unpackedValue) {
            unpackingContext.Field2 = unpackedValue;
        }
        
        private void UnpackValueOfField2(MsgPack.Unpacker unpacker, MsgPack.Serialization.VersioningTestTarget unpackingContext, int indexOfItem, int itemsCount) {
            MsgPack.Serialization.UnpackHelpers.UnpackValueTypeValue(unpacker, unpackingContext, this._serializer0, itemsCount, indexOfItem, typeof(int), "Field2", MsgPack.Serialization.NilImplication.MemberDefault, this.MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueDelegate, this.this_SetUnpackedValueOfField2Delegate);
        }
        
        private void SetUnpackedValueOfField3(MsgPack.Serialization.VersioningTestTarget unpackingContext, string unpackedValue) {
            unpackingContext.Field3 = unpackedValue;
        }
        
        private void UnpackValueOfField3(MsgPack.Unpacker unpacker, MsgPack.Serialization.VersioningTestTarget unpackingContext, int indexOfItem, int itemsCount) {
            MsgPack.Serialization.UnpackHelpers.UnpackReferenceTypeValue(unpacker, unpackingContext, this._serializer1, itemsCount, indexOfItem, typeof(string), "Field3", MsgPack.Serialization.NilImplication.MemberDefault, this.MsgPack_Serialization_UnpackHelpers_UnpackStringValueDelegate, this.this_SetUnpackedValueOfField3Delegate);
        }
        
        protected internal override MsgPack.Serialization.VersioningTestTarget UnpackFromCore(MsgPack.Unpacker unpacker) {
            MsgPack.Serialization.VersioningTestTarget result = default(MsgPack.Serialization.VersioningTestTarget);
            result = new MsgPack.Serialization.VersioningTestTarget();
            if (unpacker.IsArrayHeader) {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromArray(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.VersioningTestTarget>(), this._memberNames, this._unpackOperationList);
            }
            else {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromMap(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.VersioningTestTarget>(), this._unpackOperationTable);
            }
        }
        
        private System.Threading.Tasks.Task UnpackValueOfField1Async(MsgPack.Unpacker unpacker, MsgPack.Serialization.VersioningTestTarget unpackingContext, int indexOfItem, int itemsCount, System.Threading.CancellationToken cancellationToken) {
            return MsgPack.Serialization.UnpackHelpers.UnpackValueTypeValueAsync(unpacker, unpackingContext, this._serializer0, itemsCount, indexOfItem, typeof(int), "Field1", MsgPack.Serialization.NilImplication.MemberDefault, this.MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueAsyncDelegate, this.this_SetUnpackedValueOfField1Delegate, cancellationToken);
        }
        
        private System.Threading.Tasks.Task UnpackValueOfField2Async(MsgPack.Unpacker unpacker, MsgPack.Serialization.VersioningTestTarget unpackingContext, int indexOfItem, int itemsCount, System.Threading.CancellationToken cancellationToken) {
            return MsgPack.Serialization.UnpackHelpers.UnpackValueTypeValueAsync(unpacker, unpackingContext, this._serializer0, itemsCount, indexOfItem, typeof(int), "Field2", MsgPack.Serialization.NilImplication.MemberDefault, this.MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueAsyncDelegate, this.this_SetUnpackedValueOfField2Delegate, cancellationToken);
        }
        
        private System.Threading.Tasks.Task UnpackValueOfField3Async(MsgPack.Unpacker unpacker, MsgPack.Serialization.VersioningTestTarget unpackingContext, int indexOfItem, int itemsCount, System.Threading.CancellationToken cancellationToken) {
            return MsgPack.Serialization.UnpackHelpers.UnpackReferenceTypeValueAsync(unpacker, unpackingContext, this._serializer1, itemsCount, indexOfItem, typeof(string), "Field3", MsgPack.Serialization.NilImplication.MemberDefault, this.MsgPack_Serialization_UnpackHelpers_UnpackStringValueAsyncDelegate, this.this_SetUnpackedValueOfField3Delegate, cancellationToken);
        }
        
        protected internal override System.Threading.Tasks.Task<MsgPack.Serialization.VersioningTestTarget> UnpackFromAsyncCore(MsgPack.Unpacker unpacker, System.Threading.CancellationToken cancellationToken) {
            MsgPack.Serialization.VersioningTestTarget result = default(MsgPack.Serialization.VersioningTestTarget);
            result = new MsgPack.Serialization.VersioningTestTarget();
            if (unpacker.IsArrayHeader) {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromArrayAsync(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.VersioningTestTarget>(), this._memberNames, this._unpackOperationListAsync, cancellationToken);
            }
            else {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromMapAsync(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.VersioningTestTarget>(), this._unpackOperationTableAsync, cancellationToken);
            }
        }
    }
}