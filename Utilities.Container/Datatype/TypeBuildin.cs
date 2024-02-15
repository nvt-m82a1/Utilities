using System.Collections;
using System.Diagnostics;
using Utilities.Container.Base;
using Utilities.Container.BaseType;
using Utilities.Container.Converter;
using Utilities.Container.Option;

namespace Utilities.Container.Datatype
{
    /// <summary>
    /// Kiểu dữ liệu buildin của hệ thống như byte, int, ...
    /// </summary>
    public class TypeBuildin : TypeBase
    {
        public TypeBuildin(Type type) : base(type)
        {
        }

        public override void BindingItem(object wrap, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding!.SetValue != null);

            Read(container, converter, refsPool, (value, _) =>
            {
                Binding.SetValue!.Invoke(wrap, value);
            });
        }

        public override void BindingContainer(object wrap, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding!.GetValue != null);

            var value = Binding.GetValue!.Invoke(wrap);
            Write(value, container, converter, refsPool);
        }

        public override void Read(DataContainer container, TypeConvert converter, ReferencesPool refsPool, Action<object?, object?> OnItemResult)
        {
            if (container.ReadBoolean() == true)
            {
                OnItemResult.Invoke(null, null);
                return;
            }

            var (len, bytes) = container.ReadArray();
            var items = (IEnumerable)converter.BytesToArray(this.Info, 1, bytes!.ToArray(), 0)!;
            var item = items.First();
            OnItemResult?.Invoke(item!, null);
        }

        public override void Write(object? data, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            container.AddBoolean(data == null);
            if (data == null) return;

            var bytes = converter.ItemToBytes(this.Info, data);
            container.AddArray(bytes!);
        }
    }
}
