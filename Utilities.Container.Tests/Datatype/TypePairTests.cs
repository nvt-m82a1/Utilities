using Utilities.Container.Converter;
using static Utilities.Container.Tests.__models.DataTest;

namespace Utilities.Container.Datatype.Tests
{
    [TestClass()]
    public class TypePairTests
    {
        [TestMethod()]
        public void ReadWriteTests_empty()
        {
            var item = new Dictionary<string, string>();
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<Dictionary<string, string>>(bytes);

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Count, data.Count);
        }

        [TestMethod()]
        public void ReadWriteTests_null()
        {
            Dictionary<string, string>? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<Dictionary<string, string>?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests()
        {
            var item = new Dictionary<string, string>
            {
                {"8234456wer4t", "0su3eisdf" },
                {"342w1eew54e3", "5sd6f45" },
            };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<Dictionary<string, string>>(bytes);

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Count, data.Count);
        }

        [TestMethod()]
        public void ReadWriteTests_string_data()
        {
            var item = new Dictionary<string, Item1>
            {
                { "key1", new Item1 { Id = 1 } },
                { "key2", new Item1 { Id = 2 } },
                { "key3", new Item1 { Id = 3 } },
            };

            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<Dictionary<string, Item1>>(bytes);

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Count, data.Count);
            Assert.AreEqual(1, data["key1"].Id);
            Assert.AreEqual(2, data["key2"].Id);
            Assert.AreEqual(3, data["key3"].Id);
        }

        [TestMethod()]
        public void ReadWriteTests_data_data()
        {
            var keyItem11 = new Item1 { Id = 1 };
            var keyItem12 = new Item1 { Id = 2 };
            var keyItem13 = new Item1 { Id = 3 };
            var valueItem21 = new Item2 { Id = 4, Name = "4" };
            var valueItem22 = new Item2 { Id = 5, Name = "5" };
            var valueItem23 = new Item2 { Id = 6, Name = "6" };

            var item = new Dictionary<Item1, Item2>
            {
                { keyItem11, valueItem21 },
                { keyItem12, valueItem22 },
                { keyItem13, valueItem23 }
            };

            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<Dictionary<Item1, Item2>>(bytes);

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Count, data.Count);

            var keyItor = data.Keys.GetEnumerator();
            var valueItor = data.Values.GetEnumerator();

            var id1 = 1;
            var id2 = 4;
            for (var i=0; i<item.Count; i++)
            {
                keyItor.MoveNext();
                valueItor.MoveNext();

                Assert.AreEqual(id1, keyItor.Current.Id);
                Assert.AreEqual(id2, valueItor.Current.Id);
                Assert.AreEqual(id2.ToString(), valueItor.Current.Name);
                id1++;
                id2++;
            }
        }
    }
}