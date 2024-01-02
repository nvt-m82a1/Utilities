using Utilities.Container.Base;

namespace Utilities.Container.Tests.__models
{
    internal class ContainerTest : DataContainer<ContainerTest>
    {
        public void AddItem(byte data)
        {
            Bytes.AddItem(data);
        }
    }
}
