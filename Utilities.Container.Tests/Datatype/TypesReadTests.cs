using System.Collections.Concurrent;

namespace Utilities.Container.Datatype.Tests
{
    [TestClass()]
    public class TypesReadTests
    {
        [TestMethod()]
        public void FillCTypeTest_Dictionary2()
        {
            var item = new Dictionary<int, int>();
            var ctype = new CType();
            TypesRead.FillCType(ctype, item.GetType());

            Assert.IsTrue(ctype.IsPair == true);
            Assert.IsTrue(ctype.Others is not null);
            Assert.IsTrue(ctype.Others.Length == 2);
            Assert.IsTrue(ctype.CustomType == item.GetType());
        }

        [TestMethod()]
        public void FillCTypeTest_Stack1()
        {
            var item = new Stack<int>();
            var ctype = new CType();
            TypesRead.FillCType(ctype, item.GetType());

            Assert.IsTrue(ctype.IsEnumerable == true);
            Assert.IsTrue(ctype.IsGeneric == true);
            Assert.IsTrue(ctype.Others is not null);
            Assert.IsTrue(ctype.Others.Length == 1);
        }

        [TestMethod()]
        public void FillCTypeTest_CStack1()
        {
            var item = new ConcurrentStack<int>();
            var ctype = new CType();
            TypesRead.FillCType(ctype, item.GetType());

            Assert.IsTrue(ctype.IsEnumerable == true);
            Assert.IsTrue(ctype.IsGeneric == true);
            Assert.IsTrue(ctype.Others is not null);
            Assert.IsTrue(ctype.Others.Length == 1);
        }

        [TestMethod()]
        public void FillCTypeTest_Queue1()
        {
            var item = new Queue<int>();
            var ctype = new CType();
            TypesRead.FillCType(ctype, item.GetType());

            Assert.IsTrue(ctype.IsEnumerable == true);
            Assert.IsTrue(ctype.IsGeneric == true);
            Assert.IsTrue(ctype.Others is not null);
            Assert.IsTrue(ctype.Others.Length == 1);
        }

        [TestMethod()]
        public void FillCTypeTest_CQueue1()
        {
            var item = new ConcurrentQueue<int>();
            var ctype = new CType();
            TypesRead.FillCType(ctype, item.GetType());

            Assert.IsTrue(ctype.IsEnumerable == true);
            Assert.IsTrue(ctype.IsGeneric == true);
            Assert.IsTrue(ctype.Others is not null);
            Assert.IsTrue(ctype.Others.Length == 1);
        }

        [TestMethod()]
        public void FillCTypeTest_List1()
        {
            var item = new List<int>();
            var ctype = new CType();
            TypesRead.FillCType(ctype, item.GetType());

            Assert.IsTrue(ctype.IsEnumerable == true);
            Assert.IsTrue(ctype.IsGeneric == true);
            Assert.IsTrue(ctype.Others is not null);
            Assert.IsTrue(ctype.Others.Length == 1);
        }

        [TestMethod()]
        public void FillCTypeTest_LinkedList1()
        {
            var item = new LinkedList<int>();
            var ctype = new CType();
            TypesRead.FillCType(ctype, item.GetType());

            Assert.IsTrue(ctype.IsEnumerable == true);
            Assert.IsTrue(ctype.IsGeneric == true);
            Assert.IsTrue(ctype.Others is not null);
            Assert.IsTrue(ctype.Others.Length == 1);
        }

        [TestMethod()]
        public void FillCTypeTest_IEnumerable1()
        {
            IEnumerable<int> item = new List<int>().AsEnumerable();
            var ctype = new CType();
            TypesRead.FillCType(ctype, item.GetType());

            Assert.IsTrue(ctype.IsEnumerable == true);
            Assert.IsTrue(ctype.Others is not null);
            Assert.IsTrue(ctype.Others.Length == 1);
        }

        [TestMethod()]
        public void FillCTypeTest_IEnumerable1_generic()
        {
            IEnumerable<int> item = new List<int>().AsEnumerable();
            var ctype = new CType();
            TypesRead.FillCType(ctype, item.GetType());

            Assert.IsTrue(ctype.IsEnumerable == true);
            Assert.IsTrue(ctype.IsGeneric == true);
            Assert.IsTrue(ctype.Others is not null);
            Assert.IsTrue(ctype.Others.Length == 1);
        }

        [TestMethod()]
        public void FillCTypeTest_Concat2Iterator1()
        {
            var arr1 = new int[1];
            var arr2 = new int[1];
            var item = arr1.Concat(arr2);
            var ctype = new CType();
            TypesRead.FillCType(ctype, item.GetType());

            Assert.IsTrue(ctype.IsEnumerable == true);
            Assert.IsTrue(ctype.IsGeneric == true);
        }

        [TestMethod()]
        public void FillCTypeTest_ConcatNIterator1()
        {
            var arr1 = new int[1];
            var arr2 = new int[1];
            var arr3 = new int[1];
            var item = arr1.Concat(arr2).Concat(arr3);
            var ctype = new CType();
            TypesRead.FillCType(ctype, item.GetType());

            Assert.IsTrue(ctype.IsEnumerable == true);
            Assert.IsTrue(ctype.IsGeneric == true);
        }

        [TestMethod()]
        public void FillCTypeTest_Nullable1()
        {
            var ctype = new CType();
            TypesRead.FillCType(ctype, typeof(int?));

            Assert.IsTrue(ctype.IsNullable == true);
        }

        [TestMethod()]
        public void FillCTypeTest_Array()
        {
            var ctype = new CType();
            TypesRead.FillCType(ctype, typeof(int[]));

            Assert.IsTrue(ctype.IsEnumerable == true);
        }

    }
}