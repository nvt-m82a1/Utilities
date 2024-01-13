using Utilities.Container.Base;
using Utilities.Container.Datatype;
using Utilities.Container.Option;

namespace Utilities.Container.Converter
{
    public class DataConvert
    {
        public static DataConvert Instance = new DataConvert();
        private DataConvert() { }

        /// <summary>
        /// Lấy một định dạng bytes từ data
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <param name="data">Đối tượng</param>
        /// <returns></returns>
        public byte[]? GetBytes<T>(T? data)
        {
            if (data == null) return null;
            var dataContainer = new DataContainer();

            var dataType = TypesPool.Create(data.GetType());
            dataType.Write(data, dataContainer, TypeConvert.Instance);

            return dataContainer.Export().ToArray();
        }

        /// <summary>
        /// Lấy giá trị trong data
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <param name="data">Dữ liệu</param>
        /// <returns></returns>
        public T? GetItem<T>(byte[]? data)
        {
            if (data == null) return default;

            var wrap = new TypeWrap<T>();
            var wrapType = TypesPool.Scan(typeof(TypeWrap<T>));
            var dataType = wrapType[0];

            var container = new DataContainer();
            container.Import(data);

            dataType.BindingItem(wrap, container, TypeConvert.Instance);

            return wrap.Value;
        }
    }
}
