using Utilities.Container.Datatype;
using Utilities.Container.Tests.__models;

namespace Utilities.Container.Option.Tests
{
    [TestClass()]
    public class TypesPoolTests
    {
        [TestMethod()]
        public void ScanTest_Hashset()
        {
            var typeInt1 = TypesPool.Scan<int>();
            var typeInt2 = TypesPool.Scan<int>();

            Assert.IsTrue(typeInt1 == typeInt2);
        }
        [TestMethod()]
        public void ScanTest_Hashset_2()
        {
            var typeInt1 = TypesPool.Scan(typeof(int));
            var typeInt2 = TypesPool.Scan<int>();

            Assert.IsTrue(typeInt1 == typeInt2);
        }

        [TestMethod()]
        public void ScanTest_Typecount()
        {
            {
                var type2 = TypesPool.Scan<DataTest.Item2>();
                Assert.IsTrue(type2.Count() == 2);
            }

            {
                var type3 = TypesPool.Scan<DataTest.Item3>();
                Assert.IsTrue(type3.Count() == 3);
            }
        }

        [TestMethod()]
        public void ScanTest_FieldProp()
        {
            var type = TypesPool.Scan<DataTest.FieldPropEvent>();

            Assert.IsTrue(type.Count() == 4);
        }

        [TestMethod()]
        public void ScanTest_Nullable()
        {
            var type = TypesPool.Scan(null);
            Assert.IsTrue(type.Count() == 0);
        }

        [TestMethod()]
        public void CreateTest_TypeBoolean()
        {
            var type = TypesPool.Create(typeof(bool));
            Assert.IsTrue(type is TypeBoolean);
        }

        [TestMethod()]
        public void CreateTest_TypeBuildin_int()
        {
            var type = TypesPool.Create(typeof(int));
            Assert.IsTrue(type is TypeBuildin);
        }

        [TestMethod()]
        public void CreateTest_TypeBuildin_string()
        {
            var type = TypesPool.Create(typeof(string));
            Assert.IsTrue(type is TypeBuildin);
        }

        [TestMethod()]
        public void CreateTest_TypeCustom()
        {
            var type = TypesPool.Create(typeof(DataTest.Item1));
            Assert.IsTrue(type is TypeCustom);
        }

        [TestMethod()]
        public void CreateTest_TypeList()
        {
            var type = TypesPool.Create(typeof(List<int>));
            Assert.IsTrue(type is TypeList);
        }

        [TestMethod()]
        public void CreateTest_TypeList_Stack()
        {
            var type = TypesPool.Create(typeof(Stack<int>));
            Assert.IsTrue(type is TypeList);
        }

        [TestMethod()]
        public void CreateTest_TypeList_Queue()
        {
            var type = TypesPool.Create(typeof(Queue<int>));
            Assert.IsTrue(type is TypeList);
        }

        [TestMethod()]
        public void CreateTest_TypeList_LinkedList()
        {
            var type = TypesPool.Create(typeof(LinkedList<int>));
            Assert.IsTrue(type is TypeList);
        }

        [TestMethod()]
        public void CreateTest_TypeList_array()
        {
            var type = TypesPool.Create(typeof(int[]));
            Assert.IsTrue(type is TypeList);
        }

        [TestMethod()]
        public void CreateTest_TypePair()
        {
            var type = TypesPool.Create(typeof(Dictionary<int, string>));
            Assert.IsTrue(type is TypePair);
        }

    }
}