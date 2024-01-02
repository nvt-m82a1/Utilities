using Utilities.Container.Tests.__models;

namespace Utilities.Container.Base.Tests
{
    [TestClass()]
    public class TotalBytesTests
    {
        [TestMethod()]
        public void BitTests_empty()
        {
            var container = new BitContainer();
            var bytes = container.Export();

            Assert.AreEqual(0, container.TotalElements);
            Assert.AreEqual(1, container.TotalExportBytes);
            Assert.AreEqual(1, bytes.Count());
        }

        [TestMethod()]
        public void BitTests_1()
        {
            var container = new BitContainer();
            container.Add(true);
            var bytes = container.Export();

            Assert.AreEqual(1, container.TotalElements);
            Assert.AreEqual(3, container.TotalExportBytes);
            Assert.AreEqual(3, bytes.Count());
        }

        [TestMethod()]
        public void ByteTests_empty()
        {
            var container = new ByteContainer();
            var bytes = container.Export();

            Assert.AreEqual(0, container.TotalElements);
            Assert.AreEqual(4, container.TotalExportBytes);
            Assert.AreEqual(4, bytes.Count());
        }

        [TestMethod()]
        public void ByteTests_1()
        {
            var container = new ByteContainer();
            container.AddItem(1);
            var bytes = container.Export();

            Assert.AreEqual(1, container.TotalElements);
            Assert.AreEqual(14, container.TotalExportBytes);
            Assert.AreEqual(14, bytes.Count());
        }

        [TestMethod()]
        public void DataTests_empty()
        {
            var container = new ContainerTest();
            var bytes = container.Export();

            Assert.AreEqual(0, container.TotalElements);
            Assert.AreEqual(4, container.TotalExportBytes);
            Assert.AreEqual(4, bytes.Count());
        }

        [TestMethod()]
        public void DataTests_1()
        {
            var container = new ContainerTest();
            container.AddItem(1);
            var bytes = container.Export();

            Assert.AreEqual(1, container.TotalElements);
            Assert.AreEqual(20, container.TotalExportBytes);
            Assert.AreEqual(20, bytes.Count());
        }
    }
}