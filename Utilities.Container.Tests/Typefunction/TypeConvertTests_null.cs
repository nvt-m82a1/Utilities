using Utilities.Container.Datatype;

namespace Utilities.Container.Converter.Tests
{
    [TestClass()]
    public class TypeConvertTests_null
    {
        [TestMethod()]
        public void ItemToBytesTest_Boolean_true()
        {
            CType ctype = TypesRead.CreateCType(typeof(Boolean));
            Boolean? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);

            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Boolean_false()
        {
            CType ctype = TypesRead.CreateCType(typeof(Boolean));

            Boolean? data = null;
            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);

            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Byte()
        {
            CType ctype = TypesRead.CreateCType(typeof(Byte));
            Byte? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);

            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_SByte()
        {
            CType ctype = TypesRead.CreateCType(typeof(SByte));
            SByte? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);

            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Char()
        {
            CType ctype = TypesRead.CreateCType(typeof(Char));
            Char? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);

            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Int16()
        {
            CType ctype = TypesRead.CreateCType(typeof(Int16));
            Int16? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_UInt16()
        {
            CType ctype = TypesRead.CreateCType(typeof(UInt16));
            UInt16? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Int32()
        {
            CType ctype = TypesRead.CreateCType(typeof(Int32));
            Int32? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_UInt32()
        {
            CType ctype = TypesRead.CreateCType(typeof(UInt32));
            UInt32? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Single()
        {
            CType ctype = TypesRead.CreateCType(typeof(Single));
            Single? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Double()
        {
            CType ctype = TypesRead.CreateCType(typeof(Double));
            Double? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Int64()
        {
            CType ctype = TypesRead.CreateCType(typeof(Int64));
            Int64? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Decimal()
        {
            CType ctype = TypesRead.CreateCType(typeof(Decimal));
            Decimal? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_String()
        {
            CType ctype = TypesRead.CreateCType(typeof(String));
            String? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_DateTime()
        {
            CType ctype = TypesRead.CreateCType(typeof(DateTime));
            DateTime? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Guid()
        {
            CType ctype = TypesRead.CreateCType(typeof(Guid));
            Guid? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

    }
}