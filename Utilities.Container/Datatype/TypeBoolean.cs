using System.Diagnostics;
using Utilities.Container.Base;
using Utilities.Container.BaseType;
using Utilities.Container.Converter;

namespace Utilities.Container.Datatype
{
    public class TypeBoolean : TypeBase
    {
        public TypeBoolean(Type type) : base(type)
        {
        }

        public override void BindingItem(object wrap, DataContainer container, TypeConvert converter)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding.SetValue != null);

            if (container.ReadBoolean() == true)
                Binding.SetValue!.Invoke(wrap, null);
            else
            {
                Read(container, converter, (item, _) =>
                {
                    Binding.SetValue.Invoke(wrap, item);
                });
            }
        }

        public override void BindingContainer(object wrap, DataContainer container, TypeConvert converter)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding.GetValue != null);

            var value = Binding.GetValue(wrap);
            Write(value, container, converter);
        }

        public override void Read(DataContainer container, TypeConvert converter, Action<object, object?> OnItemResult)
        {
            var value = container.ReadBoolean();
            OnItemResult?.Invoke(value!, null);
        }

        public override void Write(object? value, DataContainer container, TypeConvert converter)
        {
            container.AddBoolean(value == null);
            if (value == null) return;

            container.AddBoolean((bool)value);
        }
    }
}
