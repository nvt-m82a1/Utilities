using Utilities.Container.Converter;
using static Utilities.Container.Tests.__models.RefsTest;

namespace Utilities.Container.Tests.Converter
{
    [TestClass]
    internal class DataRefsTest
    {
        [TestMethod]
        public void RefsTest_self()
        {
            var data = new RefData1();
            data.Id = 1;
            data.Self = data;

            var bytes = DataConvert.Instance.GetBytes(data);
            var item = DataConvert.Instance.GetItem<RefData1>(bytes);

            Assert.IsNotNull(bytes);
            Assert.IsNotNull(item);

            Assert.AreEqual(data.Id, item.Id);
            Assert.AreSame(item, item.Self);
        }

        [TestMethod]
        public void RefsTest_array()
        {
            var data = new RefData2();

            RefData1[] arr = new RefData1[5];
            for (var i = 0; i < 5; i++)
            {
                arr[i] = new RefData1();
                arr[i].Id = i;
            }
            data.Arr = arr;

            var bytes = DataConvert.Instance.GetBytes(data);
            var item = DataConvert.Instance.GetItem<RefData2>(bytes);

            Assert.IsNotNull(bytes);
            Assert.IsNotNull(item);

            Assert.AreEqual(5, item.Arr.Count());
            var itemArrIter = item.Arr.GetEnumerator();
            for (var i = 0; i < 5; i++)
            {
                itemArrIter.MoveNext();
                Assert.AreEqual(arr[i].Id, itemArrIter.Current.Id);
                Assert.AreSame(itemArrIter.Current, itemArrIter.Current.Self);
            }
        }

        [TestMethod]
        public void RefsTest_refer()
        {
            var ref3 = new RefData3();
            var ref4 = new RefData4();

            ref3.Item3 = 3;
            ref3.RefData4 = ref4;
            
            ref4.Item4 = 4;
            ref4.RefData3 = ref3;

            var bytes3 = DataConvert.Instance.GetBytes(ref3);
            var bytes4 = DataConvert.Instance.GetBytes(ref4);

            var item3 = DataConvert.Instance.GetItem<RefData3>(bytes3);
            var item4 = DataConvert.Instance.GetItem<RefData4>(bytes4);

            Assert.IsNotNull(bytes3);
            Assert.IsNotNull(bytes4);
            Assert.IsNotNull(item3);
            Assert.IsNotNull(item4);

            Assert.AreEqual(ref3.Item3, item3.Item3);
            Assert.AreEqual(ref3.RefData4.Item4, item4.Item4);

            Assert.AreEqual(ref4.Item4, item4.Item4);
            Assert.AreEqual(ref4.RefData3.Item3, item3.Item3);

            Assert.AreSame(ref3, ref3.RefData4.RefData3);
            Assert.AreSame(ref4, ref4.RefData3.RefData4);
        }

        [TestMethod]
        public void RefsTest_loop()
        {
            var ref5 = new RefData5();
            ref5.RefData3 = new RefData3();
            ref5.RefData4 = new RefData4();

            ref5.RefData3.Item3 = 3;
            ref5.RefData3.RefData4 = ref5.RefData4;

            ref5.RefData4.Item4 = 4;
            ref5.RefData4.RefData3 = ref5.RefData3;

            var bytes = DataConvert.Instance.GetBytes(ref5);
            var item = DataConvert.Instance.GetItem<RefData5>(bytes);

            Assert.IsNotNull(bytes);
            Assert.IsNotNull(item);

            Assert.AreSame(item.RefData3, item.RefData4.RefData3);
            Assert.AreSame(item.RefData4, item.RefData3.RefData4);
        }
    }
}
