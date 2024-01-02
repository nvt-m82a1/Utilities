using Utilities.Container.Tests.__models;

namespace Utilities.Container.Buildin.Tests
{
    [TestClass()]
    public class TypeReadWriterTests
    {
        [TestMethod()]
        public void AddClassTest()
        {
            var item2 = new DataTest.Item2();
            item2.Id = 84548;
            item2.Name = "Test2";

            var writer = new TypeWriter();
            writer.AddClass(item2);

            var bytes = writer.Container.Export();

            var reader = new TypeReader(bytes.ToArray());
            var item22 = new DataTest.Item2();
            reader.FillInstance(item22);

            Assert.IsTrue(item22 is not null);
            Assert.AreEqual(item2.Id, item22.Id);
            Assert.AreEqual(item2.Name, item22.Name);
        }
    }
}