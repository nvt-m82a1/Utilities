using System.Collections;
using System.Diagnostics;
using Utilities.Container.Base;
using Utilities.Container.BaseType;
using Utilities.Container.Converter;
using Utilities.Container.Option;

namespace Utilities.Container.Datatype
{
    public class TypeEnum : TypeBase
    {
        public TypeEnum(Type type, Type innerType) : base(type, innerType)
        {
        }

        public override void BindingItem(object wrap, DataContainer container, TypeConvert converter)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding.SetValue != null);

            if (container.ReadBoolean() == true)
                Binding.SetValue!.Invoke(wrap, null);
            else
                Read(container, converter, (value, _) => Binding.SetValue.Invoke(wrap, value));
        }

        public override void BindingContainer(object wrap, DataContainer container, TypeConvert converter)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding.GetValue != null);

            var value = Binding.GetValue.Invoke(wrap);
            Write(value, container, converter);
        }

        public override void Read(DataContainer container, TypeConvert converter, Action<object, object?> OnItemResult)
        {
            var (len, bytes) = container.ReadArray();
            var items = (IEnumerable)converter.BytesToArray(this.Others![0].Info, 1, bytes!.ToArray(), 0)!;
            var innerItem = items.First();
            var item = Enum.ToObject(this.Info.Type, innerItem!);
            OnItemResult?.Invoke(item!, null);
        }

        public override void Write(object? value, DataContainer container, TypeConvert converter)
        {
            container.AddBoolean(value == null);

            if (value == null) return;
            var bytes = converter.ItemToBytes(this.Others![0].Info, value);
            container.AddArray(bytes!);
        }
    }
}
