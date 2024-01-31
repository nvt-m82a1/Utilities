using System.Text;
using Utilities.Container.Option;

namespace Utilities.Container.Converter.Tests
{
    [TestClass()]
    public class TypeConvertTests
    {
        [TestMethod()]
        public void ItemToBytesTest_Boolean_true()
        {
            var type = TypesPool.GetInfo(typeof(Boolean));
            Boolean data = true;

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var expected = new byte[] { 1 };

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Boolean_false()
        {
            var type = TypesPool.GetInfo(typeof(Boolean));

            Boolean data = false;
            var bytes = TypeConvert.Instance.ItemToBytes(type, data);

            var expected = new byte[] { 0 };

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Byte()
        {
            var type = TypesPool.GetInfo(typeof(Byte));
            Byte data = 123;

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var expected = new byte[] { 123 };

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_SByte()
        {
            var type = TypesPool.GetInfo(typeof(SByte));
            SByte data = -123;

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var data2 = unchecked((byte)((sbyte)-123));
            var expected = new byte[] { data2 };

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Char()
        {
            var type = TypesPool.GetInfo(typeof(Char));
            Char data = '\u1234';

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Int16()
        {
            var type = TypesPool.GetInfo(typeof(Int16));
            Int16 data = -32100;

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_UInt16()
        {
            var type = TypesPool.GetInfo(typeof(UInt16));
            UInt16 data = 54321;

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Int32()
        {
            var type = TypesPool.GetInfo(typeof(Int32));
            Int32 data = 987654321;

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_UInt32()
        {
            var type = TypesPool.GetInfo(typeof(UInt32));
            UInt32 data = 123456789;

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Single()
        {
            var type = TypesPool.GetInfo(typeof(Single));
            Single data = 12345.6789f;

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Double()
        {
            var type = TypesPool.GetInfo(typeof(Double));
            Double data = 987654.3210d;

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Int64()
        {
            var type = TypesPool.GetInfo(typeof(Int64));
            Int64 data = 987654321123456789;

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_UInt64()
        {
            var type = TypesPool.GetInfo(typeof(UInt64));
            UInt64 data = 987654786956356789;

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Decimal()
        {
            var type = TypesPool.GetInfo(typeof(Decimal));
            Decimal data = 123456789.987654321m;

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var ints = decimal.GetBits(data);
            var expected = ints.SelectMany(BitConverter.GetBytes);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_String()
        {
            var type = TypesPool.GetInfo(typeof(String));
            String data = "5we3f4s5df65s2ew5cxv";

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var len = data.Length;
            var expected = BitConverter.GetBytes(len).Concat(Encoding.UTF8.GetBytes(data));

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_DateTime()
        {
            var type = TypesPool.GetInfo(typeof(DateTime));
            DateTime data = DateTime.Now;

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var expected = BitConverter.GetBytes(data.ToBinary());

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Guid()
        {
            var type = TypesPool.GetInfo(typeof(Guid));
            Guid data = Guid.NewGuid();

            var bytes = TypeConvert.Instance.ItemToBytes(type, data);
            var expected = data.ToByteArray();

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

    }
}