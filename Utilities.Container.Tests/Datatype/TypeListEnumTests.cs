using Utilities.Container.Converter;
using Utilities.Container.Tests.__models;

namespace Utilities.Container.Datatype.Tests
{
    [TestClass()]
    public class TypeListEnumTests
    {
        [TestMethod()]
        public void ReadWriteTests_empty()
        {
            var item = new List<DataTest.EnumByte>();
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<DataTest.EnumByte>>(bytes);

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Count, data.Count);
        }

        [TestMethod()]
        public void ReadWriteTests_null()
        {
            List<DataTest.EnumByte>? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<DataTest.EnumByte>?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_list_EnumByte()
        {
            List<DataTest.EnumByte> item = new List<DataTest.EnumByte> { DataTest.EnumByte.Item1, DataTest.EnumByte.Item2, DataTest.EnumByte.Item0, DataTest.EnumByte.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<DataTest.EnumByte>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumByte()
        {
            DataTest.EnumByte[] item = [DataTest.EnumByte.Item2, DataTest.EnumByte.Item1, DataTest.EnumByte.Item0, DataTest.EnumByte.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumByte[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }
        [TestMethod()]
        public void ReadWriteTests_list_EnumSByte()
        {
            List<DataTest.EnumSByte> item = new List<DataTest.EnumSByte> { DataTest.EnumSByte.Item1, DataTest.EnumSByte.Item2, DataTest.EnumSByte.Item0, DataTest.EnumSByte.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<DataTest.EnumSByte>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumSByte()
        {
            DataTest.EnumSByte[] item = [DataTest.EnumSByte.Item2, DataTest.EnumSByte.Item1, DataTest.EnumSByte.Item0, DataTest.EnumSByte.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumSByte[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_EnumInt16()
        {
            List<DataTest.EnumInt16> item = new List<DataTest.EnumInt16> { DataTest.EnumInt16.Item1, DataTest.EnumInt16.Item2, DataTest.EnumInt16.Item0, DataTest.EnumInt16.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<DataTest.EnumInt16>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumInt16()
        {
            DataTest.EnumInt16[] item = [DataTest.EnumInt16.Item2, DataTest.EnumInt16.Item1, DataTest.EnumInt16.Item0, DataTest.EnumInt16.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumInt16[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_EnumInt32()
        {
            List<DataTest.EnumInt32> item = new List<DataTest.EnumInt32> { DataTest.EnumInt32.Item1, DataTest.EnumInt32.Item2, DataTest.EnumInt32.Item0, DataTest.EnumInt32.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<DataTest.EnumInt32>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumInt32()
        {
            DataTest.EnumInt32[] item = [DataTest.EnumInt32.Item2, DataTest.EnumInt32.Item1, DataTest.EnumInt32.Item0, DataTest.EnumInt32.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumInt32[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_EnumInt64()
        {
            List<DataTest.EnumInt64> item = new List<DataTest.EnumInt64> { DataTest.EnumInt64.Item1, DataTest.EnumInt64.Item2, DataTest.EnumInt64.Item0, DataTest.EnumInt64.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<DataTest.EnumInt64>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumInt64()
        {
            DataTest.EnumInt64[] item = [DataTest.EnumInt64.Item2, DataTest.EnumInt64.Item1, DataTest.EnumInt64.Item0, DataTest.EnumInt64.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumInt64[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_EnumUInt16()
        {
            List<DataTest.EnumUInt16> item = new List<DataTest.EnumUInt16> { DataTest.EnumUInt16.Item1, DataTest.EnumUInt16.Item2, DataTest.EnumUInt16.Item0, DataTest.EnumUInt16.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<DataTest.EnumUInt16>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumUInt16()
        {
            DataTest.EnumUInt16[] item = [DataTest.EnumUInt16.Item2, DataTest.EnumUInt16.Item1, DataTest.EnumUInt16.Item0, DataTest.EnumUInt16.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumUInt16[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_EnumUInt32()
        {
            List<DataTest.EnumUInt32> item = new List<DataTest.EnumUInt32> { DataTest.EnumUInt32.Item1, DataTest.EnumUInt32.Item2, DataTest.EnumUInt32.Item0, DataTest.EnumUInt32.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<DataTest.EnumUInt32>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumUInt32()
        {
            DataTest.EnumUInt32[] item = [DataTest.EnumUInt32.Item2, DataTest.EnumUInt32.Item1, DataTest.EnumUInt32.Item0, DataTest.EnumUInt32.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumUInt32[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_EnumUInt64()
        {
            List<DataTest.EnumUInt64> item = new List<DataTest.EnumUInt64> { DataTest.EnumUInt64.Item1, DataTest.EnumUInt64.Item2, DataTest.EnumUInt64.Item0, DataTest.EnumUInt64.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<DataTest.EnumUInt64>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumUInt64()
        {
            DataTest.EnumUInt64[] item = [DataTest.EnumUInt64.Item2, DataTest.EnumUInt64.Item1, DataTest.EnumUInt64.Item0, DataTest.EnumUInt64.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.EnumUInt64[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }
    }
}