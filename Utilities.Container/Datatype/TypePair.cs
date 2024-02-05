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
            Debug.Assert(Binding.SetValue != null);

            var pairWrap = (IDictionary)Activator.CreateInstance(typeof(Dictionary<,>)
                .MakeGenericType(this.Others![0].Info.Type, this.Others![1].Info.Type))!;

            Read(container, converter, refsPool, (key, value) =>
            {
                if (key != null)
                    pairWrap.Add(key, value);
                else
                {
                    Binding.SetValue.Invoke(wrap, null);
                    return;
                }
            });

            Binding.SetValue.Invoke(wrap, pairWrap);
        }

        public override void BindingContainer(object wrap, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding.GetValue != null);

            var value = Binding.GetValue.Invoke(wrap);
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

            var (keyLength, keyBytes) = container.ReadArray();
            var (valueLength, valueBytes) = container.ReadArray();

            var keys = converter.BytesToArray(this.Others![0].Info, length, keyBytes!.ToArray(), 0);
            var values = converter.BytesToArray(this.Others![1].Info, length, valueBytes!.ToArray(), 0);

            if (keys is null or not IEnumerable || values is null or not IEnumerable)
                throw new TypeParseException(this.Info.FullName);

            var keyItor = ((IEnumerable)keys).GetEnumerator();
            var valueItor = ((IEnumerable)values).GetEnumerator();
            while (keyItor.MoveNext())
            {
                valueItor.MoveNext();
                OnItemResult?.Invoke(keyItor.Current, valueItor.Current);
            }
        }

        public override void Write(object? value, DataContainer container, TypeConvert converter, ReferencesPool refsPool)
        {
            container.AddBoolean(value == null);
            if (value == null) return;

            var pair = (IDictionary)value;

            container.AddLength(pair.Count);
            if (pair.Count == 0) return;

            var keyBytes = converter.ArrayToBytes(this.Others![0].Info, pair.Keys).SelectMany(x => x);
            var valueBytes = converter.ArrayToBytes(this.Others![1].Info, pair.Values).SelectMany(x => x);
            container.AddArray(keyBytes);
            container.AddArray(valueBytes);
        }
    }
}
