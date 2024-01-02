using Utilities.Container.Converter;
using Utilities.Container.Datatype;

namespace Utilities.Container.Buildin
{
    public class TypeReader
    {
        public TypeContainer Container { get; private set; }
        public TypeReader(byte[] data)
        {
            Container = new TypeContainer();
            Container.Import(data);
        }

        public TypeReader(TypeContainer container)
        {
            Container = container;
        }

        /// <summary>
        /// Đọc một thuộc tính
        /// </summary>
        protected void ReadType(CType ctype, object data)
        {
            if (Container.ReadBoolean() != true)
            {
                ctype.SetValue!(data, null);
                return;
            }

            if (ctype.IsPair)
            {
                ReadTypePair(data, ctype);
            }
            else if (ctype.IsEnumerable)
            {
                if (ctype.IsGeneric)
                    ReadTypeArray(data, ctype, ctype.Others![0]);
                else
                    ReadTypeArray(data, ctype, ctype);
            }
            else if (ctype.IsContainer)
            {
                // inner class
                var innerClass = Activator.CreateInstance(ctype.CustomType!);
                var innerContainer = Container.ReadContainer()!;
                var innerReader = new TypeReader(innerContainer);
                innerReader!.FillInstance(innerClass);
                ctype.SetValue!(data, innerClass);
            }
            else
            {
                // data
                var (len, bytes) = Container.ReadArray();
                TypeBinding.Instance.BindingItem(data, ctype, ctype, bytes!.ToArray(), 0);
            }
        }

        /// <summary>
        /// Đọc một mảng
        /// </summary>
        protected void ReadTypeArray(object data, CType root, CType ctype)
        {
            if (ctype.IsBoolean)
            {
                var len = Container.ReadInt32();
                var items = Container.ReadBooleanArray(len);
                TypeBinding.Instance.BindingList(data, root, items);
            }
            else
            {
                var len = Container.ReadInt32();
                var (byteLength, bytes) = Container.ReadArray();
                TypeBinding.Instance.BindingList(data, root, ctype, len, bytes!.ToArray(), 0);
            }
        }

        /// <summary>
        /// Đọc một đối tượng định dạng key - value
        /// </summary>
        protected void ReadTypePair(object data, CType ctype)
        {
            var count = Container.ReadInt32();
            var (keyLen, keyBytes) = Container.ReadArray();
            var (valueLen, valueBytes) = Container.ReadArray();

            TypeBinding.Instance.BindingPair(data, ctype, count, keyBytes!.ToArray(), valueBytes!.ToArray());
        }

        /// <summary>
        /// Đọc một class
        /// </summary>
        public void FillInstance<T>(T instance) where T : new()
        {
            if (Container.ReadBoolean() != true) return;

            if (instance == null) instance = new T();
            var members = TypesPool.Scan(instance);

            foreach (var member in members)
                ReadType(member, instance);
        }
    }
}
