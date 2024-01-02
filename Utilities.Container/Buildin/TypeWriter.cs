using System.Collections;
using Utilities.Container.Converter;
using Utilities.Container.Datatype;

namespace Utilities.Container.Buildin
{
    public class TypeWriter
    {
        public TypeContainer Container { get; private set; }
        public TypeWriter()
        {
            Container = new TypeContainer();
        }

        /// <summary>
        /// Thêm một thuộc tính
        /// </summary>
        protected void AddType(CType ctype, object data)
        {
            Container.AddBoolean(data != null);
            if (data == null) return;

            if (ctype.IsPair)
            {
                AddTypePair(ctype, data);
            }
            else if (ctype.IsEnumerable)
            {
                if (ctype.IsGeneric)
                    AddTypeArray(ctype.Others![0], data);
                else
                    AddTypeArray(ctype, data);
            }
            else if (ctype.IsContainer)
            {
                // inner class
                var innerWriter = new TypeWriter();
                innerWriter.AddClass(data);
                Container.AddContainer(innerWriter.Container);
            }
            else
            {
                // data
                var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
                Container.AddBytes(bytes!);
            }
        }

        /// <summary>
        /// Thêm một mảng
        /// </summary>
        protected void AddTypeArray(CType ctype, object data)
        {
            var dataType = ctype.IsGeneric ? ctype.Others![0] : ctype;

            if (ctype.IsBoolean)
            {
                // boolean
                var items = data as IEnumerable<bool>;
                Container.AddInt32(items!.Count());
                Container.AddBooleanArray(items!);
            }
            else
            {
                // data
                var bytes = new List<byte[]>();
                var itemCount = 0;
                foreach (var item in (IEnumerable)data)
                {
                    itemCount++;
                    bytes.Add(TypeConvert.Instance.ItemToBytes(dataType, item)!);
                }

                Container.AddInt32(itemCount);
                Container.AddBytes(bytes.SelectMany(x => x));
            }
        }

        /// <summary>
        /// Thêm một đối tượng định dạng key - value
        /// </summary>
        protected void AddTypePair(CType ctype, object data)
        {
            var keys = ctype.CustomType!.GetProperty("Keys")!.GetValue(data);
            var values = ctype.CustomType!.GetProperty("Values")!.GetValue(data);
            var count = keys!.GetType().GetProperty("Count")!.GetValue(keys);

            Container.AddInt32((int)count!);
            AddTypeArray(ctype.Others![0], keys!);
            AddTypeArray(ctype.Others![1], values!);
        }

        /// <summary>
        /// Thêm một class, lấy những thông tin fields và props
        /// </summary>
        public void AddClass<T>(T data)
        {
            Container.AddBoolean(data != null);
            if (data == null) return;

            var members = TypesPool.Scan(data);

            foreach (var member in members)
            {
                var value = member.GetValue?.Invoke(data);
                Container.AddBoolean(value != null);
                if (value != null)
                {
                    AddType(member, value);
                }
            }
        }
    }
}
