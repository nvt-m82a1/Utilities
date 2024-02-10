namespace Utilities.Container.Examples
{
    internal class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
        public Guid Guid { get; set; }
        public DataType DataType { get; set; }
        public Dictionary<Data2, Data3> Pairs { get; set; }
    }

    internal enum DataType
    {
        Type1 = 1,
        Type2 = 2,
        Type3 = 3
    }

    internal class Data2
    {
        public Data Parent { get; set; }
        public Data3 Item3 { get; set; }
    }

    internal class Data3
    {
        public Data Parent { get; set; }
        public Data2 Item2 { get; set; }
    }
}
