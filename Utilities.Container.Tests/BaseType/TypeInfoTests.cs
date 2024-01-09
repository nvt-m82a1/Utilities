namespace Utilities.Container.BaseType.Tests
{
    [TestClass()]
    public class TypeInfoTests
    {
        [TestMethod()]
        public void TypeInfoTest_Init()
        {
            var usertype = typeof(int);
            var typeInfo = new TypeInfo(usertype);

            Assert.AreEqual(usertype, typeInfo.Type);
            Assert.AreEqual(usertype.FullName ?? usertype.Name, typeInfo.FullName);
        }
    }
}