using Utilities.Container.Converter;

namespace Utilities.Container.Datatype.Tests
{
    [TestClass()]
    public class TypeBooleanTests
    {
        [TestMethod()]
        public void ReadWriteTests_true()
        {
            var item = true;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<bool>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_false()
        {
            var item = false;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<bool>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_null()
        {
            bool? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<bool?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_array()
        {
            bool[] item = [true, false, false, true, true];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<bool[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }
    }
}