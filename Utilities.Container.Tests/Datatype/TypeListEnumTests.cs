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
            var item = new List<BindingTest.EnumByte>();
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<BindingTest.EnumByte>>(bytes);

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Count, data.Count);
        }

        [TestMethod()]
        public void ReadWriteTests_null()
        {
            List<BindingTest.EnumByte>? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<BindingTest.EnumByte>?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_list_EnumByte()
        {
            List<BindingTest.EnumByte> item = new List<BindingTest.EnumByte> { BindingTest.EnumByte.Item1, BindingTest.EnumByte.Item2, BindingTest.EnumByte.Item0, BindingTest.EnumByte.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<BindingTest.EnumByte>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumByte()
        {
            BindingTest.EnumByte[] item = [BindingTest.EnumByte.Item2, BindingTest.EnumByte.Item1, BindingTest.EnumByte.Item0, BindingTest.EnumByte.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumByte[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }
        [TestMethod()]
        public void ReadWriteTests_list_EnumSByte()
        {
            List<BindingTest.EnumSByte> item = new List<BindingTest.EnumSByte> { BindingTest.EnumSByte.Item1, BindingTest.EnumSByte.Item2, BindingTest.EnumSByte.Item0, BindingTest.EnumSByte.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<BindingTest.EnumSByte>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumSByte()
        {
            BindingTest.EnumSByte[] item = [BindingTest.EnumSByte.Item2, BindingTest.EnumSByte.Item1, BindingTest.EnumSByte.Item0, BindingTest.EnumSByte.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumSByte[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_EnumInt16()
        {
            List<BindingTest.EnumInt16> item = new List<BindingTest.EnumInt16> { BindingTest.EnumInt16.Item1, BindingTest.EnumInt16.Item2, BindingTest.EnumInt16.Item0, BindingTest.EnumInt16.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<BindingTest.EnumInt16>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumInt16()
        {
            BindingTest.EnumInt16[] item = [BindingTest.EnumInt16.Item2, BindingTest.EnumInt16.Item1, BindingTest.EnumInt16.Item0, BindingTest.EnumInt16.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumInt16[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_EnumInt32()
        {
            List<BindingTest.EnumInt32> item = new List<BindingTest.EnumInt32> { BindingTest.EnumInt32.Item1, BindingTest.EnumInt32.Item2, BindingTest.EnumInt32.Item0, BindingTest.EnumInt32.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<BindingTest.EnumInt32>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumInt32()
        {
            BindingTest.EnumInt32[] item = [BindingTest.EnumInt32.Item2, BindingTest.EnumInt32.Item1, BindingTest.EnumInt32.Item0, BindingTest.EnumInt32.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumInt32[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_EnumInt64()
        {
            List<BindingTest.EnumInt64> item = new List<BindingTest.EnumInt64> { BindingTest.EnumInt64.Item1, BindingTest.EnumInt64.Item2, BindingTest.EnumInt64.Item0, BindingTest.EnumInt64.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<BindingTest.EnumInt64>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumInt64()
        {
            BindingTest.EnumInt64[] item = [BindingTest.EnumInt64.Item2, BindingTest.EnumInt64.Item1, BindingTest.EnumInt64.Item0, BindingTest.EnumInt64.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumInt64[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_EnumUInt16()
        {
            List<BindingTest.EnumUInt16> item = new List<BindingTest.EnumUInt16> { BindingTest.EnumUInt16.Item1, BindingTest.EnumUInt16.Item2, BindingTest.EnumUInt16.Item0, BindingTest.EnumUInt16.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<BindingTest.EnumUInt16>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumUInt16()
        {
            BindingTest.EnumUInt16[] item = [BindingTest.EnumUInt16.Item2, BindingTest.EnumUInt16.Item1, BindingTest.EnumUInt16.Item0, BindingTest.EnumUInt16.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumUInt16[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_EnumUInt32()
        {
            List<BindingTest.EnumUInt32> item = new List<BindingTest.EnumUInt32> { BindingTest.EnumUInt32.Item1, BindingTest.EnumUInt32.Item2, BindingTest.EnumUInt32.Item0, BindingTest.EnumUInt32.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<BindingTest.EnumUInt32>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumUInt32()
        {
            BindingTest.EnumUInt32[] item = [BindingTest.EnumUInt32.Item2, BindingTest.EnumUInt32.Item1, BindingTest.EnumUInt32.Item0, BindingTest.EnumUInt32.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumUInt32[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_EnumUInt64()
        {
            List<BindingTest.EnumUInt64> item = new List<BindingTest.EnumUInt64> { BindingTest.EnumUInt64.Item1, BindingTest.EnumUInt64.Item2, BindingTest.EnumUInt64.Item0, BindingTest.EnumUInt64.Item1 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<BindingTest.EnumUInt64>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_EnumUInt64()
        {
            BindingTest.EnumUInt64[] item = [BindingTest.EnumUInt64.Item2, BindingTest.EnumUInt64.Item1, BindingTest.EnumUInt64.Item0, BindingTest.EnumUInt64.Item1];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<BindingTest.EnumUInt64[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }
    }
}