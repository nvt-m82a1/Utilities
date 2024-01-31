using System.Diagnostics.CodeAnalysis;

namespace Utilities.Container.Base
{
    /// <summary>
    /// Lưu và đọc dữ liệu byte
    /// </summary>
    public class ByteContainer :
        IContainer<byte>,
        IEquatable<ByteContainer>,
        IEqualityComparer<ByteContainer>
    {
        public int TotalElements => Items.Count + Bits.TotalElements;
        public int TotalExportBytes
        {
            get
            {
                if (TotalElements == 0)
                    return 4;

                return 12 + Items.Count + Bits.TotalExportBytes + ArraySizes.Count + Arrays.Sum(arr => arr.Count());
            }
        }

        // Serialization data
        /// <summary>
        /// Dữ liệu là một byte
        /// </summary>
        protected IList<byte> Items;

        /// <summary>
        /// Danh sách cờ của mảng dữ liệu
        /// </summary>
        protected BitContainer Bits;
        /// <summary>
        /// Danh sách kích thước của mỗi mảng dữ liệu
        /// </summary>
        protected IList<byte> ArraySizes;
        /// <summary>
        /// Danh sách mảng dữ liệu ở định dạng byte
        /// </summary>
        protected IList<IEnumerable<byte>> Arrays;
        // End Serialization data

        // Read
        protected int ItemIter;
        protected int ArraySizeIter;
        protected int ArrayIter;
        // End Read

        /// <summary>
        /// Khởi tạo container
        /// </summary>
        public ByteContainer()
        {
            Items = new List<byte>();
            Bits = new BitContainer();
            ArraySizes = new List<byte>();
            Arrays = new List<IEnumerable<byte>>();
        }

        /// <summary>
        /// Thêm một dữ liệu đơn
        /// </summary>
        public void AddItem(byte data)
        {
            Items.Add(data);
        }

        /// <summary>
        /// Thêm một danh sách dữ liệu đơn
        /// </summary>
        public void AddItems(byte[] data)
        {
            foreach (var item in data)
                Items.Add(item);
        }

        /// <summary>
        /// Thêm một mảng dữ liệu
        /// </summary>
        public void AddArray(IEnumerable<byte> data)
        {
            var size = data.Count();
            if (size == 0) return;

            var largeSize = size > byte.MaxValue;

            Bits.Add(largeSize);
            if (!largeSize)
            {
                ArraySizes.Add((byte)size);
                Arrays.Add(data);
            }
            else
            {
                foreach (var item in BitConverter.GetBytes(size))
                    ArraySizes.Add(item);

                Arrays.Add(data);
            }
        }

        /// <summary>
        /// Đọc một dữ liệu đơn
        /// </summary>
        public byte? ReadItem()
        {
            if (ItemIter >= Items.Count) return null;

            var data = Items[ItemIter];
            ItemIter++;
            return data;
        }

        /// <summary>
        /// Đọc nhiều dữ liệu đơn
        /// </summary>
        public byte[] ReadItems(int length)
        {
            var data = new byte[length];
            var minLength = Math.Min(Items.Count - ItemIter, length);
            for (int i = 0; i < minLength; i++)
                data[i] = ReadItem() ?? 0;
            return data;
        }

        /// <summary>
        /// Đọc nhiều dữ liệu đơn, không tăng vị trí đọc
        /// </summary>
        public byte[] ScanItems(int length)
        {
            var data = new byte[length];
            var minLength = Math.Min(Items.Count - ItemIter, length);
            for (int i = 0; i < minLength; i++)
                data[i] = Items[ItemIter + i];
            return data;
        }

        /// <summary>
        /// Đọc một mảng dữ liệu
        /// </summary>
        /// <returns>(Kích thước mảng, mảng dưới dạng bytes)</returns>
        public (int, IEnumerable<byte>?) ReadArray()
        {
            if (ArrayIter >= Arrays.Count || ArraySizeIter >= ArraySizes.Count)
                return (0, null);

            var largeSize = Bits.Read();

            if (largeSize != true)
            {
                int size = ArraySizes[ArraySizeIter];
                var bytes = Arrays[ArrayIter];
                ArrayIter++;
                ArraySizeIter++;
                return (size, bytes);
            }
            else
            {
                byte[] sizeSpan = [
                    ArraySizes[ArraySizeIter + 0],
                    ArraySizes[ArraySizeIter + 1],
                    ArraySizes[ArraySizeIter + 2],
                    ArraySizes[ArraySizeIter + 3]];

                var size = BitConverter.ToInt32(sizeSpan);
                var bytes = Arrays[ArrayIter];
                ArrayIter++;
                ArraySizeIter += 4;
                return (size, bytes);
            }
        }

        /// <summary>
        /// Reset thông tin đọc
        /// </summary>
        public void ReadReset()
        {
            ItemIter = 0;
            Bits.ReadReset();
            ArraySizeIter = 0;
            ArrayIter = 0;
        }

        /// <summary>
        /// Làm rỗng container
        /// </summary>
        public void Clear()
        {
            Items.Clear();
            Bits.Clear();
            ArraySizes.Clear();
            Arrays.Clear();
            ReadReset();
        }

        /// <summary>
        /// Xuất dữ liệu từ container
        /// </summary>
        public IEnumerable<byte> Export()
        {
            var length = BitConverter.GetBytes(this.TotalExportBytes);
            if (this.TotalElements == 0)
            {
                return length;
            }

            var itemCount = BitConverter.GetBytes(Items.Count);
            var arraySizesCount = BitConverter.GetBytes(ArraySizes.Count);

            return length.Concat(itemCount).Concat(arraySizesCount)
                .Concat(Items)
                .Concat(Bits.Export())
                .Concat(ArraySizes)
                .Concat(Arrays.SelectMany(x => x));
        }

        /// <summary>
        /// Nhập dữ liệu vào container
        /// </summary>
        /// <param name="buffer">Mảng dữ liệu</param>
        /// <param name="start">Vị trí bắt đầu</param>
        public int Import(byte[] buffer, int start = 0)
        {
            int length = BitConverter.ToInt32(buffer, start);
            if (length == 4)
                return start + length;

            int itemCount = BitConverter.ToInt32(buffer, start + 4);
            int arraySizesCount = BitConverter.ToInt32(buffer, start + 8);

            var dataPivot = start + 12;

            if (itemCount > 0)
            {
                var items = new ReadOnlySpan<byte>(buffer, dataPivot, itemCount);
                Items = items.ToArray();
                dataPivot += itemCount;
            }

            if (arraySizesCount > 0)
            {
                Bits = new BitContainer();
                dataPivot = Bits.Import(buffer, dataPivot);

                var arraySizes = new ReadOnlySpan<byte>(buffer, dataPivot, arraySizesCount);
                ArraySizes = arraySizes.ToArray();
                dataPivot += arraySizesCount;

                for (int i = 0; i < arraySizesCount;)
                {
                    if (Bits.Read() != true)
                    {
                        var arraySize = ArraySizes[i];
                        i++;

                        var arrayBytes = new ReadOnlySpan<byte>(buffer, dataPivot, arraySize);
                        Arrays.Add(arrayBytes.ToArray());
                        dataPivot += arraySize;
                    }
                    else
                    {
                        byte[] arraySizeSpan = [
                            ArraySizes[i + 0],
                            ArraySizes[i + 1],
                            ArraySizes[i + 2],
                            ArraySizes[i + 3]];
                        i += 4;
                        var arraySize = BitConverter.ToInt32(arraySizeSpan);

                        var arrayBytes = new ReadOnlySpan<byte>(buffer, dataPivot, arraySize);
                        Arrays.Add(arrayBytes.ToArray());
                        dataPivot += arraySize;
                    }
                }
                Bits.ReadReset();
            }

            return start + length;
        }

        /// <summary>
        /// Kiểm tra bằng
        /// </summary>
        /// <param name="other">Container khác</param>
        public bool Equals(ByteContainer? other)
        {
            return Equals(this, other);
        }

        /// <summary>
        /// Kiểm tra bằng
        /// </summary>
        /// <param name="x">Container 1</param>
        /// <param name="y">Container 2</param>
        public bool Equals(ByteContainer? x, ByteContainer? y)
        {
            if (x == null && y == null) return true;
            if (x != null && y != null)
            {
                var isEqual = x.Items.SequenceEqual(y.Items)
                    && x.Bits.Equals(y.Bits)
                    && x.ArraySizes.SequenceEqual(y.ArraySizes)
                    && x.Arrays.Count == y.Arrays.Count;

                var xArr = x.Arrays.GetEnumerator();
                var yArr = y.Arrays.GetEnumerator();
                while (xArr.MoveNext() && yArr.MoveNext())
                {
                    isEqual = xArr.Current.SequenceEqual(yArr.Current);
                }
                return isEqual;
            }
            return false;
        }

        /// <summary>
        /// Lấy mã băm
        /// </summary>
        /// <param name="obj">Container</param>
        public int GetHashCode([DisallowNull] ByteContainer obj)
        {
            var hashcode = HashCode.Combine(Items, Bits, ArraySizes, Arrays);
            return hashcode;
        }
    }
}
