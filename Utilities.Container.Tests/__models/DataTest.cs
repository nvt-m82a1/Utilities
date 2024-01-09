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
    }

}
