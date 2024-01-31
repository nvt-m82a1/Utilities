using Utilities.Container.Option;

namespace Utilities.Container.Tests.__models
{
    internal class DataTest
    {
        [ClassContainer]
        public class Item1
        {
            public int Id { get; set; }
        }

        [ClassContainer]
        public class Item2
        {
            public int Id { get; set; }
            public string? Name { get; set; }
        }

        [ClassContainer]
        public class Item3
        {
            public Guid? Id;
            public string? Name;
            public string? Description;
        }

        [ClassContainer]
        public class List1
        {
            public List<int> Items;
        }

        [ClassContainer]
        public class List2
        {
            public List<int> Items;
            public int[] Items2;
        }

        [ClassContainer]
        public class Dictionary2
        {
            public Dictionary<string, string> Pair;
        }

        [ClassContainer]
        public class ItemComplex
        {
            public int Id { get; set; }
            public Item1 Item1 { get; set; }
            public Item2 Item2 { get; set; }
            public Item3 Item3 { get; set; }
            public List1 List1 { get; set; }
            public List2 List2 { get; set; }
            public Dictionary2 Dictionary2 { get; set;}
        }

        [ClassContainer]
        public class FieldPropEvent
        {
            public int Field1;
            public int Field2;
            public string Prop1 { get; set; }
            public string Prop2 { get; set; }

            public event EventHandler<EventArgs> Event1;
            public delegate void OnEvent1();
        }

        public class ForceClass
        {
            public int Id;
            public string Name;
        }

        public class ForceSkipClass1
        {
            [SkipContainer]
            public int Id;
        }

        public class ForceSkipClass2
        {
            public int Id;

            [SkipContainer]
            public string? Name;
        }

        public class ForceSkipClass3
        {
            public int Id;

            public ForceSkipClass2 Class2;

            [SkipContainer]
            public ForceSkipClass2? Class2Skip;

            [SkipContainer]
            public string? Name;
        }

        public enum EnumByte : Byte
        {
            Item0 = Byte.MinValue,
            Item1 = 100,
            Item2 = Byte.MaxValue,
        }

        public enum EnumSByte : SByte
        {
            Item0 = SByte.MinValue,
            Item1 = 10,
            Item2 = SByte.MaxValue,
        }

        public enum EnumInt16 : Int16
        {
            Item0 = Int16.MinValue,
            Item1 = 10000,
            Item2 = Int16.MaxValue,
        }

        public enum EnumInt32 : Int32
        {
            Item0 = Int32.MinValue,
            Item1 = 100000,
            Item2 = Int32.MaxValue,
        }

        public enum EnumInt64 : Int64
        {
            Item0 = Int64.MinValue,
            Item1 = 1000000,
            Item2 = Int64.MaxValue,
        }

        public enum EnumUInt16 : UInt16
        {
            Item0 = UInt16.MinValue,
            Item1 = 32000,
            Item2 = UInt16.MaxValue,
        }

        public enum EnumUInt32 : UInt32
        {
            Item0 = UInt32.MinValue,
            Item1 = 32000,
            Item2 = UInt32.MaxValue,
        }

        public enum EnumUInt64 : UInt64
        {
            Item0 = UInt64.MinValue,
            Item1 = 320000000,
            Item2 = UInt64.MaxValue,
        }
    }
}
