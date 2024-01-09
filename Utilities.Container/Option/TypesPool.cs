using System.Collections.Concurrent;
using Utilities.Container.BaseType;
using Utilities.Container.Datatype;
using static Utilities.Container.Option.TypesName;

namespace Utilities.Container.Option
{
    public class TypesPool
    {
        /// <summary>
        /// Danh sách kiểu dữ liệu đã lưu
        /// </summary>
        private static readonly ConcurrentDictionary<int, TypeBase[]> scanSaved = new();

        /// <summary>
        /// Quét và lưu danh sách thuộc tính của đối tượng
        /// </summary>
        /// <param name="dataType">Kiểu dữ liệu</param>
        /// <returns>Danh sách thông tin dữ liệu chuyển đổi</returns>
        public static TypeBase[] Scan(Type? dataType)
        {
            if (dataType == null) return Array.Empty<TypeBase>();
            var typecode = HashCode.Combine(dataType.GetHashCode(), dataType.FullName);
            foreach (var subtype in dataType.GenericTypeArguments)
                typecode ^= HashCode.Combine(subtype.GetHashCode(), subtype.FullName);

            if (!scanSaved.ContainsKey(typecode))
            {
                var fields = dataType.GetFields().Select(f =>
                {
                    var type = Create(f.FieldType);
                    type.Binding = new TypeBinding
                    {
                        GetValue = (obj) => f.GetValue(obj),
                        SetValue = (obj, value) => f.SetValue(obj, value),
                    };
                    return type;
                });

                var props = dataType.GetProperties().Select(p =>
                {
                    var type = Create(p.PropertyType);
                    type.Binding = new TypeBinding
                    {
                        GetValue = (obj) => p.GetValue(obj),
                        SetValue = (obj, value) => p.SetValue(obj, value),
                    };
                    return type;
                });

                scanSaved[typecode] = fields.Concat(props).ToArray();
            }

            return scanSaved[typecode];
        }

        /// <summary>
        /// Quét và lưu danh sách thuộc tính của đối tượng
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <returns>Danh sách thông tin dữ liệu chuyển đổi</returns>
        public static TypeBase[] Scan<T>()
        {
            return Scan(typeof(T));
        }

        /// <summary>
        /// Tạo một BaseType từ định dạng Type
        /// </summary>
        public static TypeBase Create(Type target)
        {
            switch (target.Name)
            {
                case Name.Enumerable.Dictionary2:
                case Name.Enumerable.CDictionary2:
                case Name.Enumerable.IDictionary2:
                    return new TypePair(target);

                case Name.Enumerable.Stack1:
                case Name.Enumerable.CStack1:
                    return new TypeList(target, "Push", target.GenericTypeArguments[0]);

                case Name.Enumerable.Queue1:
                case Name.Enumerable.CQueue1:
                    return new TypeList(target, "Enqueue", target.GenericTypeArguments[0]);

                case Name.Enumerable.List1:
                    return new TypeList(target, "Add", target.GenericTypeArguments[0]);

                case Name.Enumerable.LinkedList1:
                    return new TypeList(target, "AddLast", target.GenericTypeArguments[0]);

                case Name.Enumerable.IList1:
                case Name.Enumerable.IEnumerable1:
                case Name.Enumerable.Concat2Iterator1:
                case Name.Enumerable.ConcatNIterator1:
                    return new TypeList(typeof(List<>).MakeGenericType(target.GenericTypeArguments[0]), "Add", target.GenericTypeArguments[0]);

                case Name.Nullable1:
                    {
                        var type = Create(target.GenericTypeArguments[0]);
                        type.Info.IsNullable = true;
                        return type;
                    }

                default:
                    if (target.BaseType?.FullName == FullName.Array)
                    {
                        string targetName = target.FullName ?? target.Name;
                        targetName = targetName.Replace("[]", "");

                        var isNullable = targetName.Last() == '?';
                        var isBooleanArray = targetName.Replace("?", "") == FullName.Boolean;
                        targetName = targetName.Replace("?", "");

                        if (isBooleanArray)
                        {
                            var type = new TypeList(typeof(List<>).MakeGenericType(typeof(bool)), "Add", typeof(Boolean));
                            type.Info.IsArray = true;
                            type.Info.FullName = targetName;
                            type.Info.IsNullable = isNullable;
                            return type;
                        }
                        else
                        {
                            var type = new TypeList(typeof(List<>).MakeGenericType(target.GetElementType()!), "Add", target.GetElementType()!);
                            type.Info.IsArray = true;
                            type.Info.FullName = targetName;
                            type.Info.IsNullable = isNullable;
                            return type;
                        }
                    }

                    var isCustom = Attribute.IsDefined(target, typeof(ClassContainerAttribute));
                    if (isCustom) return new TypeCustom(target);

                    var isBoolean = target.FullName == FullName.Boolean;
                    if (isBoolean) return new TypeBoolean(target);

                    return new TypeBuildin(target);
            }

            throw new TypeNotfoundException(target.FullName ?? target.Name);
        }

        /// <summary>
        /// Lấy thông tin type info của kiểu type
        /// </summary>
        /// <param name="type">Kiểu dữ liệu</param>
        public static TypeInfo GetInfo(Type type)
        {
            var typeInfo = new TypeInfo(type);
            typeInfo.IsContainer = Attribute.IsDefined(type, typeof(ClassContainerAttribute));

            return typeInfo;
        }
    }
}
