using Utilities.Container.Converter;

namespace Utilities.Container.Datatype.Tests
{
    [TestClass()]
    public class TypeListTests
    {
        [TestMethod()]
        public void ReadWriteTests_empty()
        {
            var item = new List<int>();
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<int>>(bytes);

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Count, data.Count);
        }

        [TestMethod()]
        public void ReadWriteTests_null()
        {
            List<int>? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<int>?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_list_byte()
        {
            List<byte> item = new List<byte> { 24, 12, 54, 57, 124, 250 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<byte>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_byte()
        {
            byte[] item = [25, 36, 25, 14, 25, 16, 84, 250, 245, 142, 62];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<byte[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_sbyte()
        {
            List<sbyte> item = new List<sbyte> { -120, -52, 62, 35, 26, 125, -65, 68 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<sbyte>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_sbyte()
        {
            sbyte[] item = [70, 42, 51, -122, 123, 52, 63, 48, 75, 26];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<sbyte[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_char()
        {
            List<char> item = new List<char> { '\u1235', '\u2445', '\u6532', '\u8457', '\u6332' };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<char>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_char()
        {
            char[] item = ['\u5421', '\u2467', '\u8454', '\u9421', '\u4574', '\u3244', '\u3146'];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<char[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_short()
        {
            List<short> item = new List<short> { 12452, 30521, -15412, -25418, 15425, 1542 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<short>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_short()
        {
            short[] item = [1542, 1653, 25487, 5412, 6532, 1245, 1124, 514];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<short[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_ushort()
        {
            List<ushort> item = new List<ushort> { 50662, 145, 52451, 62154, 875, 48579, 8457 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<ushort>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_ushort()
        {
            ushort[] item = [3262, 3254, 1254, 6568, 4515, 1254, 6658];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<ushort[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_int()
        {
            List<int> item = new List<int> { 8654, 6578, 56784, 5486, 496875, 498754 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<int>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_int()
        {
            int[] item = [7845, 48754, 8754, 4864, 65468, 65487, 54687];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<int[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_uint()
        {
            List<uint> item = new List<uint> { 984654854, 8754985, 689458784, 5135487, 1657684524 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<uint>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_uint()
        {
            uint[] item = [98684784, 6548754, 687542, 3151234, 651345, 156452];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<uint[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_float()
        {
            List<float> item = new List<float> { 123.456f, 561357865468465f, 6513215.456124565f, 23154215.12451f };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<float>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_float()
        {
            float[] item = [58648.46545f, 545123.321541f, 535465685468534f, 54652.2154564f, 5466898456.26545f];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<float[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_double()
        {
            List<double> item = new List<double> { 2665456.456545d, 654683245653546846546d, 4682316546876548465452d, 6546876546845.46581235468d };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<double>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_double()
        {
            double[] item = [587564845.121165465d, 468468864654876546845d, 4568754685321.54657846d, 546875468454684354684d];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<double[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_long()
        {
            List<long> item = new List<long> { 3544652348235446235L, 4468243654426384623L, 6523446523445L, 5624346253446253L };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<long>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_long()
        {
            long[] item = [2365446523445L, 9823465426354L, 2563446238445623446L, 62534465234L];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<long[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_decimal()
        {
            List<decimal> item = new List<decimal> { 56562354453M, 5645234.4625374M, 56234465423654.46253448623445623M, 5624346542.44625344826534652344652M };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<decimal>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_decimal()
        {
            decimal[] item = [65234465623545523454M, 45654235262.4625344652346452344M, 652344652344236.4625344652344M, 4625436284452346.54483232413254425335M];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<decimal[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_string()
        {
            List<string> item = new List<string> { "asdjhweorj", "kliwer03924", "290332h0s9df", "uihg294u32jh0df", "0f932l40s9adfhjasd" };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<string>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_string()
        {
            string[] item = ["923jjkjsa0difjj", "kj asdfj oiasdj dkf", " ##($)*(&(* (*&DFSD(* ", "KSDFJSDOFU)(9*fd)(*sd(*f&8"];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<string[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_DateTime()
        {
            List<DateTime> item = new List<DateTime> { new DateTime(5642445L), new DateTime(652563L), new DateTime(4652342122L) };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<DateTime>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_DateTime()
        {
            DateTime[] item = [new DateTime(45263455L), new DateTime(562344523L), new DateTime(23654642L)];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DateTime[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_list_Guid()
        {
            List<Guid> item = new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<Guid>>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void ReadWriteTests_array_Guid()
        {
            Guid[] item = [Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()];
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<Guid[]>(bytes);

            Assert.IsNotNull(data);
            Assert.IsTrue(item.SequenceEqual(data));
        }

    }
}