namespace Utilities
{
    internal class Data
    {
        public int a;
        public string b;
        public Data2 e;
        public int f;
        public Data2 g { get; set; }
        public int h;
        public bool[] j;
        public DataEnum k;
        public DataEnum[] m;

        public Data ref_this;

        public Data()
        {
            ref_this = this;
        }
    }

    public class Data2
    {
        public int c;
        public string d;
    }

    public enum DataEnum : byte
    {
        No0 = 0,
        No1 = 1,
        No2 = 2,
    }
}
