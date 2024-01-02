namespace Utilities.Container.Buildin.Tests
{
    [TestClass()]
    public class TypeContainerTests
    {
        [TestMethod()]
        public void AddInt32Test()
        {
            var item = 85688498;
            var container = new TypeContainer();
            container.AddInt32(item);
            var data = container.ReadInt32();

            Assert.IsTrue(data == item);
        }
    }
}