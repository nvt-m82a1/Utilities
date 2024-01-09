using Utilities.Container.BaseType;
using Utilities.Container.Option;

namespace Utilities.Container.Converter.Tests
{
    [TestClass()]
    public class TypeConvertTests_null
    {
        [TestMethod()]
        public void ItemToBytesTest_Boolean_true()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Boolean));
            Boolean? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);

            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Boolean_false()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Boolean));

            Boolean? data = null;
            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);

            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Byte()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Byte));
            Byte? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);

            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_SByte()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(SByte));
            SByte? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);

            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Char()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Char));
            Char? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);

            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Int16()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Int16));
            Int16? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_UInt16()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(UInt16));
            UInt16? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Int32()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Int32));
            Int32? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_UInt32()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(UInt32));
            UInt32? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Single()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Single));
            Single? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Double()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Double));
            Double? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Int64()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Int64));
            Int64? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Decimal()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Decimal));
            Decimal? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_String()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(String));
            String? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_DateTime()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(DateTime));
            DateTime? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

        [TestMethod()]
        public void ItemToBytesTest_Guid()
        {
            TypeInfo ctype = TypesPool.GetInfo(typeof(Guid));
            Guid? data = null;

            var bytes = TypeConvert.Instance.ItemToBytes(ctype, data);
            
            Assert.IsTrue(bytes == null);
        }

    }
}