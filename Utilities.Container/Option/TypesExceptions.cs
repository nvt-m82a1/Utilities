namespace Utilities.Container.Option
{
    public class TypeNotfoundException : Exception
    {
        public TypeNotfoundException(string message) : base(message) { }
    }

    public class TypeParseException : Exception
    {
        public TypeParseException(string message) : base(message) { }
    }
}
