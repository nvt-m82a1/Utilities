using Utilities.Container.Option;

namespace Utilities.Container.Datatype
{
    [ClassContainer]
    public class TypeWrap<T>
    {
        public T? Value { get; set; }
    }
}
