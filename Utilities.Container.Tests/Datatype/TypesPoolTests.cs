using Utilities.Container.Tests.__models;

namespace Utilities.Container.Datatype.Tests
{
    [TestClass()]
    public class TypesPoolTests
    {
        [TestMethod()]
        public void ScanTest_Hashset()
        {
            var ctypeInt1 = TypesPool.Scan(8578545);
            var ctypeInt2 = TypesPool.Scan(8453468);

            Assert.IsTrue(ctypeInt1 == ctypeInt2);
        }

        [TestMethod()]
        public void ScanTest_Typecount()
        {
            {
                var item2 = new DataTest.Item2();
                var ctype2 = TypesPool.Scan(item2);
                Assert.IsTrue(ctype2.Count() == 2);
            }

            {
                var item3 = new DataTest.Item3();
                var ctype3 = TypesPool.Scan(item3);
                Assert.IsTrue(ctype3.Count() == 3);
            }
        }

        [TestMethod()]
        public void ScanTest_FieldProp()
        {
            var item = new DataTest.FieldPropEvent();
            var ctype = TypesPool.Scan(item);

            Assert.IsTrue(ctype.Count() == 4);
        }

        [TestMethod()]
        public void ScanTest_Null()
        {
            int? data = null;
            var ctype = TypesPool.Scan(data);
            Assert.IsTrue(ctype.Count() == 0);
        }
    }
}