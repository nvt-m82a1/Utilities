namespace Utilities.Container.Option
{
    /// <summary>
    /// Kiểu dữ liệu không xác định.
    /// Thêm thuộc tính ClassContainer nếu kiểu dữ liệu là Class và chứa những kiểu dữ liệu có thể convert.
    /// </summary>
    public class TypeNotfoundException : Exception
    {
        public TypeNotfoundException(string message) : base(message) { }
    }

    public class TypeParseException : Exception
    {
        public TypeParseException(string message) : base(message) { }
    }
}
