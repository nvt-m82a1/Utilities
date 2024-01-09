using System.Collections;
using System.Collections.Concurrent;

namespace Utilities.Container.Option.Tests
{
    [TestClass()]
    public class TypesNameTests
    {
        [TestMethod()]
        public void Type_FullName()
        {
            Assert.AreEqual(TypesName.FullName.Boolean, typeof(Boolean).FullName);
            Assert.AreEqual(TypesName.FullName.Byte, typeof(Byte).FullName);
            Assert.AreEqual(TypesName.FullName.SByte, typeof(SByte).FullName);
            Assert.AreEqual(TypesName.FullName.Char, typeof(Char).FullName);
            Assert.AreEqual(TypesName.FullName.Int16, typeof(Int16).FullName);
            Assert.AreEqual(TypesName.FullName.UInt16, typeof(UInt16).FullName);
            Assert.AreEqual(TypesName.FullName.Int32, typeof(Int32).FullName);
            Assert.AreEqual(TypesName.FullName.UInt32, typeof(UInt32).FullName);
            Assert.AreEqual(TypesName.FullName.Single, typeof(Single).FullName);
            Assert.AreEqual(TypesName.FullName.Double, typeof(Double).FullName);
            Assert.AreEqual(TypesName.FullName.Int64, typeof(Int64).FullName);
            Assert.AreEqual(TypesName.FullName.Decimal, typeof(Decimal).FullName);
            Assert.AreEqual(TypesName.FullName.String, typeof(String).FullName);
            Assert.AreEqual(TypesName.FullName.DateTime, typeof(DateTime).FullName);
            Assert.AreEqual(TypesName.FullName.Guid, typeof(Guid).FullName);
            Assert.AreEqual(TypesName.FullName.Object, typeof(Object).FullName);
            Assert.AreEqual(TypesName.FullName.Array, typeof(Array).FullName);
        }

        [TestMethod()]
        public void Type_Name()
        {
            Assert.AreEqual(TypesName.Name.Enumerable.Dictionary2, typeof(Dictionary<int, int>).Name);
            Assert.AreEqual(TypesName.Name.Enumerable.CDictionary2, typeof(ConcurrentDictionary<int, int>).Name);
            Assert.AreEqual(TypesName.Name.Enumerable.List1, typeof(List<int>).Name);
            Assert.AreEqual(TypesName.Name.Enumerable.LinkedList1, typeof(LinkedList<int>).Name);
            Assert.AreEqual(TypesName.Name.Enumerable.Queue1, typeof(Queue<int>).Name);
            Assert.AreEqual(TypesName.Name.Enumerable.CQueue1, typeof(ConcurrentQueue<int>).Name);
            Assert.AreEqual(TypesName.Name.Enumerable.Stack1, typeof(Stack<int>).Name);
            Assert.AreEqual(TypesName.Name.Enumerable.CStack1, typeof(ConcurrentStack<int>).Name);
            Assert.AreEqual(TypesName.Name.Enumerable.IDictionary2, typeof(IDictionary<int, int>).Name);
            Assert.AreEqual(TypesName.Name.Enumerable.IList1, typeof(IList<int>).Name);
            Assert.AreEqual(TypesName.Name.Enumerable.IEnumerable, typeof(IEnumerable).Name);
            Assert.AreEqual(TypesName.Name.Enumerable.IEnumerable1, typeof(IEnumerable<int>).Name);

            var arr1 = new int[1];
            var arr2 = new int[1];
            var arr3 = new int[1];
            var concat2 = arr1.Concat(arr2);
            var concatN = arr1.Concat(arr2).Concat(arr3);
            Assert.AreEqual(TypesName.Name.Enumerable.Concat2Iterator1, concat2.GetType().Name);
            Assert.AreEqual(TypesName.Name.Enumerable.ConcatNIterator1, concatN.GetType().Name);

            Assert.AreEqual(TypesName.Name.Nullable1, typeof(int?).Name);

            var range1 = Enumerable.Range(0, 10).Select(x => x);
            Assert.AreEqual(TypesName.Name.Enumerable.SelectRangeIterator1, range1.GetType().Name);
        }
    }
}
