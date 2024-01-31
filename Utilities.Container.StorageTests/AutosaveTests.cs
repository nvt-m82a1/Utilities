using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utilities.Container.Storage.Tests
{
    [TestClass()]
    public class AutosaveTests
    {
        [TestMethod()]
        public void AddGetTest_index()
        {
            var now = DateTime.Now;
            var after2s = now.AddSeconds(2);

            var autosave = new Autosave();
            var getItem = () =>
            {
                if (DateTime.Now >= after2s) return 456789;
                return 123456;
            };

            var add = autosave.Create("test", getItem, 2, 2);
            Assert.IsTrue(add);
            var item1 = autosave.Get<int>("test");
            Assert.AreEqual(123456, item1);
            
            Thread.Sleep(2500);
            var item2 = autosave.Get<int>("test");
            Assert.AreEqual(456789, item2);
        }

        [TestMethod()]
        public void AddGetTest_timestamp()
        {
            var now = DateTime.Now;
            var after2s = now.AddSeconds(2);

            var autosave = new Autosave();
            var getItem = () =>
            {
                if (DateTime.Now >= after2s) return 456789;
                return 123456;
            };

            var add = autosave.Create("test", getItem, 2, 2);
            Assert.IsTrue(add);
            var time1 = DateTime.Now;
            Thread.Sleep(3000);
            var time2 = DateTime.Now;

            var item1 = autosave.Get<int>("test", time1.Ticks);
            Assert.AreEqual(123456, item1);

            var item2 = autosave.Get<int>("test", time2.Ticks);
            Assert.AreEqual(456789, item2);
        }
    }
}