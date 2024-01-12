using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utilities.Container.Storage.Tests
{
    [TestClass()]
    public class BackupItemTests
    {
        [TestMethod()]
        public void InitTests_0()
        {
            var count = 0;
            var backupItem = new BackupItem(count);
            Assert.AreEqual(count, backupItem.Total);
            Assert.AreEqual(-1, backupItem.Index);
            Assert.AreEqual(count, backupItem.Data.Length);
            Assert.AreEqual(count, backupItem.Timestamp.Length);
        }

        [TestMethod()]
        public void InitTests_1()
        {
            var count = 1;
            var backupItem = new BackupItem(count);
            Assert.AreEqual(count, backupItem.Total);
            Assert.AreEqual(-1, backupItem.Index);
            Assert.AreEqual(count, backupItem.Data.Length);
            Assert.AreEqual(count, backupItem.Timestamp.Length);
        }

        [TestMethod()]
        public void InitTests_1000()
        {
            var count = 1000;
            var backupItem = new BackupItem(count);
            Assert.AreEqual(count, backupItem.Total);
            Assert.AreEqual(-1, backupItem.Index);
            Assert.AreEqual(count, backupItem.Data.Length);
            Assert.AreEqual(count, backupItem.Timestamp.Length);
        }

        [TestMethod()]
        public void AddTests_null()
        {
            var backupItem = new BackupItem(1);
            backupItem.Add(null);
            Assert.AreEqual(1, backupItem.Total);
            backupItem.Data[0] = null;
        }

        [TestMethod()]
        public void AddTests_empty()
        {
            var item = Array.Empty<byte>();
            var backupItem = new BackupItem(1);
            backupItem.Add(item);
            Assert.AreEqual(1, backupItem.Total);
            backupItem.Data[0] = item;
        }

        [TestMethod()]
        public void AddTests_array()
        {
            var item = new byte[] { 12, 25, 68, 47, 54, 48, 59 };
            var backupItem = new BackupItem(1);
            backupItem.Add(item);
            Assert.AreEqual(1, backupItem.Total);
            Assert.IsNotNull(backupItem.Data[0]);
            Assert.IsTrue(backupItem.Data[0]!.SequenceEqual(item));
        }


        [TestMethod()]
        public void GetTests_reverseIndex()
        {
            byte[]? item1 = [12, 25, 68, 47, 54, 48, 59];
            byte[]? item2 = null;
            byte[]? item3 = [56];

            var backupItem = new BackupItem(5);
            backupItem.Add(item1);
            backupItem.Add(item2);
            backupItem.Add(item3);
            
            Assert.AreEqual(5, backupItem.Total);

            var get3 = backupItem.Get(0);
            var get2 = backupItem.Get(1);
            var get1 = backupItem.Get(2);
            var getNull = backupItem.Get(3);
            var get100 = backupItem.Get(100);

            Assert.IsNotNull(get3);
            Assert.IsNull(get2);
            Assert.IsNotNull(get1);
            Assert.IsNull(getNull);
            Assert.IsNull(get100);

            Assert.IsTrue(item1.SequenceEqual(get1));
            Assert.IsTrue(item3.SequenceEqual(get3));
        }

        [TestMethod()]
        public void GetTests_timestamp()
        {
            byte[]? item1 = [1];
            byte[]? item2 = [2];
            byte[]? item3 = [3];
            byte[]? item4 = [4];

            var backupItem = new BackupItem(5);
            backupItem.Add(item1);
            Thread.Sleep(1000);
            backupItem.Add(item2);
            Thread.Sleep(1000);
            backupItem.Add(item3);
            Thread.Sleep(1000);
            backupItem.Add(item4);

            Assert.AreEqual(5, backupItem.Total);

            Thread.Sleep(100);
            var now = DateTime.Now;

            var get4 = backupItem.Get(now.Ticks);
            var get4_0 = backupItem.Get(now.Ticks, 0);
            var get4_1 = backupItem.Get(now.Ticks, 1);
            var get4_2 = backupItem.Get(now.Ticks, 2);
            var get4_3 = backupItem.Get(now.Ticks, 3);
            var get4_4 = backupItem.Get(now.Ticks, 4);
            Assert.AreEqual(get4, get4_0);
            Assert.AreEqual(item4, get4_0);
            Assert.AreEqual(item3, get4_1);
            Assert.AreEqual(item2, get4_2);
            Assert.AreEqual(item1, get4_3);
            Assert.AreEqual(null, get4_4);

            var time3 = now.Subtract(TimeSpan.FromMilliseconds(1000));
            var get3 = backupItem.Get(time3.Ticks);
            var get3_0 = backupItem.Get(time3.Ticks, 0);
            var get3_1 = backupItem.Get(time3.Ticks, 1);
            var get3_2 = backupItem.Get(time3.Ticks, 2);
            var get3_3 = backupItem.Get(time3.Ticks, 3);
            Assert.AreEqual(get3, get3_0);
            Assert.AreEqual(item3, get3_0);
            Assert.AreEqual(item2, get3_1);
            Assert.AreEqual(item1, get3_2);
            Assert.AreEqual(null, get3_3);

            var time2 = time3.Subtract(TimeSpan.FromMilliseconds(1000));
            var get2 = backupItem.Get(time2.Ticks);
            var get2_0 = backupItem.Get(time2.Ticks, 0);
            var get2_1 = backupItem.Get(time2.Ticks, 1);
            var get2_2 = backupItem.Get(time2.Ticks, 2);
            Assert.AreEqual(get2, get2_0);
            Assert.AreEqual(item2, get2_0);
            Assert.AreEqual(item1, get2_1);
            Assert.AreEqual(null, get2_2);

            byte[]?[] arr4NotNull = [get4_0, get4_1, get4_2, get4_3];
            byte[]?[] arr4Null = [get4_4];

            byte[]?[] arr3NotNull = [get3_0, get3_1, get3_2];
            byte[]?[] arr3Null = [get3_3];

            byte[]?[] arr2NotNull = [get2_0, get2_1];
            byte[]?[] arr2Null = [get2_2];

            foreach (var item in arr4NotNull) Assert.IsNotNull(item);
            foreach (var item in arr3NotNull) Assert.IsNotNull(item);
            foreach (var item in arr2NotNull) Assert.IsNotNull(item);

            foreach (var item in arr4Null) Assert.IsNull(item);
            foreach (var item in arr3Null) Assert.IsNull(item);
            foreach (var item in arr2Null) Assert.IsNull(item);

            byte[]?[] arr4EqualArr3 = [get4_1, get4_2, get4_3];
            byte[]?[] arr3EqualArr2 = [get3_1, get3_2];

            for(var i=0; i<arr3NotNull.Length; i++)
            {
                Assert.IsNotNull(arr4EqualArr3[i]);
                Assert.IsNotNull(arr3NotNull[i]);
                Assert.IsTrue(arr4EqualArr3[i]!.SequenceEqual(arr3NotNull[i]!));
            }

            for (var i = 0; i < arr2NotNull.Length; i++)
            {
                Assert.IsNotNull(arr3EqualArr2[i]);
                Assert.IsNotNull(arr2NotNull[i]);
                Assert.IsTrue(arr3EqualArr2[i]!.SequenceEqual(arr2NotNull[i]!));
            }
        }
    }
}