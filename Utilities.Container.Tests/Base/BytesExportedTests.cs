using Utilities.Container.Converter;
using Utilities.Container.Tests.__models;

namespace Utilities.Container.Base.Tests
{
    [TestClass()]
    public class BytesExportedTests
    {
        [TestMethod()]
        public void BytesExported_empty()
        {
            var bytes = DataConvert.Instance.GetBytes(Array.Empty<int>());
            
            Assert.IsNotNull(bytes);
            Assert.IsTrue(bytes.Length == 12);
            var len = BitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(len, bytes.Length);
        }

        [TestMethod()]

        public void BytesExported_complex()
        {
            var item = new DataTest.ItemComplex
            {
                Id = 45325,
                Item1 = new DataTest.Item1 { Id = 8623654 },
                Item2 = new DataTest.Item2 { Id = 6236565, Name = "5w4e5r" },
                Item3 = new DataTest.Item3 { Id = Guid.Empty, Name = "542354", Description = "dsjfuawej" },
                List1 = new DataTest.List1
                {
                    Items = [26349, 283478, 23871, 2387, 123],
                },
                List2 = new DataTest.List2
                {
                    Items = [6875, 5475, 54784, 6578, 5784],
                    Items2 = [6542, 457, 4875, 6564, 54841],
                },
                Dictionary2 = new DataTest.Dictionary2
                {
                    Pair = new Dictionary<string, string>
                    {
                        { "alsdifskadf", "oaidsfsdkf" },
                        { "klwejkr", "sdpfjkl" }
                    }
                }
            };

            var bytes = DataConvert.Instance.GetBytes(item);
            Assert.IsNotNull(bytes);
            Assert.IsTrue(bytes.Length > 4);

            var len = BitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(len, bytes.Length);

            var item2 = DataConvert.Instance.GetItem<DataTest.ItemComplex>(bytes);

            Assert.IsNotNull(item2);
            Assert.AreEqual(item.Id, item2.Id);
            Assert.AreEqual(item.Item1.Id, item2.Item1.Id);
            Assert.AreEqual(item.Item2.Id, item2.Item2.Id);
            Assert.AreEqual(item.Item2.Name, item2.Item2.Name);
            Assert.AreEqual(item.Item3.Id, item2.Item3.Id);
            Assert.AreEqual(item.Item3.Name, item2.Item3.Name);
            Assert.AreEqual(item.Item3.Description, item2.Item3.Description);
            Assert.AreEqual(item.List1.Items.Count, item2.List1.Items.Count);
            Assert.IsTrue(item.List1.Items.SequenceEqual(item2.List1.Items));
            Assert.AreEqual(item.List2.Items.Count, item2.List2.Items.Count);
            Assert.IsTrue(item.List2.Items.SequenceEqual(item2.List2.Items));
            Assert.AreEqual(item.List2.Items2.Length, item2.List2.Items2.Length);
            Assert.IsTrue(item.List2.Items2.SequenceEqual(item2.List2.Items2));
            Assert.AreEqual(item.Dictionary2.Pair.Count, item2.Dictionary2.Pair.Count);
            foreach (var kvp in item.Dictionary2.Pair)
            {
                Assert.IsTrue(item2.Dictionary2.Pair.ContainsKey(kvp.Key));
                Assert.AreEqual(kvp.Value, item2.Dictionary2.Pair[kvp.Key]);
            }
        }
    }
}