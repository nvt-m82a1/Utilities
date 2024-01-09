using System.Collections;
using System.Diagnostics;
using Utilities.Container.Base;
using Utilities.Container.BaseType;
using Utilities.Container.Converter;
using Utilities.Container.Option;

namespace Utilities.Container.Datatype
{
    internal class TypePair : TypeBase
    {
        public TypePair(Type type) : base(type, type.GenericTypeArguments)
        {
        }

        public override void BindingItem(object wrap, DataContainer container, TypeConvert converter)
        {
            Debug.Assert(Binding != null);
            Debug.Assert(Binding.SetValue != null);
            if (container.ReadBoolean() != true)
                Binding.SetValue!.Invoke(wrap, null);
            else
            {
                var pairWrap = (IDictionary)Activator.CreateInstance(typeof(Dictionary<,>)
                    .MakeGenericType(this.Others![0].Info.Type, this.Others![1].Info.Type))!;

                Read(container, converter, pairWrap.Add);
                Binding.SetValue.Invoke(wrap, pairWrap);
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

        public override void Write(object? value, DataContainer container, TypeConvert converter)
        {
            container.AddBoolean(value != null);
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
