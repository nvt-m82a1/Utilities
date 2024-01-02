using System.Diagnostics.CodeAnalysis;

namespace Utilities.Container.Base
{
    /// <summary>
    /// Lưu và đọc dữ liệu bit
    /// </summary>
    public class BitContainer :
        IContainer<byte>,
        IEquatable<BitContainer>,
        IEqualityComparer<BitContainer>
    {
        public int TotalElements => Total;
        public int TotalExportBytes
        {
            get
            {
                if (Data.Count == 0)
                    return 1;

                return 2 + Data.Count;
            }
        }

        // Serialization data
        protected byte Offset;
        protected IList<byte> Data;
        // End Serialization data

        protected int Total;
        protected int Template;

        // Read
        protected int ReadItor;
        protected int ReadOffset;
        protected int ReadTotal;
        // End Read

        public BitContainer()
        {
            Data = new List<byte>();
        }

        /// <summary>
        /// Thêm một bit dữ liệu
        /// </summary>
        public void Add(bool data)
        {
            if (Offset >= 8 || Total == 0)
            {
                Data.Add(0);
                Offset = 0;
                Template = 0;
            }

            if (data)
            {
                Template |= 1 << Offset;
                Data[Data.Count - 1] = (byte)Template;
            }

            Offset++;
            Total++;
        }

        /// <summary>
        /// Thêm một mảng bit dữ liệu
        /// </summary>
        public void AddArray(IEnumerable<bool> data)
        {
            foreach (bool item in data)
                Add(item);
        }

        /// <summary>
        /// Đọc một bit dữ liệu
        /// </summary>
        public bool? Read()
        {
            if (ReadTotal >= Total) return null;
            if (ReadOffset >= 8)
            {
                ReadItor++;
                ReadOffset = 0;
            }

            var data = (Data[ReadItor] & (1 << ReadOffset)) == 0 ? false : true;
            ReadOffset++;
            ReadTotal++;
            return data;
        }

        /// <summary>
        /// Đọc một mảng bit dữ liệu
        /// </summary>
        public bool?[] ReadArray(int length)
        {
            var data = new bool?[length];
            for (int i = 0; i < length; i++)
                data[i] = Read();

            return data;
        }

        public void ReadReset()
        {
            ReadItor = 0;
            ReadOffset = 0;
            ReadTotal = 0;
        }

        public IEnumerable<byte> Export()
        {
            byte length = (byte)this.TotalExportBytes;
            if (this.Data.Count == 0)
                return [length];
            else
                return [length, Offset, .. Data];
        }

        public int Import(byte[] buffer, int start = 0)
        {
            byte length = buffer[start + 0];
            if (length == 0)
                return start + length;

            Offset = buffer[start + 1];

            var dataSize = length - 2;
            if (dataSize > 0)
            {
                Data = new List<byte>();
                for (int i = 0; i < dataSize; i++)
                    Data.Add(buffer[start + 2 + i]);

                Template = Data[dataSize - 1];
                Total = ((dataSize - 1) << 3) + Offset;
            }

            return start + length;
        }

        public bool Equals(BitContainer? other)
        {
            return Equals(this, other);
        }

        public bool Equals(BitContainer? x, BitContainer? y)
        {
            if (x == null && y == null) return true;
            if (x != null && y != null)
            {
                return x.Offset == y.Offset
                    && x.Data.SequenceEqual(y.Data);
            }
            return false;
        }

        public int GetHashCode([DisallowNull] BitContainer obj)
        {
            var hashcode = HashCode.Combine(Offset, Data, Data.Count);
            return hashcode;
        }
    }
}
