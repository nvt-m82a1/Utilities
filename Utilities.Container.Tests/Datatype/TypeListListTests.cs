using Utilities.Container.Converter;
using static Utilities.Container.Tests.__models.DataTest;

namespace Utilities.Container.Datatype.Tests
{
    [TestClass()]
    public class TypeListListTests
    {
        [TestMethod()]
        public void ReadWriteTests_empty()
        {
            var data = new List<List<Item1>>();
            var bytes = DataConvert.Instance.GetBytes(data);
            var item = DataConvert.Instance.GetItem<List<List<Item1>>>(bytes);

            Assert.IsNotNull(item);
            Assert.AreEqual(data.Count, item.Count);
        }

        [TestMethod()]
        public void ReadWriteTests_null()
        {
            List<List<Item1>>? item = null;
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<List<List<Item1>>?>(bytes);

            Assert.AreEqual(item, data);
        }

        [TestMethod()]
        public void ReadWriteTests_list_list_item()
        {
            List<List<Item1>> data = [
                [new Item1 { Id = 1 }],
                [
                    new Item1 { Id = 2 },
                    new Item1 { Id = 3 }
                ]
            ];

            var bytes = DataConvert.Instance.GetBytes(data);
            var item = DataConvert.Instance.GetItem<List<List<Item1>>>(bytes);

            Assert.IsNotNull(item);
            Assert.AreEqual(data.Count, item.Count);
            for (var i = 0; i < item.Count; i++)
            {
                Assert.AreEqual(data[i].Count, item[i].Count);
                for (var j=0; j < item[i].Count; j++)
                {
                    Assert.AreEqual(data[i][j].Id, item[i][j].Id);
                }
            }
        }

        [TestMethod()]
        public void ReadWriteTests_array_array_item()
        {
            Item1[][] data = [
                [new Item1 { Id = 1 }],
                [
                    new Item1 { Id = 2 },
                    new Item1 { Id = 3 }
                ]
            ];

            var bytes = DataConvert.Instance.GetBytes(data);
            var item = DataConvert.Instance.GetItem<Item1[][]>(bytes);

            Assert.IsNotNull(item);
            Assert.AreEqual(data.Length, item.Length);
            for (var i = 0; i < item.Length; i++)
            {
                Assert.AreEqual(data[i].Length, item[i].Length);
                for (var j = 0; j < item[i].Length; j++)
                {
                    Assert.AreEqual(data[i][j].Id, item[i][j].Id);
                }
            }
        }
    }
}