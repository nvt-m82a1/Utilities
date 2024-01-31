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
        protected bool forceClass;

        public TypeCustom(Type type, bool forceClass = false) : base(type, type.GenericTypeArguments)
        {
            this.forceClass = forceClass;
        }

        public override void BindingItem(object wrap, DataContainer container, TypeConvert converter)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding.SetValue != null);

            if (container.ReadBoolean() == true)
                Binding.SetValue!.Invoke(wrap, null);
            else
                Read(container, converter, (instance, _) => Binding.SetValue.Invoke(wrap, instance));
        }

        public override void BindingContainer(object wrap, DataContainer container, TypeConvert converter)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding.GetValue != null);

            var innerWrap = Binding.GetValue.Invoke(wrap);
            Write(innerWrap, container, converter);
        }

        public override void Read(DataContainer container, TypeConvert converter, Action<object, object?> OnItemResult)
        {
            var instance = Activator.CreateInstance(this.Info.Type);
            var members = TypesPool.Scan(this.Info.Type, forceClass);

            var innerContainer = container.ReadContainer();
            foreach (var member in members)
            {
                member.BindingItem(instance!, innerContainer!, converter);
            }
            OnItemResult?.Invoke(instance!, null);
        }

        public override void Write(object? innerWrap, DataContainer container, TypeConvert converter)
        {
            container.AddBoolean(innerWrap == null);
            if (innerWrap == null) return;

            var subContainer = new DataContainer();
            var members = TypesPool.Scan(innerWrap.GetType(), forceClass);
            foreach (var member in members)
            {
                var memberValue = member.Binding!.GetValue!(innerWrap);
                member.Write(memberValue, subContainer, converter);
            }
            container.AddContainer(subContainer);
        }
    }
}
