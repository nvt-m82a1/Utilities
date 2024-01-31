using Utilities.Container.Converter;
using Utilities.Container.Tests.__models;

namespace Utilities.Container.Datatype.Tests
{
    [TestClass()]
    public class TypeEnumTests
    {
        [TestMethod()]
        public void ReadWriteTests_EnumByte_min()
        {
            BindingTest.EnumByte item = BindingTest.EnumByte.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumByte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumByte_normal()
        {
            BindingTest.EnumByte item = BindingTest.EnumByte.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumByte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumByte_max()
        {
            BindingTest.EnumByte item = BindingTest.EnumByte.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumByte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumByte_null()
        {
            BindingTest.EnumByte? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumByte?>(bytes);

            Assert.AreEqual(item, data);
        }
        [TestMethod()]
        public void ReadWriteTests_EnumSByte_min()
        {
            BindingTest.EnumSByte item = BindingTest.EnumSByte.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumSByte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumSByte_normal()
        {
            BindingTest.EnumSByte item = BindingTest.EnumSByte.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumSByte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumSByte_max()
        {
            BindingTest.EnumSByte item = BindingTest.EnumSByte.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumSByte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumSByte_null()
        {
            BindingTest.EnumSByte? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumSByte?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt16_min()
        {
            BindingTest.EnumInt16 item = BindingTest.EnumInt16.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumInt16>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt16_normal()
        {
            BindingTest.EnumInt16 item = BindingTest.EnumInt16.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumInt16>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt16_max()
        {
            BindingTest.EnumInt16 item = BindingTest.EnumInt16.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumInt16>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt16_null()
        {
            BindingTest.EnumInt16? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumInt16?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt32_min()
        {
            BindingTest.EnumInt32 item = BindingTest.EnumInt32.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumInt32>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt32_normal()
        {
            BindingTest.EnumInt32 item = BindingTest.EnumInt32.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumInt32>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt32_max()
        {
            BindingTest.EnumInt32 item = BindingTest.EnumInt32.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumInt32>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt32_null()
        {
            BindingTest.EnumInt32? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumInt32?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt64_min()
        {
            BindingTest.EnumInt64 item = BindingTest.EnumInt64.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumInt64>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt64_normal()
        {
            BindingTest.EnumInt64 item = BindingTest.EnumInt64.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumInt64>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt64_max()
        {
            BindingTest.EnumInt64 item = BindingTest.EnumInt64.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumInt64>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt64_null()
        {
            BindingTest.EnumInt64? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumInt64?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt16_min()
        {
            BindingTest.EnumUInt16 item = BindingTest.EnumUInt16.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumUInt16>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt16_normal()
        {
            BindingTest.EnumUInt16 item = BindingTest.EnumUInt16.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumUInt16>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt16_max()
        {
            BindingTest.EnumUInt16 item = BindingTest.EnumUInt16.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumUInt16>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt16_null()
        {
            BindingTest.EnumUInt16? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumUInt16?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt32_min()
        {
            BindingTest.EnumUInt32 item = BindingTest.EnumUInt32.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumUInt32>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt32_normal()
        {
            BindingTest.EnumUInt32 item = BindingTest.EnumUInt32.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumUInt32>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt32_max()
        {
            BindingTest.EnumUInt32 item = BindingTest.EnumUInt32.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumUInt32>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt32_null()
        {
            BindingTest.EnumUInt32? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumUInt32?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt64_min()
        {
            BindingTest.EnumUInt64 item = BindingTest.EnumUInt64.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumUInt64>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt64_normal()
        {
            BindingTest.EnumUInt64 item = BindingTest.EnumUInt64.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumUInt64>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt64_max()
        {
            BindingTest.EnumUInt64 item = BindingTest.EnumUInt64.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumUInt64>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt64_null()
        {
            BindingTest.EnumUInt64? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumUInt64?>(bytes);

            Assert.AreEqual(item, data);
        }
    }
}