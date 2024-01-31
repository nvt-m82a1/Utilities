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
            DataTest.EnumByte item = DataTest.EnumByte.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumByte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumByte_normal()
        {
            DataTest.EnumByte item = DataTest.EnumByte.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumByte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumByte_max()
        {
            DataTest.EnumByte item = DataTest.EnumByte.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumByte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumByte_null()
        {
            DataTest.EnumByte? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumByte?>(bytes);

            Assert.AreEqual(item, data);
        }
        [TestMethod()]
        public void ReadWriteTests_EnumSByte_min()
        {
            DataTest.EnumSByte item = DataTest.EnumSByte.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumSByte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumSByte_normal()
        {
            DataTest.EnumSByte item = DataTest.EnumSByte.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumSByte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumSByte_max()
        {
            DataTest.EnumSByte item = DataTest.EnumSByte.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumSByte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumSByte_null()
        {
            DataTest.EnumSByte? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumSByte?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt16_min()
        {
            DataTest.EnumInt16 item = DataTest.EnumInt16.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumInt16>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt16_normal()
        {
            DataTest.EnumInt16 item = DataTest.EnumInt16.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumInt16>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt16_max()
        {
            DataTest.EnumInt16 item = DataTest.EnumInt16.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumInt16>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt16_null()
        {
            DataTest.EnumInt16? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumInt16?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt32_min()
        {
            DataTest.EnumInt32 item = DataTest.EnumInt32.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumInt32>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt32_normal()
        {
            DataTest.EnumInt32 item = DataTest.EnumInt32.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumInt32>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt32_max()
        {
            DataTest.EnumInt32 item = DataTest.EnumInt32.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumInt32>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt32_null()
        {
            DataTest.EnumInt32? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumInt32?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt64_min()
        {
            DataTest.EnumInt64 item = DataTest.EnumInt64.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumInt64>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt64_normal()
        {
            DataTest.EnumInt64 item = DataTest.EnumInt64.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumInt64>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt64_max()
        {
            DataTest.EnumInt64 item = DataTest.EnumInt64.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumInt64>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumInt64_null()
        {
            DataTest.EnumInt64? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumInt64?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt16_min()
        {
            DataTest.EnumUInt16 item = DataTest.EnumUInt16.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumUInt16>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt16_normal()
        {
            DataTest.EnumUInt16 item = DataTest.EnumUInt16.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumUInt16>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt16_max()
        {
            DataTest.EnumUInt16 item = DataTest.EnumUInt16.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumUInt16>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt16_null()
        {
            DataTest.EnumUInt16? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumUInt16?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt32_min()
        {
            DataTest.EnumUInt32 item = DataTest.EnumUInt32.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumUInt32>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt32_normal()
        {
            DataTest.EnumUInt32 item = DataTest.EnumUInt32.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumUInt32>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt32_max()
        {
            DataTest.EnumUInt32 item = DataTest.EnumUInt32.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumUInt32>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt32_null()
        {
            DataTest.EnumUInt32? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumUInt32?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt64_min()
        {
            DataTest.EnumUInt64 item = DataTest.EnumUInt64.Item0;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumUInt64>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt64_normal()
        {
            DataTest.EnumUInt64 item = DataTest.EnumUInt64.Item1;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumUInt64>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt64_max()
        {
            DataTest.EnumUInt64 item = DataTest.EnumUInt64.Item2;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumUInt64>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_EnumUInt64_null()
        {
            DataTest.EnumUInt64? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumUInt64?>(bytes);

            Assert.AreEqual(item, data);
        }
    }
}