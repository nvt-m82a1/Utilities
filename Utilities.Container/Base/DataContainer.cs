using System.Diagnostics.CodeAnalysis;

namespace Utilities.Container.Base
{
    public class DataContainer<TSelf> :
        IContainer<byte>,
        IEquatable<DataContainer<TSelf>>,
        IEqualityComparer<DataContainer<TSelf>> where TSelf : DataContainer<TSelf>, new()
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

        public DataContainer()
        {
            Bits = new BitContainer();
            Bytes = new ByteContainer();
            SubContainers = new List<TSelf>();
        }

        public virtual void AddContainer(TSelf container)
        {
            SubContainers.Add(container);
        }

        public virtual TSelf? ReadContainer()
        {
            if (SubContainerIter >= SubContainers.Count) return null;
            var container = SubContainers[SubContainerIter];
            SubContainerIter++;
            return container;
        }

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

        public int Import(byte[] buffer, int start = 0)
        {
            var length = BitConverter.ToInt32(buffer, start);
            if (length == 0)
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

        public bool Equals(DataContainer<TSelf>? other)
        {
            return this.Equals(this, other);
        }

        public bool Equals(DataContainer<TSelf>? x, DataContainer<TSelf>? y)
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

        public int GetHashCode([DisallowNull] DataContainer<TSelf> obj)
        {
            var hashcode = HashCode.Combine(Bits, Bytes, SubContainers);
            foreach (var item in SubContainers) hashcode ^= item.GetHashCode();
            return hashcode;
        }
    }
}
