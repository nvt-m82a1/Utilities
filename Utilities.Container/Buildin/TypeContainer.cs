using Utilities.Container.Base;

namespace Utilities.Container.Buildin
{
    public class TypeContainer : DataContainer<TypeContainer>
    {
        /// <summary>
        /// Ghi một số int32
        /// </summary>
        public void AddInt32(int data)
        {
            var dataAsByte = data <= byte.MaxValue;
            Bits.Add(dataAsByte);
            if (dataAsByte)
            {
                Bytes.AddItem((byte)data);
            }
            else
            {
                Bytes.AddItems(BitConverter.GetBytes(data));
            }
        }

        /// <summary>
        /// Đọc một số int32
        /// </summary>
        public int ReadInt32()
        {
            var dataAsByte = Bits.Read();
            if (dataAsByte == true)
            {
                return (int)Bytes.ReadItem()!;
            }
            else
            {
                var bytes = Bytes.ReadItems(4);
                return BitConverter.ToInt32(bytes);
            }
        }

        public void AddBoolean(bool data)
        {
            Bits.Add(data);
        }

        public void AddBooleanArray(IEnumerable<bool> data)
        {
            Bits.AddArray(data);
        }

        public void AddBytes(IEnumerable<byte> data)
        {
            Bytes.AddArray(data);
        }

        public bool? ReadBoolean()
        {
            return Bits.Read();
        }

        public IEnumerable<bool?> ReadBooleanArray(int length)
        {
            return Bits.ReadArray(length);
        }

        public (int, IEnumerable<byte>?) ReadArray()
        {
            return Bytes.ReadArray();
        }
    }
}
