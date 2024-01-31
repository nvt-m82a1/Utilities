namespace Utilities.Container.BaseType
{
    /// <summary>
    /// Thao tác với field, prop của class
    /// </summary>
    public class TypeBinding
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        public Func<object?, object?>? GetValue;

        /// <summary>
        /// Đặt dữ liệu
        /// </summary>
        public Action<object?, object?>? SetValue;
    }
}
