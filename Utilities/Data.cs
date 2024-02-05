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

    public class Data4
    {
        public static Data4 Instance = new Data4();

        public int Id;
        public string Name;
    }

    public class Data5
    {
        public string Name = "a";
        public IEnumerable<IEnumerable<string>> Data = [["10", "11"], ["12", "13"]];
    }
}
