namespace Utilities.Container.Option
{
    /// <summary>
    /// Kiểu dữ liệu không xác định.
    /// </summary>
    public class TypeNotfoundException : Exception
    {
        public TypeNotfoundException(string message) : base(message) { }
    }

    /// <summary>
    /// Kiểu dữ liệu không thể chuyển đổi
    /// </summary>
    public class TypeConvertException : Exception
    {
        public TypeConvertException(string message) : base(message) { }
    }

    /// <summary>
    /// Không thể parse dữ liệu
    /// </summary>
    public class TypeParseException : Exception
    {
        public TypeParseException(string message) : base(message) { }
    }
}
