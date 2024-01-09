using Utilities.Container.Base;

namespace Utilities.Container.Tests.__models
{
    internal class ContainerTest : BaseContainer<ContainerTest>
    {
        public void AddItem(byte data)
        {
            Bytes.AddItem(data);
        }

        public byte? ReadItem()
        {
            return Bytes.ReadItem();
        }
    }
}
