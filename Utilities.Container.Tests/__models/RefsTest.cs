namespace Utilities.Container.Tests.__models
{
    internal class RefsTest
    {
        public class RefData1
        {
            public int Id;
            public RefData1 Self;
        }

        public class RefData2
        {
            public IEnumerable<RefData1> Arr;
        }

        public class RefData3
        {
            public int Item3;
            public RefData4 RefData4;
        }

        public class RefData4
        {
            public int Item4;
            public RefData3 RefData3;
        }

        public class RefData5
        {
            public RefData3 RefData3;
            public RefData4 RefData4;
        }
    }
}
