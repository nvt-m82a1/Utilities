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
        public byte[]? GetBytes<T>(T? data)
        {
            if (data == null) return null;

            ReferencesPool refsPool = new();
            var dataContainer = new DataContainer();
            var dataType = TypesPool.Create(data.GetType());

            dataType.Write(data, dataContainer, TypeConvert.Instance, refsPool);

            return dataContainer.Export().ToArray();
        }

        /// <summary>
        /// Lấy giá trị trong data
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <param name="data">Dữ liệu</param>
        public T? GetItem<T>(byte[]? data)
        {
            if (data == null) return default;

            var wrap = new TypeWrap<T>();
            var wrapType = TypesPool.Scan(typeof(TypeWrap<T>));
            var dataType = wrapType[0];

            ReferencesPool refsPool = new();

            var container = new DataContainer();
            container.Import(data);

            dataType.BindingItem(wrap, container, TypeConvert.Instance, refsPool);

            return wrap.Value;
        }
    }
}
