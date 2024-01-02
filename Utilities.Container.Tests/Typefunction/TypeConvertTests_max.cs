using System.Text;
using Utilities.Container.Datatype;

namespace Utilities.Container.Converter.Tests
{
    [TestClass()]
    public class TypeConvertTests_max
    {
        [TestMethod()]
        public void ItemToBytesTest_Boolean_false()
        {
            CType ctype = TypesRead.CreateCType(typeof(Boolean));

            Boolean data = true;
            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);

            var expected = new byte[] { 1 };

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Byte()
        {
            CType ctype = TypesRead.CreateCType(typeof(Byte));
            Byte data = Byte.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = new byte[] { Byte.MaxValue };

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_SByte()
        {
            CType ctype = TypesRead.CreateCType(typeof(SByte));
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
            CType ctype = TypesRead.CreateCType(typeof(Char));
            Char data = Char.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Int16()
        {
            CType ctype = TypesRead.CreateCType(typeof(Int16));
            Int16 data = Int16.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_UInt16()
        {
            CType ctype = TypesRead.CreateCType(typeof(UInt16));
            UInt16 data = UInt16.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Int32()
        {
            CType ctype = TypesRead.CreateCType(typeof(Int32));
            Int32 data = Int32.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_UInt32()
        {
            CType ctype = TypesRead.CreateCType(typeof(UInt32));
            UInt32 data = UInt32.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Single()
        {
            CType ctype = TypesRead.CreateCType(typeof(Single));
            Single data = Single.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Double()
        {
            CType ctype = TypesRead.CreateCType(typeof(Double));
            Double data = Double.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Int64()
        {
            CType ctype = TypesRead.CreateCType(typeof(Int64));
            Int64 data = Int64.MaxValue;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            var expected = BitConverter.GetBytes(data);

            Assert.IsTrue(bytes != null);
            Assert.IsTrue(expected.SequenceEqual(bytes));
        }

        [TestMethod()]
        public void ItemToBytesTest_Decimal()
        {
            CType ctype = TypesRead.CreateCType(typeof(Decimal));
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
            CType ctype = TypesRead.CreateCType(typeof(String));
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
            CType ctype = TypesRead.CreateCType(typeof(DateTime));
            DateTime data = DateTime.MaxValue;

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