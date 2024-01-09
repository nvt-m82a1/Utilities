namespace Utilities.Container.Base.Tests
{
    [TestClass()]
    public class ByteContainerTests
    {
        [TestMethod()]
        public void AddItemTest_byte()
        {
            byte item = 100;
            var container = new ByteContainer();
            container.AddItem(item);
            var data = container.ReadItem();

            Assert.IsTrue(data == item);
        }

        [TestMethod()]
        public void AddItemTest_bytes()
        {
            byte[] items = [50, 100, 125, 150, 200];
            var container = new ByteContainer();
            container.AddItems(items);

            var data = container.ReadItems(5).ToArray();

            Assert.IsTrue(data is not null);
            for (int i = 0; i < items.Length; i++)
            {
                Assert.IsTrue(data[i] == items[i]);
            }
        }

        [TestMethod()]
        public void AddItemTest_array()
        {
            var items = new byte[] { 120, 121, 122, 123, 124, 125, 126, 127, 128, 129 };
            var container = new ByteContainer();
            container.AddArray(items);

            var (len, bytes) = container.ReadArray();

            Assert.IsTrue(items.Count() == len);
            Assert.IsTrue(bytes is not null);

            var data = bytes!.ToArray();
            for (int i = 0; i < items.Count(); i++)
            {
                Assert.IsTrue(data[i] == items[i]);
            }
        }

        [TestMethod()]
        public void ReadItemTest_null()
        {
            var container = new ByteContainer();
            var data = container.ReadItem();
            Assert.IsNull(data);
        }

        [TestMethod()]
        public void ReadItemTest_items_0()
        {
            byte item = 4;
            var container = new ByteContainer();
            container.AddItem(item);

            var data = container.ReadItems(4);
            Assert.IsTrue(data[0] == item);
            Assert.IsTrue(data[1] == 0);
            Assert.IsTrue(data[2] == 0);
            Assert.IsTrue(data[3] == 0);
        }

        [TestMethod()]
        public void ImportExport()
        {
            var items1 = new byte[] { 110, 111, 112, 113, 114, 115,
                120, 121, 122, 123, 124, 125, 126, 127, 128, 129 };
            var items2 = new byte[] { 200, 201, 87, 54, 75, 86,
                206, 207, 25, 1, 16, 6, 43, 5, 24, 2, 52, 2, 45 };

            var container = new ByteContainer();
            container.AddArray(items1);
            container.AddArray(items2);

            var bytes = container.Export();

            var container2 = new ByteContainer();
            container2.Import(bytes.ToArray());
            var (len3, items3) = container2.ReadArray();
            var (len4, items4) = container2.ReadArray();

            var bytes2 = container2.Export();
            Assert.IsTrue(bytes.SequenceEqual(bytes2));
            Assert.IsTrue(container.Equals(container2));
            Assert.IsTrue(items3 is not null);
            Assert.IsTrue(items4 is not null);
            Assert.IsTrue(items1.Length == len3);
            Assert.IsTrue(items2.Length == len4);
            Assert.IsTrue(items1.SequenceEqual(items3.ToArray()));
            Assert.IsTrue(items2.SequenceEqual(items4.ToArray()));
        }

        [TestMethod()]
        public void ResetClearTests_item()
        {
            var container = new ByteContainer();
            container.AddItem(1);

            container.Clear();
            Assert.AreEqual(0, container.TotalElements);

            container.AddItem(2);
            container.AddItem(3);
            Assert.AreEqual(2, container.TotalElements);

            Assert.AreEqual((byte)2, container.ReadItem());
            Assert.AreEqual((byte)3, container.ReadItem());
            Assert.AreEqual(null, container.ReadItem());

            container.ReadReset();

            Assert.AreEqual((byte)2, container.ReadItem());
            Assert.AreEqual((byte)3, container.ReadItem());
            Assert.AreEqual(null, container.ReadItem());
        }

        [TestMethod()]
        public void ResetClearTests_items()
        {
            byte[] byte1 = [1, 2, 3];
            byte[] byte2 = [4, 5, 6];

            var container = new ByteContainer();
            container.AddItems(byte1);

            container.Clear();
            Assert.AreEqual(0, container.TotalElements);
            
            container.AddItems(byte2);
            Assert.AreEqual(3, container.TotalElements);

            byte[] bytes = container.ReadItems(4);
            Assert.AreEqual(byte2[0], bytes[0]);
            Assert.AreEqual(byte2[1], bytes[1]);
            Assert.AreEqual(byte2[2], bytes[2]);
            Assert.AreEqual(0, bytes[3]);

            container.ReadReset();

            byte[] bytes2 = container.ReadItems(4);
            Assert.AreEqual(byte2[0], bytes2[0]);
            Assert.AreEqual(byte2[1], bytes2[1]);
            Assert.AreEqual(byte2[2], bytes2[2]);
            Assert.AreEqual(0, bytes2[3]);

        }
    }
}