using Utilities.Container.Option;

namespace Utilities.Container.Datatype
{
    [ClassContainer]
    public class TypeWrap<T>
    {
        public TypeWrap() { }
        public TypeWrap(T? value)
        {
            Value = value;
        }

        public T? Value { get; set; }
    }
}
