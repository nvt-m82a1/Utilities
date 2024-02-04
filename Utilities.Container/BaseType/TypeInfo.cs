namespace Utilities.Container.BaseType
{
    /// <summary>
    /// Lưu những thông tin về type
    /// </summary>
    public class TypeInfo
    {
        public Type Type { get; protected set; }

        public string FullName { get; set; }
        public bool IsNullable { get; set; }
        public bool IsArray { get; set; }

        public TypeInfo(Type type)
        {
            Type = type;
            FullName = type.FullName ?? type.Name;
        }
    }
}
