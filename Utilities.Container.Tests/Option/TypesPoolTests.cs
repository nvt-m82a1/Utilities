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
    }
}