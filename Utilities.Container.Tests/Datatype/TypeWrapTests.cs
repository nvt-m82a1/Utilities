using Utilities.Container.Converter;

namespace Utilities.Container.Datatype.Tests
{
    [TestClass()]
    public class TypeWrapTests
    {
        [TestMethod()]
        public void ReadWriteTests()
        {
            var item = new TypeWrap<int>();
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<TypeWrap<int>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.Value.GetType() == typeof(int));
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
        public void ReadWriteTests_string()
        {
            var item = new TypeWrap<string> { Value = "j2o3iosdfu08oiwe" };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<TypeWrap<string>>(bytes);

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Value, data.Value);
        }
    }
}