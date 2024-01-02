using System.Collections;
using Utilities.Container.Datatype;
using Utilities.Container.Tests.__models;

namespace Utilities.Container.Converter.Tests
{
    [TestClass()]
    public class TypeBindingTests
    {
        [TestMethod()]
        public void ParseArrayTest()
        {
            var data = new List<int> { 832445, 53458, 6384557, 89587345, 834554, 6348345 };
            var itemType = TypesRead.CreateCType(typeof(int));
            var bytes = data.SelectMany(item => TypeConvert.Instance.ItemToBytes(itemType, item)!);

            CType ctype = TypesRead.CreateCType(typeof(List<int>));
            TypeBinding.Instance.ParseArray(ctype.Others![0], data.Count, bytes.ToArray(), 0, arr =>
            {
                Assert.IsTrue(arr is IEnumerable);
                var index = 0;
                foreach (var item in (IEnumerable)arr)
                {
                    Assert.IsTrue(item is int);
                    Assert.IsTrue(data[index] == (int)item);
                    index++;
                }
            });
        }

        [TestMethod()]
        public void ParseItemTest()
        {
            var data = new List<int> { 89587345 };
            var itemType = TypesRead.CreateCType(typeof(int));
            var bytes = data.SelectMany(item => TypeConvert.Instance.ItemToBytes(itemType, item)!);

            CType ctype = TypesRead.CreateCType(typeof(List<int>));
            TypeBinding.Instance.ParseItem(ctype.Others![0], bytes.ToArray(), 0, item =>
            {
                Assert.IsTrue(item is int);
                Assert.IsTrue(data[0] == (int)item);
            });
        }

        [TestMethod()]
        public void BindingItemTest()
        {
            var item = new DataTest.Item1() { Id = 123 };
            var ctype = TypesPool.Scan(item).ToArray();

            var propIdType = ctype[0];
            var propIdBytes = TypeConvert.Instance.ItemToBytes(propIdType, item.Id);

            var reveredItem = new DataTest.Item1();
            TypeBinding.Instance.BindingItem(reveredItem, propIdType, propIdType, propIdBytes, 0);

            Assert.IsTrue(reveredItem is not null);
            Assert.IsTrue(reveredItem is DataTest.Item1);
            Assert.IsTrue(reveredItem.Id == item.Id);
        }

        [TestMethod()]
        public void BindingPairTest()
        {
            var item = new DataTest.Dictionary2()
            {
                Pair = new Dictionary<string, string>()
                {
                    { "123", "456" },
                    { "abc", "789" },
                }
            };
            var ctype = TypesPool.Scan(item).ToArray();

            var pairType = ctype[0];
            var pairLength = item.Pair.Count;

            var keyType = pairType.Others![0];
            var keyItems = item.Pair.Keys;
            var keyBytes = keyItems.SelectMany(item => TypeConvert.Instance.ItemToBytes(keyType, item)!).ToArray();

            var valueType = pairType.Others![1];
            var valueItems = item.Pair.Values;
            var valueBytes = valueItems.SelectMany(item => TypeConvert.Instance.ItemToBytes(valueType, item)!).ToArray();

            var reveredItem = new DataTest.Dictionary2();
            TypeBinding.Instance.BindingPair(reveredItem, pairType, pairLength, keyBytes, valueBytes);
            
            Assert.IsTrue(item.Pair.Count == reveredItem.Pair.Count);
            foreach (var kvp in item.Pair)
            {
                Assert.IsTrue(reveredItem.Pair.ContainsKey(kvp.Key));
                Assert.IsTrue(reveredItem.Pair[kvp.Key] == kvp.Value);
            }
        }
    }
}