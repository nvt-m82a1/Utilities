using Utilities.Container.Converter;

namespace Utilities.Container.Datatype.Tests
{
    [TestClass()]
    public class TypeBuildinTests
    {
        [TestMethod()]
        public void ReadWriteTests_byte_min()
        {
            var item = byte.MinValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<byte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_byte_max()
        {
            var item = byte.MaxValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<byte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_byte_null()
        {
            byte? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<byte?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_sbyte_min()
        {
            var item = sbyte.MinValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<sbyte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_sbyte_max()
        {
            var item = sbyte.MaxValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<sbyte>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_sbyte_null()
        {
            sbyte? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<sbyte?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_char_min()
        {
            var item = char.MinValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<char>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_char_max()
        {
            var item = char.MaxValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<char>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_char_null()
        {
            char? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<char?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_short_min()
        {
            var item = short.MinValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<short>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_short_max()
        {
            var item = short.MaxValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<short>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_short_null()
        {
            short? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<short?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_ushort_min()
        {
            var item = ushort.MinValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<ushort>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_ushort_max()
        {
            var item = ushort.MaxValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<ushort>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_ushort_null()
        {
            ushort? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<ushort?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_int_min()
        {
            var item = int.MinValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<int>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_int_max()
        {
            var item = int.MaxValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<int>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_int_null()
        {
            int? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<int?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_uint_min()
        {
            var item = uint.MinValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<uint>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_uint_max()
        {
            var item = uint.MaxValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<uint>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_uint_null()
        {
            uint? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<uint?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_float_min()
        {
            var item = float.MinValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<float>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_float_max()
        {
            var item = float.MaxValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<float>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_float_null()
        {
            float? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<float?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_double_min()
        {
            var item = double.MinValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<double>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_double_max()
        {
            var item = double.MaxValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<double>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_double_null()
        {
            double? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<double?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_long_min()
        {
            var item = long.MinValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<long>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_long_max()
        {
            var item = long.MaxValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<long>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_long_null()
        {
            long? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<long?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_ulong_min()
        {
            var item = ulong.MinValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<ulong>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_ulong_max()
        {
            var item = ulong.MaxValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<ulong>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_ulong_null()
        {
            ulong? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<ulong?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_decimal_min()
        {
            var item = decimal.MinValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<decimal>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_decimal_max()
        {
            var item = decimal.MaxValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<decimal>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_decimal_null()
        {
            decimal? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<decimal?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_string_min()
        {
            var item = string.Empty;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<string>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_string_max()
        {
            var item = string.Join("", Enumerable.Repeat("6465w2e1", 1000));
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<string>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_string_null()
        {
            string? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<string?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_DateTime_min()
        {
            var item = DateTime.MinValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DateTime>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_DateTime_max()
        {
            var item = DateTime.MaxValue;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DateTime>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_DateTime_null()
        {
            DateTime? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DateTime?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_Guid_min()
        {
            var item = Guid.Empty;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<Guid>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_Guid_max()
        {
            var item = Guid.NewGuid();
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<Guid>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_Guid_null()
        {
            Guid? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<Guid?>(bytes);

            Assert.AreEqual(item, data);
        }
    }
}