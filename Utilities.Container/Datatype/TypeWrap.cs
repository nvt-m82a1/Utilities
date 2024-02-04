namespace Utilities.Container.Datatype
{
    /// <summary>
    /// Lớp wrap để xử lý kiểu dữ liệu buildin
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TypeWrap<T>
    {
        public TypeWrap() { }
        public TypeWrap(T? value)
        {
            Value = value;
        }

        public T? Value { get; set; }
    }
}
