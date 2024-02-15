using Utilities.Container.Tests.__models;

namespace Utilities.Container.Stage.Tests
{
    [TestClass()]
    public class RollbackItemTests
    {
        [TestMethod()]
        public void CommitRollbackTest()
        {
            var item = new ModelTest { Id = 1, Name = "test1" };

            var urItem = new RollbackItem<ModelTest>(item, 5);
            Assert.AreEqual(1, urItem.Count);

            item.Id = 2;
            item.Name = "test2";
            urItem.Commit();
            Assert.AreEqual(2, urItem.Count);

            item.Id = 3;
            item.Name = "test3";
            urItem.Commit();
            Assert.AreEqual(3, urItem.Count);

            item.Id = 4;
            item.Name = "test4";
            urItem.Commit();
            Assert.AreEqual(4, urItem.Count);

            var rb3 = urItem.Rollback();
            Assert.IsTrue(rb3);
            Assert.AreEqual(3, urItem.Count);
            Assert.AreEqual(3, item.Id);
            Assert.AreEqual("test3", item.Name);

            var rb2 = urItem.Rollback();
            Assert.IsTrue(rb2);
            Assert.AreEqual(2, urItem.Count);
            Assert.AreEqual(2, item.Id);
            Assert.AreEqual("test2", item.Name);

            var rb1 = urItem.Rollback();
            Assert.IsTrue(rb1);
            Assert.AreEqual(1, urItem.Count);
            Assert.AreEqual(1, item.Id);
            Assert.AreEqual("test1", item.Name);

            var rb0 = urItem.Rollback();
            Assert.IsFalse(rb0);
            Assert.AreEqual(1, urItem.Count);
            Assert.AreEqual(1, item.Id);
            Assert.AreEqual("test1", item.Name);
        }
    }
}