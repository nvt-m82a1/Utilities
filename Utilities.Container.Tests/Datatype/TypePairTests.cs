using Utilities.Container.Converter;

namespace Utilities.Container.Datatype.Tests
{
    [TestClass()]
    public class TypePairTests
    {
        [TestMethod()]
        public void ReadWriteTests_empty()
        {
            var item = new Dictionary<string, string>();
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<Dictionary<string, string>>(bytes);

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Count, data.Count);
        }

        [TestMethod()]
        public void ReadWriteTests_null()
        {
            Dictionary<string, string>? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<Dictionary<string, string>?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests()
        {
            var item = new Dictionary<string, string>
            {
                {"8234456wer4t", "0su3eisdf" },
                {"342w1eew54e3", "5sd6f45" },
            };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<Dictionary<string, string>>(bytes);

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Count, data.Count);
        }
    }
}