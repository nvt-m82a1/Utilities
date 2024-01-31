using Utilities.Container.Option;
using Utilities.Container.Tests.__models;

namespace Utilities.Container.Converter.Tests
{
    [TestClass]
    internal class ForceSkipTests
    {
        [TestMethod]
        [ExpectedException(typeof(TypeConvertException))]
        public void ForceClassTest_getbytes_exception()
        {
            var data = new DataTest.ForceClass { Id = 1, Name = "forceclass" };
            var bytes = DataConvert.Instance.GetBytes(data);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeConvertException))]
        public void ForceClassTest_getitem_exception()
        {
            var data = new DataTest.ForceClass { Id = 1, Name = "forceclass" };
            var bytes = DataConvert.Instance.GetBytes(data, true);
            Assert.IsNotNull(bytes);
            var item = DataConvert.Instance.GetItem<DataTest.ForceClass>(bytes);
        }

        [TestMethod]
        public void ForceClassTest()
        {
            var data = new DataTest.ForceClass { Id = 1, Name = "forceclass" };
            var bytes = DataConvert.Instance.GetBytes(data, true);
            Assert.IsNotNull(bytes);

            var item = DataConvert.Instance.GetItem<DataTest.ForceClass>(bytes, true);
            Assert.IsNotNull(item);

            Assert.AreEqual(data.Id, item.Id);
            Assert.AreEqual(data.Name, item.Name);
        }

        [TestMethod]
        public void SkipTest_empty()
        {
            var data = new DataTest.ForceSkipClass1 { Id = 1 };
            var members = TypesPool.Scan(data.GetType(), true);
            Assert.AreEqual(0, members.Length);
        }

        [TestMethod]
        public void SkipTest_convert()
        {
            var data = new DataTest.ForceSkipClass2 { Id = 1, Name = "forceclass" };
            var members = TypesPool.Scan(data.GetType(), true);
            Assert.AreEqual(1, members.Length);
            var bytes = DataConvert.Instance.GetBytes(data, true);
            Assert.IsNotNull(bytes);

            var item = DataConvert.Instance.GetItem<DataTest.ForceSkipClass2>(bytes, true);
            Assert.IsNotNull(item);

            Assert.AreEqual(data.Id, item.Id);
        }

        [TestMethod]
        public void SkipTest_readwrite()
        {
            var data = new DataTest.ForceSkipClass2 { Id = 1, Name = "forceclass" };
            var bytes = DataBinding.Instance.ReadMembers(data, true);
            Assert.IsNotNull(bytes);

            data.Id = 2;
            data.Name = "forceclass2";
            
            DataBinding.Instance.WriteMembers(data, bytes, true);

            Assert.AreEqual(1, data.Id);
            Assert.AreEqual("forceclass2", data.Name);
        }
    }
}
