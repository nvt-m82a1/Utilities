using System.Collections;
using System.Diagnostics;
using Utilities.Container.Base;
using Utilities.Container.BaseType;
using Utilities.Container.Converter;
using Utilities.Container.Option;

namespace Utilities.Container.Datatype
{
    /// <summary>
    /// Kiểu dữ liệu Key - Value
    /// </summary>
    public class TypePair : TypeBase
    {
        public TypePair(Type type) : base(type, type.GenericTypeArguments)
        {
        }

        public override void BindingItem(object wrap, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding!.SetValue != null);

            var pairWrap = (IDictionary)Activator.CreateInstance(typeof(Dictionary<,>)
                .MakeGenericType(this.Others![0].Info.Type, this.Others![1].Info.Type))!;

            Read(container, converter, refsPool, (key, value) =>
            {
                if (key != null)
                    pairWrap.Add(key, value);
                else
                {
                    Binding.SetValue!.Invoke(wrap, null);
                    return;
                }
            });

            Binding.SetValue!.Invoke(wrap, pairWrap);
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

            var length = container.ReadLength();
            if (length == 0) return;

            var listKey = ReadPairItems(length, Others![0], container, converter, refsPool);
            var listValue = ReadPairItems(length, Others![1], container, converter, refsPool);

            var keyItor = ((IEnumerable)listKey).GetEnumerator();
            var valueItor = ((IEnumerable)listValue).GetEnumerator();
            while (keyItor.MoveNext())
            {
                valueItor.MoveNext();
                OnItemResult?.Invoke(keyItor.Current, valueItor.Current);
            }
        }

        public override void Write(object? data, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            container.AddBoolean(data == null);
            if (data == null) return;

            var pair = (IDictionary)data;

            container.AddLength(pair.Count);
            if (pair.Count == 0) return;

            WritePairItems(pair.Keys, Others![0], container, converter, refsPool);
            WritePairItems(pair.Values, Others![1], container, converter, refsPool);
        }

        public static object ReadPairItems(int length, TypeBase valueType, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            if (valueType is TypeCustom or TypeList)
            {
                var list = Activator.CreateInstance(typeof(List<>).MakeGenericType(valueType.Info.Type))!;
                var addMethod = list.GetType().GetMethod("Add");
                Action<object?, object?> actionAddItem = (item, index) => addMethod!.Invoke(list, [item]);

                for (var i = 0; i < length; i++)
                    valueType.Read(container, converter, refsPool, actionAddItem);

                return list;
            }
            else if (valueType is TypeEnum)
            {
                var (len, bytes) = container.ReadArray();
                return converter.BytesToArray(valueType.Others![0].Info, length, bytes!.ToArray(), 0)!;
            }
            else
            {
                var (len, bytes) = container.ReadArray();
                return converter.BytesToArray(valueType.Info, length, bytes!.ToArray(), 0)!;
            }
        }

        public static void WritePairItems(object? value, TypeBase valueType, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            var list = (IEnumerable)value!;

            if (valueType is TypeCustom or TypeList)
            {
                foreach (var item in list)
                    valueType.Write(item, container, converter, refsPool);
            }
            else if (valueType is TypeEnum)
            {
                var itemsByte = converter.ArrayToBytes(valueType.Others![0].Info, list).SelectMany(x => x);
                container.AddArray(itemsByte);
            }
            else
            {
                var itemsByte = converter.ArrayToBytes(valueType.Info, list).SelectMany(x => x);
                container.AddArray(itemsByte);
            }
        }
    }
}
