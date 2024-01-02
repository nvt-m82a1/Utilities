using System.Collections.Concurrent;

namespace Utilities.Container.Datatype
{
    public class TypesPool
    {
        /// <summary>
        /// Danh sách kiểu dữ liệu đã lưu
        /// </summary>
        private static readonly ConcurrentDictionary<int, IEnumerable<CType>> saved = new();

        /// <summary>
        /// Quét và lưu danh sách thuộc tính của đối tượng
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <param name="data">Đối tượng thực tế của kiểu dữ liệu</param>
        /// <returns>Danh sách thông tin dữ liệu chuyển đổi</returns>
        public static IEnumerable<CType> Scan<T>(T data)
        {
            if (data == null) return Array.Empty<CType>();

            var dataType = data.GetType();
            var typecode = dataType.GetHashCode();
            if (!saved.ContainsKey(typecode))
            {
                var fields = dataType.GetFields().Select(f =>
                {
                    var convertType = new CType();
                    TypesRead.FillCType(convertType, f.FieldType);

                    convertType.SetValue = (obj, value) => f.SetValue(obj, value);
                    convertType.GetValue = (obj) => f.GetValue(obj);
                    return convertType;
                });

                var props = dataType.GetProperties().Select(p =>
                {
                    var convertType = new CType();
                    TypesRead.FillCType(convertType, p.PropertyType);

                    convertType.SetValue = (obj, value) => p.SetValue(obj, value);
                    convertType.GetValue = (obj) => p.GetValue(obj);
                    return convertType;
                });

                saved[typecode] = fields.Concat(props);
            }

            return saved[typecode];
        }
    }
}
