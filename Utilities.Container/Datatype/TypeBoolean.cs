using System.Diagnostics;
using Utilities.Container.Base;
using Utilities.Container.BaseType;
using Utilities.Container.Converter;
using Utilities.Container.Option;

namespace Utilities.Container.Datatype
{
    /// <summary>
    /// Kiểu dữ liệu bool
    /// </summary>
    public class TypeBoolean : TypeBase
    {
        public TypeBoolean(Type type) : base(type)
        {
        }

        public override void BindingItem(object wrap, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding.SetValue != null);

            if (container.ReadBoolean() == true)
                Binding.SetValue!.Invoke(wrap, null);
            else
            {
                Read(container, converter, refsPool, (item, _) =>
                {
                    Binding.SetValue.Invoke(wrap, item);
                });
            }
        }

        public override void BindingContainer(object wrap, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding.GetValue != null);

            var value = Binding.GetValue(wrap);
            Write(value, container, converter, refsPool);
        }

        public override void Read(DataContainer container, TypeConvert converter, ReferencesPool refsPool, Action<object, object?> OnItemResult)
        {
            var value = container.ReadBoolean();
            OnItemResult?.Invoke(value!, null);
        }

        public override void Write(object? value, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            container.AddBoolean(value == null);
            if (value == null) return;

            container.AddBoolean((bool)value);
        }
    }
}
