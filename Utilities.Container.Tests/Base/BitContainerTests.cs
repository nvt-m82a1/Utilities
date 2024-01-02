namespace Utilities.Container.Base.Tests
{
    [TestClass()]
    public class BitContainerTests
    {
        [TestMethod()]
        public void AddTest_true()
        {
            var container = new BitContainer();
            container.Add(true);

            var data = container.Read();
            Assert.IsTrue(data == true);
        }

        [TestMethod()]
        public void AddTest_false()
        {
            var container = new BitContainer();
            container.Add(false);

            var data = container.Read();
            Assert.IsTrue(data == false);
        }

        [TestMethod()]
        public void AddTest_Array()
        {
            bool[] arr = [true, false, false, true];
            var container = new BitContainer();
            container.AddArray(arr);

            var data = container.ReadArray(4).ToArray();
            for (var i=0; i<arr.Length; i++)
            {
                Assert.IsTrue(arr[i] == data[i]);
            }
        }

        [TestMethod()]
        public void ReadTest_null()
        {
            var container = new BitContainer();
            var data = container.Read();

            Assert.IsNull(data);
        }

        [TestMethod()]
        public void ReadTest_Array_contains_null()
        {
            var container = new BitContainer();
            container.Add(true);

            var data = container.ReadArray(4).ToArray();
            Assert.IsTrue(data[0] == true);
            Assert.IsNull(data[1]);
            Assert.IsNull(data[2]);
            Assert.IsNull(data[3]);
        }

        [TestMethod()]
        public void ImportExport()
        {
            bool[] arr = [false, true, false, true, true, false, true];
            var container = new BitContainer();
            container.AddArray(arr);

            var bytes = container.Export();

            var container2 = new BitContainer();
            container2.Import(bytes.ToArray());

            Assert.IsTrue(container.Equals(container2));

            var arr2 = container2.ReadArray(7).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.IsTrue(arr[i] == arr2[i]);
            }
        }
    }
}