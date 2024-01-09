using Utilities.Container.Option;

namespace Utilities
{
    [ClassContainer]
    internal class Data
    {
        public int a;
        public string b;
        public Data2 e;
        public int f;
        public Data2 g { get; set; }
        public int h;
        public bool[] j;
    }

    [ClassContainer]
    public class Data2
    {
        public int c;
        public string d;
    }
}
