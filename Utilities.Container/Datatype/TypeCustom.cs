﻿using System.Diagnostics;
using Utilities.Container.Base;
using Utilities.Container.BaseType;
using Utilities.Container.Converter;
using Utilities.Container.Option;

namespace Utilities.Container.Datatype
{
    internal class TypeCustom : TypeBase
    {
        public TypeCustom(Type type) : base(type, type.GenericTypeArguments)
        {
        }

        public override void BindingItem(object wrap, DataContainer container, TypeConvert converter)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding.SetValue != null);

            if (container.ReadBoolean() != true)
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
            var members = TypesPool.Scan(this.Info.Type);

            var innerContainer = container.ReadContainer();
            foreach (var member in members)
            {
                member.BindingItem(instance!, innerContainer!, converter);
            }
            OnItemResult?.Invoke(instance!, null);
        }

        public override void Write(object? innerWrap, DataContainer container, TypeConvert converter)
        {
            container.AddBoolean(innerWrap != null);
            if (innerWrap == null) return;

            var subContainer = new DataContainer();
            var members = TypesPool.Scan(innerWrap.GetType());
            foreach (var member in members)
            {
                var memberValue = member.Binding!.GetValue!(innerWrap);
                member.Write(memberValue, subContainer, converter);
            }
            container.AddContainer(subContainer);
        }
    }
}
