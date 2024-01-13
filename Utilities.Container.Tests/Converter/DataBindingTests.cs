using Utilities.Container.Tests.__models;

namespace Utilities.Container.Converter.Tests
{
    [TestClass]
    public class DataBindingTests
    {
        [TestMethod]
        public void ReadBindingTests_field()
        {
            var item = new BindingTest.Item1Field { Id = 1 };
            var bytes = DataBinding.Instance.ReadMembers(item);

            item.Id = 2;

            DataBinding.Instance.WriteMembers(item, bytes);
            Assert.AreEqual(1, item.Id);
        }

        [TestMethod]
        public void ReadWriteTests_field_null()
        {
            var item = new BindingTest.Item1Field { Id = null };
            var bytes = DataBinding.Instance.ReadMembers(item);

            item.Id = 2;

            DataBinding.Instance.WriteMembers(item, bytes);
            Assert.AreEqual(null, item.Id);
        }

        [TestMethod]
        public void ReadWriteTests_prop()
        {
            var item = new BindingTest.Item1Prop { Id = 1 };
            var bytes = DataBinding.Instance.ReadMembers(item);

            item.Id = 2;

            DataBinding.Instance.WriteMembers(item, bytes);
            Assert.AreEqual(1, item.Id);
        }

        [TestMethod]
        public void ReadWriteTests_prop_null()
        {
            var item = new BindingTest.Item1Prop { Id = null };
            var bytes = DataBinding.Instance.ReadMembers(item);

            item.Id = 2;

            DataBinding.Instance.WriteMembers(item, bytes);
            Assert.AreEqual(null, item.Id);
        }

        [TestMethod()]
        public void ReadWriteTests_2()
        {
            var item = new BindingTest.Item2 { Name = "test2", Address = "Test method" };
            var bytes = DataBinding.Instance.ReadMembers(item);

            item.Name = "test 2 updated";
            item.Address = "Test method updated";

            DataBinding.Instance.WriteMembers(item, bytes);
            Assert.AreEqual("test2", item.Name);
            Assert.AreEqual("Test method", item.Address);
        }

        [TestMethod()]
        public void ReadWriteTests_2_null()
        {
            var item = new BindingTest.Item2 { Name = null, Address = null };
            var bytes = DataBinding.Instance.ReadMembers(item);

            item.Name = "test 2 updated";
            item.Address = "Test method updated";

            DataBinding.Instance.WriteMembers(item, bytes);
            Assert.AreEqual(null, item.Name);
            Assert.AreEqual(null, item.Address);
        }

        [TestMethod()]
        public void ReadWriteTests_buildin()
        {
            var date = DateTime.Now;
            var guid = Guid.NewGuid();
            var item = new BindingTest.Buildin1
            {
                Boolean = true,
                Byte = 56,
                SByte = -45,
                Char = '\u5484',
                Int16 = 20000,
                UInt16 = 40000,
                Int32 = -84354565,
                UInt32 = 846548745,
                Single = 1546542.15451f,
                Double = 5465132448421.165468424544d,
                Int64 = 5215454654543484546L,
                Decimal = 65465456846435485.156486465468465M,
                String = "a5s4df68we654f6a5sdf6asdf654",
                DateTime = date,
                Guid = guid,
            };
            var bytes = DataBinding.Instance.ReadMembers(item);

            item.Boolean = false;
            item.Byte = 67;
            item.SByte = -24;
            item.Char = '\u8547';
            item.Int16 = 15424;
            item.UInt16 = 30215;
            item.Int32 = -1514351;
            item.UInt32 = 624512452;
            item.Single = 542154.21541f;
            item.Double = 456153451245.21541654d;
            item.Int64 = 54126561245154L;
            item.Decimal = 56236532.1654215454M;
            item.String = "54sd5f65ew4f";
            item.DateTime = DateTime.Now;
            item.Guid = Guid.NewGuid();

            DataBinding.Instance.WriteMembers(item, bytes);
            Assert.AreEqual(true, item.Boolean);
            Assert.AreEqual((byte)56, item.Byte);
            Assert.AreEqual((sbyte)-45, item.SByte);
            Assert.AreEqual('\u5484', item.Char);
            Assert.AreEqual((Int16)20000, item.Int16);
            Assert.AreEqual((UInt16)40000, item.UInt16);
            Assert.AreEqual(-84354565, item.Int32);
            Assert.AreEqual((UInt32)846548745, item.UInt32);
            Assert.AreEqual(1546542.15451f, item.Single);
            Assert.AreEqual(5465132448421.165468424544d, item.Double);
            Assert.AreEqual(5215454654543484546L, item.Int64);
            Assert.AreEqual(65465456846435485.156486465468465M, item.Decimal);
            Assert.AreEqual("a5s4df68we654f6a5sdf6asdf654", item.String);
            Assert.AreEqual(date, item.DateTime);
            Assert.AreEqual(guid, item.Guid);
        }

        [TestMethod()]
        public void ReadWriteTests_buildin_null()
        {
            var item = new BindingTest.Buildin1();
            var bytes = DataBinding.Instance.ReadMembers(item);

            item.Boolean = false;
            item.Byte = 67;
            item.SByte = -24;
            item.Char = '\u8547';
            item.Int16 = 15424;
            item.UInt16 = 30215;
            item.Int32 = -1514351;
            item.UInt32 = 624512452;
            item.Single = 542154.21541f;
            item.Double = 456153451245.21541654d;
            item.Int64 = 54126561245154L;
            item.Decimal = 56236532.1654215454M;
            item.String = "54sd5f65ew4f";
            item.DateTime = DateTime.Now;
            item.Guid = Guid.NewGuid();

            DataBinding.Instance.WriteMembers(item, bytes);
            Assert.AreEqual(null, item.Boolean);
            Assert.AreEqual(null, item.Byte);
            Assert.AreEqual(null, item.SByte);
            Assert.AreEqual(null, item.Char);
            Assert.AreEqual(null, item.Int16);
            Assert.AreEqual(null, item.UInt16);
            Assert.AreEqual(null, item.Int32);
            Assert.AreEqual(null, item.UInt32);
            Assert.AreEqual(null, item.Single);
            Assert.AreEqual(null, item.Double);
            Assert.AreEqual(null, item.Int64);
            Assert.AreEqual(null, item.Decimal);
            Assert.AreEqual(null, item.String);
            Assert.AreEqual(null, item.DateTime);
            Assert.AreEqual(null, item.Guid);
        }
    }
}
