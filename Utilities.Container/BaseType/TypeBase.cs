using Utilities.Container.Base;
using Utilities.Container.Converter;
using Utilities.Container.Option;

namespace Utilities.Container.BaseType
{
    public abstract class TypeBase
    {
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
        public TypeBase[]? Others { get; protected set; }
        public TypeBinding? Binding { get; set; }

        /// <summary>
        /// Đọc this type trong container và gán vào wrap
        /// </summary>
        public abstract void BindingItem(object wrap, DataContainer container, TypeConvert converter);

        /// <summary>
        /// Lấy giá trị từ wrap và ghi vào container
        /// </summary>
        public abstract void BindingContainer(object wrap, DataContainer container, TypeConvert converter);

        /// <summary>
        /// Đọc this type trong container
        /// </summary>
        /// <param name="OnItemResult">Enumerable(item, index) hoặc (key, value)</param>
        public abstract void Read(DataContainer container, TypeConvert converter, Action<object, object?> OnItemResult);

        /// <summary>
        /// Ghi data vào container
        /// </summary>
        public abstract void Write(object? data, DataContainer container, TypeConvert converter);
    }
}
