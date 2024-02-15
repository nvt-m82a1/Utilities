using System.Collections;
using System.Diagnostics;
using System.Reflection;
using Utilities.Container.Base;
using Utilities.Container.BaseType;
using Utilities.Container.Converter;
using Utilities.Container.Option;

namespace Utilities.Container.Datatype
{
    /// <summary>
    /// Kiểu dữ liệu danh sách
    /// </summary>
    public class TypeList : TypeBase
    {
        protected MethodInfo? AddMethod;

        public TypeList(Type wrapType, string addMethodName, Type dataType) : base(wrapType, dataType)
        {
            this.AddMethod = Info.Type.GetMethod(addMethodName, [dataType]);
        }

        public override void BindingItem(object wrap, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding!.SetValue != null);

            Read(container, converter, refsPool, (list, length) =>
            {
                Binding.SetValue!.Invoke(wrap, list);
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
            
            if (container.ReadBoolean() == true)
            {
                if (Info.IsArray)
                {
                    var arr = Activator.CreateInstance(Others![0].Info.Type.MakeArrayType());
                    OnItemResult.Invoke(arr, null);
                    return;
                }
                else
                {
                    var list = Activator.CreateInstance(Info.Type);
                    OnItemResult.Invoke(list, null);
                    return;
                }
            }

            var length = container.ReadLength();
            if (length == 0) return;

            var listWrap = Activator.CreateInstance(Info.Type)!;
            Action<object?, object?> actionAddItem = (item, index) => AddMethod!.Invoke(listWrap, [item]);
            
            if (Others![0] is TypeCustom or TypeList)
            {
                for (var i = 0; i < length; i++)
                    Others![0].Read(container, converter, refsPool, actionAddItem);
            }
            else if (Others![0] is TypeEnum)
            {
                var (len, bytes) = container.ReadArray();
                var items = converter.BytesToArray(Others![0].Others![0].Info, length, bytes!.ToArray(), 0);
                foreach (var item in (IEnumerable)items!)
                    actionAddItem.Invoke(Enum.ToObject(Others![0].Info.Type, item), null);
            }
            else
            {
                var (len, bytes) = container.ReadArray();
                var items = converter.BytesToArray(Others![0].Info, length, bytes!.ToArray(), 0);
                foreach (var item in (IEnumerable)items!)
                    actionAddItem.Invoke(item, null);
            }

            if (Info.IsArray)
            {
                var toArrayMethod = Info.Type.GetMethod("ToArray");
                var arr = toArrayMethod!.Invoke(listWrap, null);
                OnItemResult?.Invoke(arr!, length);
            }
            else
                OnItemResult?.Invoke(listWrap, length);
        }

        public override void Write(object? data, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            container.AddBoolean(data == null);
            if (data == null) return;

            var length = 0;
            if (Info.IsArray)
                length = ((IList)data).Count;
            else
                length = ((IEnumerable)data).Count();

            container.AddBoolean(length == 0);
            if (length == 0) return;

            var list = (IEnumerable)data;
            container.AddLength(length);

            if (Others![0] is TypeCustom or TypeList)
            {
                foreach (var item in list)
                    this.Others![0].Write(item, container, converter, refsPool);
            }
            else if (Others![0] is TypeEnum)
            {
                var itemsByte = converter.ArrayToBytes(Others![0].Others![0].Info, list).SelectMany(x => x);
                container.AddArray(itemsByte);
            }
            else
            {
                var itemsByte = converter.ArrayToBytes(Others![0].Info, list).SelectMany(x => x);
                container.AddArray(itemsByte);
            }
        }
    }
}
