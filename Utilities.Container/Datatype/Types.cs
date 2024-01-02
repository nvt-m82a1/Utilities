namespace Utilities.Container.Datatype
{
    public class Types
    {
        /// <summary>
        /// Tên đầy đủ một số kiểu dữ liệu
        /// </summary>
        public struct FullName
        {
            public const string Boolean = "System.Boolean";
            public const string Byte = "System.Byte";
            public const string SByte = "System.SByte";
            public const string Char = "System.Char";
            public const string Int16 = "System.Int16";
            public const string UInt16 = "System.UInt16";
            public const string Int32 = "System.Int32";
            public const string UInt32 = "System.UInt32";
            public const string Single = "System.Single";
            public const string Double = "System.Double";
            public const string Int64 = "System.Int64";
            public const string Decimal = "System.Decimal";

            public const string String = "System.String";
            public const string DateTime = "System.DateTime";
            public const string Guid = "System.Guid";

            public const string Object = "System.Object";
            public const string Array = "System.Array";
        }

        /// <summary>
        /// Tên một số kiểu dữ liệu
        /// </summary>
        public struct Name
        {
            public struct Enumerable
            {
                public const string Dictionary2 = "Dictionary`2";
                public const string CDictionary2 = "ConcurrentDictionary`2";
                public const string List1 = "List`1";
                public const string LinkedList1 = "LinkedList`1";
                public const string Queue1 = "Queue`1";
                public const string CQueue1 = "ConcurrentQueue`1";
                public const string Stack1 = "Stack`1";
                public const string CStack1 = "ConcurrentStack`1";

                public const string IDictionary2 = "IDictionary`2";
                public const string IEnumerable1 = "IEnumerable`1";
                public const string Concat2Iterator1 = "Concat2Iterator`1";
                public const string ConcatNIterator1 = "ConcatNIterator`1";
            }

            public const string Nullable1 = "Nullable`1";
        }
    }

    /// <summary>
    /// Dữ liệu định dạng chuyển đổi
    /// </summary>
    public class CType
    {
        public string? FullName;
        public bool IsEnumerable;
        public bool IsNullable;
        public bool IsPair;
        public bool IsList;
        public bool IsBoolean;
        public bool IsContainer;
        public bool IsGeneric;
        public Type? CustomType;
        public Func<object?, object?>? GetValue;
        public Action<object?, object?>? SetValue;

        public CType[]? Others;
    }
}
