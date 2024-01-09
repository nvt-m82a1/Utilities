using System.Collections;
using System.Diagnostics;
using Utilities.Container.Base;
using Utilities.Container.BaseType;
using Utilities.Container.Converter;
using Utilities.Container.Option;

namespace Utilities.Container.Datatype
{
    public class TypeList : TypeBase
    {
        protected Type WrapType;
        protected string AddMethodName;

        public TypeList(Type wrapType, string addMethodName, Type dataType) : base(wrapType, dataType)
        {
            this.WrapType = wrapType;
            this.AddMethodName = addMethodName;
        }

        public override void BindingItem(object wrap, DataContainer container, TypeConvert converter)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding.SetValue != null);

            if (container.ReadBoolean() == true)
                Binding.SetValue!.Invoke(wrap, null);
            else
            {
                // empty list
                if (container.ReadBoolean() == true)
                {
                    if (Info.IsArray)
                    {
                        var arr = Activator.CreateInstance(Others![0].Info.Type.MakeArrayType());
                        Binding.SetValue.Invoke(wrap, arr);
                        return;
                    }
                    else
                    {
                        var list = Activator.CreateInstance(WrapType);
                        Binding.SetValue.Invoke(wrap, list);
                        return;
                    }
                }

                Read(container, converter, (list, length) =>
                {
                    Binding.SetValue.Invoke(wrap, list);
                });
            }
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
            var length = container.ReadLength();
            if (length == 0) return;

            var (len, bytes) = container.ReadArray();

            var listWrap = Activator.CreateInstance(WrapType)!;
            var addMethod = WrapType.GetMethod(this.AddMethodName);
            Action<object, object?> actionAddItem = (item, index) => addMethod!.Invoke(listWrap, [item]);

            if (Others![0].Info.IsContainer)
            {
                for (var i = 0; i < length; i++)
                    Others![0].Read(container, converter, actionAddItem);
            }
            else
            {
                var items = converter.BytesToArray(Others![0].Info, length, bytes!.ToArray(), 0);
                foreach (var item in (IEnumerable)items!)
                    actionAddItem.Invoke(item, null);
            }

            if (Info.IsArray)
            {
                var toArrayMethod = WrapType.GetMethod("ToArray");
                var arr = toArrayMethod!.Invoke(listWrap, null);
                OnItemResult?.Invoke(arr!, length);
            }
            else
                OnItemResult?.Invoke(listWrap, length);
        }

        public override void Write(object? value, DataContainer container, TypeConvert converter)
        {
            container.AddBoolean(value == null);
            if (value == null) return;

            var length = 0;
            if (Info.IsArray)
                length = ((IList)value).Count;
            else
                length = ((IEnumerable)value).Count();

            container.AddBoolean(length == 0);
            if (length == 0) return;

            var list = (IEnumerable)value;
            container.AddLength(length);

            if (Others![0].Info.IsContainer)
            {
                foreach (var item in list)
                    this.Others![0].Write(item, container, converter);
            }
            else
            {
                var itemsByte = converter.ArrayToBytes(Others![0].Info, list).SelectMany(x => x);
                container.AddArray(itemsByte);
            }
        }
    }
}
