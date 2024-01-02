using System.Collections.Concurrent;

namespace Utilities.Container.Datatype.Tests
{
    [TestClass()]
    public class TypesTests
    {
        [TestMethod()]
        public void Type_FullName()
        {
            Assert.AreEqual(Types.FullName.Boolean, typeof(Boolean).FullName);
            Assert.AreEqual(Types.FullName.Byte, typeof(Byte).FullName);
            Assert.AreEqual(Types.FullName.SByte, typeof(SByte).FullName);
            Assert.AreEqual(Types.FullName.Char, typeof(Char).FullName);
            Assert.AreEqual(Types.FullName.Int16, typeof(Int16).FullName);
            Assert.AreEqual(Types.FullName.UInt16, typeof(UInt16).FullName);
            Assert.AreEqual(Types.FullName.Int32, typeof(Int32).FullName);
            Assert.AreEqual(Types.FullName.UInt32, typeof(UInt32).FullName);
            Assert.AreEqual(Types.FullName.Single, typeof(Single).FullName);
            Assert.AreEqual(Types.FullName.Double, typeof(Double).FullName);
            Assert.AreEqual(Types.FullName.Int64, typeof(Int64).FullName);
            Assert.AreEqual(Types.FullName.Decimal, typeof(Decimal).FullName);
            Assert.AreEqual(Types.FullName.String, typeof(String).FullName);
            Assert.AreEqual(Types.FullName.DateTime, typeof(DateTime).FullName);
            Assert.AreEqual(Types.FullName.Guid, typeof(Guid).FullName);
            Assert.AreEqual(Types.FullName.Object, typeof(Object).FullName);
            Assert.AreEqual(Types.FullName.Array, typeof(Array).FullName);
        }

        [TestMethod()]
        public void Type_Name()
        {
            Assert.AreEqual(Types.Name.Enumerable.Dictionary2, typeof(Dictionary<int, int>).Name);
            Assert.AreEqual(Types.Name.Enumerable.CDictionary2, typeof(ConcurrentDictionary<int, int>).Name);
            Assert.AreEqual(Types.Name.Enumerable.List1, typeof(List<int>).Name);
            Assert.AreEqual(Types.Name.Enumerable.LinkedList1, typeof(LinkedList<int>).Name);
            Assert.AreEqual(Types.Name.Enumerable.Queue1, typeof(Queue<int>).Name);
            Assert.AreEqual(Types.Name.Enumerable.CQueue1, typeof(ConcurrentQueue<int>).Name);
            Assert.AreEqual(Types.Name.Enumerable.Stack1, typeof(Stack<int>).Name);
            Assert.AreEqual(Types.Name.Enumerable.CStack1, typeof(ConcurrentStack<int>).Name);
            Assert.AreEqual(Types.Name.Enumerable.IDictionary2, typeof(IDictionary<int, int>).Name);
            Assert.AreEqual(Types.Name.Enumerable.IEnumerable1, typeof(IEnumerable<int>).Name);

            var arr1 = new int[1];
            var arr2 = new int[1];
            var arr3 = new int[1];
            var concat2 = arr1.Concat(arr2);
            var concatN = arr1.Concat(arr2).Concat(arr3);
            Assert.AreEqual(Types.Name.Enumerable.Concat2Iterator1, concat2.GetType().Name);
            Assert.AreEqual(Types.Name.Enumerable.ConcatNIterator1, concatN.GetType().Name);

            Assert.AreEqual(Types.Name.Nullable1, typeof(int?).Name);
        }
    }
}
