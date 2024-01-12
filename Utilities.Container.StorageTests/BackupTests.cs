using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities.Container.Option;
using Utilities.Container.StorageTests.__models;

namespace Utilities.Container.Storage.Tests
{
    [TestClass()]
    public class BackupTests
    {
        [TestMethod()]
        public void SetupTest()
        {
            var backup = new Backup();
            var setup = backup.Setup("test", 1);
            Assert.AreEqual(true, setup);
        }

        [TestMethod()]
        public void SetupTest_duplicate()
        {
            var backup = new Backup();
            var setup = backup.Setup("test", 1);
            Assert.AreEqual(true, setup);

            var setup2 = backup.Setup("test", 2);
            Assert.AreEqual(false, setup2);
        }

        [TestMethod()]
        public void AddTests()
        {
            var backup = new Backup();
            backup.Setup("test", 2);

            var item = 123456;
            var add = backup.Add("test", item);
            Assert.AreEqual(true, add);
        }

        [TestMethod()]
        public void AddTests_wrong_key()
        {
            var backup = new Backup();
            backup.Setup("test", 2);

            var item = 123456;
            var add = backup.Add("test2", item);
            Assert.AreEqual(false, add);
        }

        [TestMethod()]
        public void ExportTests_bytes_index()
        {
            var backup = new Backup();
            backup.Setup("test", 1);
            var item = 123456;
            backup.Add("test", item);

            var data = backup.Export("test");
            Assert.IsNotNull(data);
        }


        [TestMethod()]
        public void ExportTests_bytes_timestamp()
        {
            var item1 = 123456;
            var item2 = 456789;

            var backup = new Backup();
            backup.Setup("test", 5);
            backup.Add("test", item1);
            var time1 = DateTime.Now;
            backup.Add("test", item2);
            var time2 = DateTime.Now;

            var data1 = backup.Get<int>("test", time1.Ticks);
            Assert.IsNotNull(data1);
            Assert.AreEqual(item1, data1);;

            var data2 = backup.Get<int>("test", time2.Ticks);
            Assert.IsNotNull(data2);
            Assert.AreEqual(item2, data2);
        }

        [TestMethod]
        public void ImportTests()
        {
            var item1 = 123456;
            var item2 = 456789;

            var backup1 = new Backup();
            backup1.Setup("test", 5);
            backup1.Add("test", item1);
            backup1.Add("test", item2);

            var data2 = backup1.Export("test", 0);
            Assert.IsNotNull(data2);

            var backup2 = new Backup();
            backup2.Setup("test", 5);
            backup2.Import("test", data2);

            var item2_restore = backup2.Get<int>("test", 0);
            Assert.AreEqual(item2, item2_restore);

            var data1 = backup1.Export("test", 1);
            Assert.IsNotNull(data1);

            var backup3 = new Backup();
            backup3.Setup("test", 5);
            backup3.Import("test", data1);

            var item1_restore = backup3.Get<int>("test", 0);
            Assert.AreEqual(item1, item1_restore);
        }

        [TestMethod()]
        [ExpectedException(typeof(TypeNotfoundException))]
        public void GetTests_index()
        {
            var item1 = 123456;
            var item2 = 456789;

            var backup = new Backup();
            backup.Setup("test", 5);
            backup.Add("test", item1);
            backup.Add("test", item2);

            var item2_restore = backup.Get<int?>("test");
            var item1_restore = backup.Get<int?>("test", 1);
            var itemNull = backup.Get<int?>("test", 2);
            var itemNotFound = backup.Get<DataTest>("test", 0);

            Assert.IsNotNull(item2_restore);
            Assert.IsNotNull(item1_restore);
            Assert.IsNull(itemNull);
            Assert.IsNull(itemNotFound);

            Assert.AreEqual(item1, item1_restore);
            Assert.AreEqual(item2, item2_restore);
        }

        [TestMethod()]
        [ExpectedException(typeof(TypeNotfoundException))]
        public void GetTest_timestamp()
        {
            var item1 = 123456;
            var item2 = 456789;

            var backup = new Backup();
            backup.Setup("test", 5);
            backup.Add("test", item1);
            var time1 = DateTime.Now;
            backup.Add("test", item2);
            var time2 = DateTime.Now;

            var item2_restore = backup.Get<int?>("test", time2.Ticks);
            var item2_1_restore = backup.Get<int?>("test", time2.Ticks, 1);
            var item1_restore = backup.Get<int?>("test", time1.Ticks);
            var itemNull = backup.Get<int?>("test", time1.Ticks, 1);
            var itemNotFound = backup.Get<DataTest>("test", time2.Ticks);

            Assert.IsNotNull(item2_restore);
            Assert.IsNotNull(item2_1_restore);
            Assert.IsNotNull(item1_restore);
            Assert.IsNull(itemNull);
            Assert.IsNull(itemNotFound);

            Assert.AreEqual(item1, item1_restore);
            Assert.AreEqual(item1, item2_1_restore);
            Assert.AreEqual(item2, item2_restore);
        }
    }
}