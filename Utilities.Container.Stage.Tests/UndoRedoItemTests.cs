using Utilities.Container.Stage.Tests.__models;

namespace Utilities.Container.Stage.Tests
{
    [TestClass()]
    public class UndoRedoItemTests
    {
        [TestMethod()]
        public void CommitUndoRedoTest()
        {
            var item = new ModelTest { Id = 1, Name = "test1" };

            var urItem = new UndoRedoItem<ModelTest>(item, 5);
            Assert.AreEqual(1, urItem.Count);

            item.Id = 2;
            item.Name = "test2";
            urItem.Commit();
            Assert.AreEqual(2, urItem.Count);

            item.Id = 3;
            item.Name = "test3";
            urItem.Commit();
            Assert.AreEqual(3, urItem.Count);

            var ud2 = urItem.Undo();
            Assert.IsTrue(ud2);
            Assert.AreEqual(2, urItem.Count);
            Assert.AreEqual(2, item.Id);
            Assert.AreEqual("test2", item.Name);

            var ud1 = urItem.Undo();
            Assert.IsTrue(ud1);
            Assert.AreEqual(1, urItem.Count);
            Assert.AreEqual(1, item.Id);
            Assert.AreEqual("test1", item.Name);

            var ud0 = urItem.Undo();
            Assert.IsFalse(ud0);
            Assert.AreEqual(1, urItem.Count);
            Assert.AreEqual(1, item.Id);
            Assert.AreEqual("test1", item.Name);

            var rd2 = urItem.Redo();
            Assert.IsTrue(rd2);
            Assert.AreEqual(2, urItem.Count);
            Assert.AreEqual(2, item.Id);
            Assert.AreEqual("test2", item.Name);

            var rd3 = urItem.Redo();
            Assert.IsTrue(rd3);
            Assert.AreEqual(3, urItem.Count);
            Assert.AreEqual(3, item.Id);
            Assert.AreEqual("test3", item.Name);

            var rd4 = urItem.Redo();
            Assert.IsFalse(rd4);
            Assert.AreEqual(3, urItem.Count);
            Assert.AreEqual(3, item.Id);
            Assert.AreEqual("test3", item.Name);
        }

        [TestMethod()]
        public void CommitUndoAddTest()
        {
            var item = new ModelTest { Id = 1, Name = "test1" };
            var urItem = new UndoRedoItem<ModelTest>(item, 5);

            item.Id = 2;
            item.Name = "test2";
            urItem.Commit();

            item.Id = 3;
            item.Name = "test3";
            urItem.Commit();

            urItem.Undo();

            item.Id = 4;
            item.Name = "test4";
            urItem.Commit();

            var rd2 = urItem.Undo();
            Assert.IsTrue(rd2);
            Assert.AreEqual(2, urItem.Count);
            Assert.AreEqual(2, item.Id);
            Assert.AreEqual("test2", item.Name);

            var rd4 = urItem.Redo();
            Assert.IsTrue(rd4);
            Assert.AreEqual(3, urItem.Count);
            Assert.AreEqual(4, item.Id);
            Assert.AreEqual("test4", item.Name);
        }
    }
}