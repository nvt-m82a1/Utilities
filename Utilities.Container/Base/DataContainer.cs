namespace Utilities.Container.Base
{
    public class DataContainer : BaseContainer<DataContainer>
    {
        /// <summary>
        /// Ghi một kích thước byte hoặc integer
        /// </summary>
        public void AddLength(int data)
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
        /// Đọc một kích thước byte hoặc integer
        /// </summary>
        public int ReadLength()
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

        /// <summary>
        /// Quét trước kích thước là một byte hoặc integer
        /// </summary>
        /// <returns></returns>
        public int ScanLength()
        {
            var dataAsByte = Bits.Scan();
            if (dataAsByte == true)
            {
                return (int)Bytes.ScanItems(1)[0];
            }
            else
            {
                var bytes = Bytes.ScanItems(4);
                return BitConverter.ToInt32(bytes);
            }
        }

        /// <summary>
        /// Ghi một giá trị true / false
        /// </summary>
        /// <param name="data"></param>
        public void AddBoolean(bool data)
        {
            Bits.Add(data);
        }

        /// <summary>
        /// Đọc một giá trị true / false
        /// </summary>
        /// <returns></returns>
        public bool? ReadBoolean()
        {
            return Bits.Read();
        }

        /// <summary>
        /// Ghi một danh sách giá trị true / false
        /// </summary>
        /// <param name="data"></param>
        public void AddBooleanArray(IEnumerable<bool> data)
        {
            Bits.AddArray(data);
        }

        /// <summary>
        /// Đọc một danh sách giá trị true / false
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public IEnumerable<bool?> ReadBooleanArray(int length)
        {
            return Bits.ReadArray(length);
        }

        /// <summary>
        /// Ghi một mảng dữ liệu
        /// </summary>
        /// <param name="data"></param>
        public void AddArray(IEnumerable<byte> data)
        {
            Bytes.AddArray(data.ToArray());
        }

        /// <summary>
        /// Đọc một mảng dữ liệu
        /// </summary>
        /// <returns>(Số lượng bytes, mảng dưới dạng bytes)</returns>
        public (int, IEnumerable<byte>?) ReadArray()
        {
            return Bytes.ReadArray();
        }
    }
}
