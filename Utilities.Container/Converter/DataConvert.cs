using Utilities.Container.Base;
using Utilities.Container.Datatype;
using Utilities.Container.Option;

namespace Utilities.Container.Converter
{
    /// <summary>
    /// Chuyển đổi dữ liệu
    /// </summary>
    public class DataConvert
    {
        public static DataConvert Instance = new DataConvert();
        private DataConvert() { }

        /// <summary>
        /// Lấy dữ liệu bytes từ data
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <param name="data">Đối tượng</param>
        /// <param name="forceClass">Lấy danh sách members trực tiếp nếu là class</param>
        public byte[]? GetBytes<T>(T? data, bool forceClass = false)
        {
            if (data == null) return null;
            var dataContainer = new DataContainer();

            var dataType = TypesPool.Create(data.GetType(), forceClass);
            dataType.Write(data, dataContainer, TypeConvert.Instance);

            return dataContainer.Export().ToArray();
        }

        /// <summary>
        /// Lấy giá trị trong data
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <param name="data">Dữ liệu</param>
        /// <param name="forceClass">Lấy danh sách members trực tiếp nếu là class</param>
        public T? GetItem<T>(byte[]? data, bool forceClass = false)
        {
            if (data == null) return default;

            var wrap = new TypeWrap<T>();
            var wrapType = TypesPool.Scan(typeof(TypeWrap<T>), forceClass);
            var dataType = wrapType[0];

            var container = new DataContainer();
            container.Import(data);

            dataType.BindingItem(wrap, container, TypeConvert.Instance);

            return wrap.Value;
        }
    }
}
