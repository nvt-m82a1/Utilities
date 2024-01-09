using Utilities.Container.Converter;
using Utilities.Container.Tests.__models;

namespace Utilities.Container.Datatype.Tests
{
    [TestClass()]
    public class TypeCustomTests
    {
        [TestMethod()]
        public void ReadWriteTests()
        {
            var item = new DataTest.Item1 { Id = 686865865 };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.Item1>(bytes);

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Id, data.Id);
        }

        [TestMethod()]
        public void ReadWriteTests_complex()
        {
            var item = new DataTest.ItemComplex
            {
                Id = 435345345,
                Item1 = new DataTest.Item1 { Id = 234567684 },
                Item2 = new DataTest.Item2 { Id = 523454, Name = "234uwiusdf93" },
                Item3 = new DataTest.Item3 { Id = null, Name = null, Description = null },
                List1 = new DataTest.List1 { Items = new List<int> { 6658745, 78794, 57894, 578456 } },
                List2 = new DataTest.List2
                {
                    Items = new List<int> { 6548, 54845, 784578, 68457, 648757 },
                    Items2 = [96867, 5784, 54875, 48754, 48754]
                },
                Dictionary2 = new DataTest.Dictionary2
                {
                    Pair = new Dictionary<string, string>
                    {
                        { "asdfasdkf", "aksdfiiwer" },
                        { "5asd1f1", "9xcv46" },
                        { "6we5r4", "86wer5" },
                    }
                }
            };
            var bytes = DataConvert.Instance.GetBytes(item);
            var data = DataConvert.Instance.GetItem<DataTest.ItemComplex>(bytes);

            Assert.IsNotNull(data);
            Assert.AreEqual(item.Id, data.Id);
            Assert.AreEqual(item.Item1.Id, data.Item1.Id);
            Assert.AreEqual(item.Item2.Id, data.Item2.Id);
            Assert.AreEqual(item.Item2.Name, data.Item2.Name);
            Assert.AreEqual(item.Item3.Id, data.Item3.Id);
            Assert.AreEqual(item.Item3.Name, data.Item3.Name);
            Assert.AreEqual(item.Item3.Description, data.Item3.Description);
            Assert.IsTrue(item.List1.Items.SequenceEqual(data.List1.Items));
            Assert.IsTrue(item.List2.Items.SequenceEqual(data.List2.Items));
            Assert.IsTrue(item.List2.Items2.SequenceEqual(data.List2.Items2));

            Assert.AreEqual(item.Dictionary2.Pair.Count, data.Dictionary2.Pair.Count);
            var itemIter = item.Dictionary2.Pair.Keys.GetEnumerator();
            var dataIter = data.Dictionary2.Pair.Keys.GetEnumerator();

            while (itemIter.MoveNext())
            {
                dataIter.MoveNext();

                Assert.AreEqual(itemIter.Current, dataIter.Current);
                Assert.AreEqual(item.Dictionary2.Pair[itemIter.Current], data.Dictionary2.Pair[dataIter.Current]);
            }
        }
    }
}