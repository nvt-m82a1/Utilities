namespace Utilities.Container.BaseType
{
    /// <summary>
    /// Thao tác với field, prop của class
    /// </summary>
    public class TypeBinding
    {
        public Func<object?, object?>? GetValue;
        public Action<object?, object?>? SetValue;
    }
}
