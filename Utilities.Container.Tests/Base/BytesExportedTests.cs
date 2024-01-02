using Utilities.Container.Buildin;
using Utilities.Container.Tests.__models;

namespace Utilities.Container.Base.Tests
{
    [TestClass()]
    public class BytesExportedTests
    {
        [TestMethod()]
        public void BytesExported_empty()
        {
            var writer = new TypeWriter();
            var bytes = writer.Container.Export().ToArray();

            Assert.IsTrue(bytes.Length >= 4);
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
                Dictionary2 = new DataTest.Dictionary2
                {
                    Pair = new Dictionary<string, string>
                    {
                        { "alsdifskadf", "oaidsfsdkf" },
                        { "klwejkr", "sdpfjkl" }
                    }
                }
            };

            var writer = new TypeWriter();
            writer.AddClass(item);

            var bytes = writer.Container.Export().ToArray();
            Assert.IsTrue(bytes.Length > 4);
            var len = BitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(len, bytes.Length);

            var reader = new TypeReader(bytes);
            var bytes2 = reader.Container.Export().ToArray();
            Assert.AreEqual(bytes.Length, bytes2.Length);
            Assert.IsTrue(bytes.SequenceEqual(bytes2));

            var item2 = new DataTest.ItemComplex();
            reader.FillInstance(item2);

            Assert.AreEqual(item.Id, item2.Id);
            Assert.AreEqual(item.Item1.Id, item2.Item1.Id);
            Assert.AreEqual(item.Item2.Id, item2.Item2.Id);
            Assert.AreEqual(item.Item2.Name, item2.Item2.Name);
            Assert.AreEqual(item.Item3.Id, item2.Item3.Id);
            Assert.AreEqual(item.Item3.Name, item2.Item3.Name);
            Assert.AreEqual(item.Item3.Description, item2.Item3.Description);
            Assert.AreEqual(item.List1.Items.Count, item2.List1.Items.Count);
            Assert.IsTrue(item.List1.Items.SequenceEqual(item2.List1.Items));
            Assert.AreEqual(item.Dictionary2.Pair.Count, item2.Dictionary2.Pair.Count);
            foreach (var kvp in item.Dictionary2.Pair)
            {
                Assert.IsTrue(item2.Dictionary2.Pair.ContainsKey(kvp.Key));
                Assert.AreEqual(kvp.Value, item2.Dictionary2.Pair[kvp.Key]);
            }
        }
    }
}