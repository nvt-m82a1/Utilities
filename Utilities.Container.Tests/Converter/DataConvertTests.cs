using Utilities.Container.Tests.__models;

namespace Utilities.Container.Converter.Tests
{
    [TestClass()]
    public class DataConvertTests
    {
        [TestMethod()]
        public void AddClassTest()
        {
            var item2 = new DataTest.Item2();
            item2.Id = 84548;
            item2.Name = "Test2";

            var bytes = DataConvert.Instance.GetBytes(item2);
            Assert.IsNotNull(bytes);

            var item22 = DataConvert.Instance.GetItem<DataTest.Item2>(bytes);

            Assert.IsTrue(item22 is not null);
            Assert.AreEqual(item2.Id, item22.Id);
            Assert.AreEqual(item2.Name, item22.Name);
        }

        [TestMethod()]
        public void AddArrayTest_int()
        {
            int[] item = [468465, 68456, 87864, 5487, 487545, 757845, 784575, 56548];

            var bytes = DataConvert.Instance.GetBytes(item);
            Assert.IsNotNull(bytes);

            var item2 = DataConvert.Instance.GetItem<int[]>(bytes);

            Assert.IsNotNull(item2);
            Assert.IsTrue(item.SequenceEqual(item2));
        }

        [TestMethod()]
        public void AddArrayTest_string()
        {
            string[] item = ["a5sd46f5w5e", "45we2r154sdf", "58xcv7845we", "5wer21s5d4f"];

            var bytes = DataConvert.Instance.GetBytes(item);
            Assert.IsNotNull(bytes);

            var data = DataConvert.Instance.GetItem<string[]>(bytes);

            Assert.IsTrue(data is not null);
            Assert.AreEqual(item.Length, data.Length);
            Assert.IsTrue(item.SequenceEqual(data));
        }

        [TestMethod()]
        public void AddArrayTest_class()
        {
            DataTest.Item2[] items = [
                new DataTest.Item2 { Id = 1, Name = "Item2_1" },
                new DataTest.Item2 { Id = 2, Name = "Item2_2" },
                new DataTest.Item2 { Id = 3, Name = "Item2_3" }
                ];

            var bytes = DataConvert.Instance.GetBytes(items);
            Assert.IsNotNull(bytes);

            var data = DataConvert.Instance.GetItem<DataTest.Item2[]>(bytes);

            Assert.IsTrue(data is not null);
            Assert.AreEqual(items.Length, data.Count());
            var index = 0;
            foreach (var item in data)
            {
                Assert.AreEqual(items[index].Id, item.Id);
                Assert.AreEqual(items[index].Name, item.Name);
                index++;
            }
        }
    }
}