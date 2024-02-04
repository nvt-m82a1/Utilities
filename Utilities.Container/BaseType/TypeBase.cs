using Utilities.Container.Base;
using Utilities.Container.Converter;
using Utilities.Container.Option;

namespace Utilities.Container.BaseType
{
    /// <summary>
    /// Lưu thông tin kiểu dữ liệu
    /// </summary>
    public abstract class TypeBase
    {
        /// <summary>
        /// Khởi tạo kiểu dữ liệu
        /// </summary>
        /// <param name="type">Kiểu dữ liệu hệ thống</param>
        /// <param name="others">Kiểu dữ liệu generics</param>
        public TypeBase(Type type, params Type[] others)
        {
            Info = TypesPool.GetInfo(type);

            if (others.Length > 0)
            {
                Others = new TypeBase[others.Length];
                for (var i = 0; i < others.Length; i++)
                    Others[i] = TypesPool.Create(others[i]);
            }
        }

        public TypeInfo Info { get; set; }

        /// <summary>
        /// Thông tin kiểu dữ liệu generics
        /// </summary>
        public TypeBase[]? Others { get; protected set; }
        public TypeBinding? Binding { get; set; }

        /// <summary>
        /// Đọc this type trong container và gán vào wrap
        /// </summary>
        /// <param name="wrap">Đối tượng chứa dữ liệu</param>
        /// <param name="container">Container dữ liệu</param>
        /// <param name="converter">Chuyển đổi dữ liệu</param>
        /// <param name="refsPool">Danh sách reference</param>
        public abstract void BindingItem(object wrap, DataContainer container, TypeConvert converter, ReferencesPool refsPool);

        /// <summary>
        /// Lấy giá trị từ wrap và ghi vào container
        /// </summary>
        /// <param name="wrap">Đối tượng chứa dữ liệu</param>
        /// <param name="container">Container dữ liệu</param>
        /// <param name="converter">Chuyển đổi dữ liệu</param>
        /// <param name="refsPool">Danh sách reference</param>
        public abstract void BindingContainer(object wrap, DataContainer container, TypeConvert converter, ReferencesPool refsPool);

        /// <summary>
        /// Đọc this type trong container
        /// </summary>
        /// <param name="container">Container dữ liệu</param>
        /// <param name="converter">Chuyển đổi dữ liệu</param>
        /// <param name="OnItemResult">Enumerable(item, index) hoặc (key, value)</param>
        /// <param name="refsPool">Danh sách reference</param>
        public abstract void Read(DataContainer container, TypeConvert converter, ReferencesPool refsPool, Action<object, object?> OnItemResult);

        /// <summary>
        /// Ghi data vào container
        /// </summary>
        /// <param name="data">Dữ liệu</param>
        /// <param name="container">Container dữ liệu</param>
        /// <param name="converter">Chuyển đổi dữ liệu</param>
        /// <param name="refsPool">Danh sách reference</param>
        public abstract void Write(object? data, DataContainer container, TypeConvert converter, ReferencesPool refsPool);
    }
}
