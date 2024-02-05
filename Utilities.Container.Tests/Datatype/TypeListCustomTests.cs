using Utilities.Container.Converter;
using static Utilities.Container.Tests.__models.DataTest;

namespace Utilities.Container.Datatype.Tests
{
    [TestClass()]
    public class TypeListCustomTests
    {
        [TestMethod()]
        public void ReadWriteTests_empty()
        {
            var data = new List<Item1>();
            var bytes = DataConvert.Instance.GetBytes(data);
            var item = DataConvert.Instance.GetItem<List<Item1>>(bytes);

            Assert.IsNotNull(item);
            Assert.AreEqual(data.Count, item.Count);
        }

        [TestMethod()]
        public void ReadWriteTests_null()
        {
            List<Item1>? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<Item1>?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_list_item()
        {
            List<Item1> data = new List<Item1> {
                new Item1 { Id = 1 },
                new Item1 { Id = 2 },
                new Item1 { Id = 3 },
            };

            var bytes = DataConvert.Instance.GetBytes(data);
            var item = DataConvert.Instance.GetItem<List<Item1>>(bytes);

            Assert.IsNotNull(item);
            Assert.AreEqual(data.Count, item.Count);
            for (var i = 0; i < item.Count; i++)
            {
                Assert.AreEqual(data[i].Id, item[i].Id);
            }
        }

        [TestMethod()]
        public void ReadWriteTests_array_item()
        {
            Item1[] data = [
                new Item1 { Id = 1 },
                new Item1 { Id = 2 },
                new Item1 { Id = 3 }
            ];

            var bytes = DataConvert.Instance.GetBytes(data);
            var item = DataConvert.Instance.GetItem<Item1[]>(bytes);

            Assert.IsNotNull(item);
            Assert.AreEqual(data.Length, item.Length);
            for (var i = 0; i < item.Length; i++)
            {
                Assert.AreEqual(item[i].Id, data[i].Id);
            }
        }
    }
}