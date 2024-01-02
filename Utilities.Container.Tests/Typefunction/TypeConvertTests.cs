using System.Text;
using Utilities.Container.Datatype;

namespace Utilities.Container.Converter.Tests
{
    [TestClass()]
    public class TypeConvertTests
    {
        [TestMethod()]
        public void ItemToBytesTest_Boolean_true()
        {
            CType ctype = TypesRead.CreateCType(typeof(Boolean));
            Boolean data = true;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = new byte[] { 1 };

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Boolean_false()
        {
            CType ctype = TypesRead.CreateCType(typeof(Boolean));

            Boolean data = false;
            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);

            var expected = new byte[] { 0 };

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Byte()
        {
            CType ctype = TypesRead.CreateCType(typeof(Byte));
            Byte data = 123;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = new byte[] { 123 };

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_SByte()
        {
            CType ctype = TypesRead.CreateCType(typeof(SByte));
            SByte data = -123;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var data2 = unchecked((byte)((sbyte)-123));
            var expected = new byte[] { data2 };

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Char()
        {
            CType ctype = TypesRead.CreateCType(typeof(Char));
            Char data = '\u1234';

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Int16()
        {
            CType ctype = TypesRead.CreateCType(typeof(Int16));
            Int16 data = -32100;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_UInt16()
        {
            CType ctype = TypesRead.CreateCType(typeof(UInt16));
            UInt16 data = 54321;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Int32()
        {
            CType ctype = TypesRead.CreateCType(typeof(Int32));
            Int32 data = 987654321;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_UInt32()
        {
            CType ctype = TypesRead.CreateCType(typeof(UInt32));
            UInt32 data = 123456789;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Single()
        {
            CType ctype = TypesRead.CreateCType(typeof(Single));
            Single data = 12345.6789f;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Double()
        {
            CType ctype = TypesRead.CreateCType(typeof(Double));
            Double data = 987654.3210d;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Int64()
        {
            CType ctype = TypesRead.CreateCType(typeof(Int64));
            Int64 data = 987654321123456789;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Decimal()
        {
            CType ctype = TypesRead.CreateCType(typeof(Decimal));
            Decimal data = 123456789.987654321m;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var ints = decimal.GetBits(data);
            var expected = ints.SelectMany(BitConverter.GetBytes);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_String()
        {
            CType ctype = TypesRead.CreateCType(typeof(String));
            String data = "5we3f4s5df65s2ew5cxv";

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var len = data.Length;
            var expected = BitConverter.GetBytes(len).Concat(Encoding.UTF8.GetBytes(data));

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_DateTime()
        {
            CType ctype = TypesRead.CreateCType(typeof(DateTime));
            DateTime data = DateTime.Now;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data.ToBinary());

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Guid()
        {
            CType ctype = TypesRead.CreateCType(typeof(Guid));
            Guid data = Guid.NewGuid();

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = data.ToByteArray();

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

    }
}