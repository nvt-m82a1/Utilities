using System.Text;
using Utilities.Container.BaseType;
using Utilities.Container.Option;

namespace Utilities.Container.Converter.Tests
{
    [TestClass()]
    public class TypeConvertTests_max
    {
        [TestMethod()]
        public void ItemToBytesTest_Boolean_false()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Boolean));

            Boolean data = true;
            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);

            var expected = new byte[] { 1 };

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Byte()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Byte));
            Byte data = Byte.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = new byte[] { Byte.MaxValue };

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_SByte()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(SByte));
            SByte data = SByte.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var data2 = unchecked((byte)((sbyte)SByte.MaxValue));
            var expected = new byte[] { data2 };

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Char()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Char));
            Char data = Char.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Int16()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Int16));
            Int16 data = Int16.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_UInt16()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(UInt16));
            UInt16 data = UInt16.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Int32()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Int32));
            Int32 data = Int32.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_UInt32()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(UInt32));
            UInt32 data = UInt32.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Single()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Single));
            Single data = Single.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Double()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Double));
            Double data = Double.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Int64()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Int64));
            Int64 data = Int64.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_UInt64()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(UInt64));
            UInt64 data = UInt64.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Decimal()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Decimal));
            Decimal data = Decimal.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var ints = decimal.GetBits(data);
            var expected = ints.SelectMany(BitConverter.GetBytes);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_String()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(String));
            String data = string.Join(String.Empty, Enumerable.Repeat("wer45sdf", 1234));

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var len = data.Length;
            var expected = BitConverter.GetBytes(len).Concat(Encoding.UTF8.GetBytes(data));

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_DateTime()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(DateTime));
            DateTime data = DateTime.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data.ToBinary());

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Guid()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Guid));
            Guid data = Guid.NewGuid();

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = data.ToByteArray();

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

    }
}