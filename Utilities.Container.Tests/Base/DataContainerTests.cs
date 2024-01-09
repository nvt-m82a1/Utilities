using Utilities.Container.Base;

namespace Utilities.Container.Tests.Base
{
    [TestClass()]
    public class DataContainerTests
    {
        [TestMethod()]
        public void AddInt32Test()
        {
            var item = 85688498;
            var container = new DataContainer();
            container.AddLength(item);
            var data = container.ReadLength();

            Assert.IsTrue(data == item);
        }

        [TestMethod()]
        public void AddBooleanTest()
        {
            var item = true;
            var container = new DataContainer();
            container.AddBoolean(item);

            var data = container.ReadBoolean();

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void AddBooleanArrayTest()
        {
            var item = new List<bool> { true, false, false, true };
            var container = new DataContainer();
            container.AddBooleanArray(item);

            var data = container.ReadBooleanArray(5).ToArray();

            Assert.AreEqual(true, data[0]);
            Assert.AreEqual(false, data[1]);
            Assert.AreEqual(false, data[2]);
            Assert.AreEqual(true, data[3]);
            Assert.AreEqual(null, data[4]);
        }

        [TestMethod()]
        public void AddArrayTest()
        {
            var item = new List<byte> { 1, 2, 3, 4, 5 };
            var container = new DataContainer();
            container.AddArray(item);

            var (len, data) = container.ReadArray();

            Assert.IsTrue(data is not null);
            Assert.IsTrue(item.SequenceEqual(data));
        }
    }
}