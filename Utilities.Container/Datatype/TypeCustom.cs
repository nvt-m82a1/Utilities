using System.Diagnostics;
using Utilities.Container.Base;
using Utilities.Container.BaseType;
using Utilities.Container.Converter;
using Utilities.Container.Option;

namespace Utilities.Container.Datatype
{
    /// <summary>
    /// Lưu trữ dữ liệu class
    /// </summary>
    public class TypeCustom : TypeBase
    {
        public TypeCustom(Type type) : base(type, type.GenericTypeArguments)
        {
        }

        public override void BindingItem(object wrap, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding.SetValue != null);

            Read(container, converter, refsPool, (instance, _) =>
            {
                Binding.SetValue.Invoke(wrap, instance);
            });
        }

        public override void BindingContainer(object wrap, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding.GetValue != null);

            var innerWrap = Binding.GetValue.Invoke(wrap);
            Write(innerWrap, container, converter, refsPool);
        }

        public override void Read(DataContainer container, TypeConvert converter, ReferencesPool refsPool, Action<object?, object?> OnItemResult)
        {
            if (container.ReadBoolean() == true)
            {
                OnItemResult.Invoke(null, null);
                return;
            }

            var refFound = container.ReadBoolean();
            if (refFound == true)
            {
                var refIndex = container.ReadLength();
                var refValue = refsPool.GetValue(refIndex);
                OnItemResult?.Invoke(refValue, null);
                return;
            }

            var instance = Activator.CreateInstance(this.Info.Type);
            refsPool.FindValue(instance!);

            var innerContainer = container.ReadContainer();
            var members = TypesPool.Scan(this.Info.Type);
            foreach (var member in members)
            {
                member.BindingItem(instance!, innerContainer!, converter, refsPool);
            }
            OnItemResult?.Invoke(instance!, null);
        }

        public override void Write(object? innerWrap, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            container.AddBoolean(innerWrap == null);
            if (innerWrap == null) return;

            var (refFound, refIndex) = refsPool.FindValue(innerWrap);
            container.AddBoolean(refFound);

            if (refFound)
            {
                container.AddLength(refIndex);
            }
            else
            {
                var subContainer = new DataContainer();
                var members = TypesPool.Scan(innerWrap.GetType());
                foreach (var member in members)
                {
                    member.BindingContainer(innerWrap, subContainer, converter, refsPool);
                }
                container.AddContainer(subContainer);
            }
        }
    }
}
