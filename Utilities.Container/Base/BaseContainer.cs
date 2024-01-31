using System.Diagnostics.CodeAnalysis;

namespace Utilities.Container.Base
{
    /// <summary>
    /// Mẫu container lưu trữ dữ liệu
    /// </summary>
    /// <typeparam name="TSelf"></typeparam>
    public abstract class BaseContainer<TSelf> :
        IContainer<byte>,
        IEquatable<BaseContainer<TSelf>>,
        IEqualityComparer<BaseContainer<TSelf>> where TSelf : BaseContainer<TSelf>, new()
    {
        public int TotalElements => Bits.TotalElements + Bytes.TotalElements
            + SubContainers.Sum(sub => sub.TotalElements);
        public int TotalExportBytes
        {
            get
            {
                if (TotalElements == 0)
                    return 4;

                return 5 + Bits.TotalExportBytes + Bytes.TotalExportBytes
                    + SubContainers.Sum(sub => sub.TotalExportBytes);
            }
        }

        // Serialization data
        protected BitContainer Bits;
        protected ByteContainer Bytes;
        protected IList<TSelf> SubContainers;
        // End Serialization data

        // Read
        protected byte SubContainerIter;
        // End Read

        public BaseContainer()
        {
            Bits = new BitContainer();
            Bytes = new ByteContainer();
            SubContainers = new List<TSelf>();
        }

        /// <summary>
        /// Thêm một container
        /// </summary>
        /// <param name="container"></param>
        public virtual void AddContainer(TSelf container)
        {
            SubContainers.Add(container);
        }

        /// <summary>
        /// Đọc một container
        /// </summary>
        /// <returns></returns>
        public virtual TSelf? ReadContainer()
        {
            if (SubContainerIter >= SubContainers.Count) return null;
            var container = SubContainers[SubContainerIter];
            SubContainerIter++;
            return container;
        }

        /// <summary>
        /// Reset thông tin đọc
        /// </summary>
        public void ReadReset()
        {
            Bits.ReadReset();
            Bytes.ReadReset();
            foreach (var container in SubContainers)
            {
                container.ReadReset();
            }
        }

        /// <summary>
        /// Làm rỗng container
        /// </summary>
        public void Clear()
        {
            Bits.Clear();
            Bytes.Clear();
            foreach (var container in SubContainers)
            {
                container.Clear();
            }
        }

        /// <summary>
        /// Xuất dữ liệu từ container
        /// </summary>
        public IEnumerable<byte> Export()
        {
            var length = BitConverter.GetBytes(this.TotalExportBytes);
            if (this.TotalElements == 0)
                return length;

            var subContainerSize = (byte)SubContainers.Count();
            var bits = Bits.Export();
            var bytes = Bytes.Export();
            var subContainers = SubContainers.SelectMany(container => container.Export());

            return length
                .Concat([subContainerSize])
                .Concat(bits)
                .Concat(bytes)
                .Concat(subContainers);
        }

        /// <summary>
        /// Nhập dữ liệu vào container
        /// </summary>
        /// <param name="buffer">Mảng dữ liệu</param>
        /// <param name="start">Vị trí bắt đầu</param>
        public int Import(byte[] buffer, int start = 0)
        {
            var length = BitConverter.ToInt32(buffer, start);
            if (length == 4)
                return start + length;

            var subContainerSize = buffer[start + 4];
            var dataPivot = start + 5;

            dataPivot = Bits.Import(buffer, dataPivot);
            dataPivot = Bytes.Import(buffer, dataPivot);

            for (int i = 0; i < subContainerSize; i++)
            {
                var dataContainer = new TSelf();
                dataPivot = dataContainer.Import(buffer, dataPivot);
                SubContainers.Add(dataContainer);
            }

            return start + length;
        }

        /// <summary>
        /// Kiểm tra bằng
        /// </summary>
        /// <param name="other">Container khác</param>
        public bool Equals(BaseContainer<TSelf>? other)
        {
            return this.Equals(this, other);
        }

        /// <summary>
        /// Kiểm tra bằng
        /// </summary>
        /// <param name="x">Container 1</param>
        /// <param name="y">Container 2</param>
        public bool Equals(BaseContainer<TSelf>? x, BaseContainer<TSelf>? y)
        {
            if (x == null && y == null) return true;
            if (x != null && y != null)
            {
                return x.Bits.Equals(y.Bits)
                    && x.Bytes.Equals(y.Bytes)
                    && x.SubContainers.SequenceEqual(y.SubContainers);
            }
            return false;
        }

        /// <summary>
        /// Lấy mã băm
        /// </summary>
        /// <param name="obj">Container</param>
        public int GetHashCode([DisallowNull] BaseContainer<TSelf> obj)
        {
            var hashcode = HashCode.Combine(Bits, Bytes, SubContainers);
            foreach (var item in SubContainers) hashcode ^= item.GetHashCode();
            return hashcode;
        }
    }
}
