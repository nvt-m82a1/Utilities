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

            if (container.ReadBoolean() == true)
                Binding.SetValue!.Invoke(wrap, null);
            else
            {
                 var refFound = container.ReadBoolean();
                if (refFound == true)
                {
                    var refIndex = container.ReadLength();
                    var refValue = refsPool.GetValue(refIndex);
                    Binding.SetValue.Invoke(wrap, refValue!);
                }
                else
                {
                    Read(container, converter, refsPool, (instance, _) =>
                    {
                        Binding.SetValue.Invoke(wrap, instance);
                    });
                }
            }
        }

        public override void BindingContainer(object wrap, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding.GetValue != null);

            var innerWrap = Binding.GetValue.Invoke(wrap);
            Write(innerWrap, container, converter, refsPool);
        }

        public override void Read(DataContainer container, TypeConvert converter, ReferencesPool refsPool, Action<object, object?> OnItemResult)
        {
            var instance = Activator.CreateInstance(this.Info.Type);
            var members = TypesPool.Scan(this.Info.Type);

            refsPool.FindValue(instance!);

            var innerContainer = container.ReadContainer();
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
                    var memberValue = member.Binding!.GetValue!(innerWrap);
                    member.Write(memberValue, subContainer, converter, refsPool);
                }
                container.AddContainer(subContainer);
            }
        }
    }
}
