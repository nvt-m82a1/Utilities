namespace Utilities.Container.Storage
{
    /// <summary>
    /// Một bản lưu trữ dữ liệu
    /// </summary>
    public class BackupItem
    {
        /// <summary>
        /// Số lượng bản ghi tối đa
        /// </summary>
        public int Total { get; protected set; }

        /// <summary>
        /// Số lượng bản ghi hiện tại
        /// </summary>
        public int Count { get; protected set; }

        /// <summary>
        /// Vị trí bản ghi mới nhất
        /// </summary>
        public int Index { get; protected set; }

        /// <summary>
        /// Đã ghi đủ tất cả số lượng bản ghi
        /// </summary>
        public bool Filled => Count == Total;

        /// <summary>
        /// Dữ liệu bản ghi
        /// </summary>
        public byte[]?[] Data { get; protected set; }

        /// <summary>
        /// Thời gian lưu bản ghi
        /// </summary>
        public long[] Timestamp { get; protected set; }

        public BackupItem(int numberOfBackup)
        {
            Total = numberOfBackup;
            Index = -1;
            Data = new byte[]?[numberOfBackup];
            Timestamp = new long[numberOfBackup];
        }

        /// <summary>
        /// Tính vị trí index mới so với vị trí index hiện tại
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        protected int GetIndex(int index, int offset)
        {
            return (index + Total + offset) % Total;
        }

        /// <summary>
        /// Thêm một bản
        /// </summary>
        /// <param name="data">Dữ liệu</param>
        /// <returns>Thành công (True)</returns>
        public bool Add(byte[]? data)
        {
            if (Total == 0) return false;

            Index++;
            if (Count < Total) Count++;
            if (Index >= Total)
            {
                Index = 0;
            }

            Data[Index] = data;
            Timestamp[Index] = DateTime.Now.Ticks;

            return true;
        }

        /// <summary>
        /// Lấy một bản
        /// </summary>
        /// <param name="reverseIndex">Số thứ tự, 0 là bản mới nhất</param>
        /// <returns>Dữ liệu</returns>
        public byte[]? Get(int reverseIndex)
        {
            if (Total == 0 || reverseIndex >= Count) return null;

            var targetIndex = GetIndex(Index, -reverseIndex);

            return Data[targetIndex];
        }

        /// <summary>
        /// Lấy một bản trước thời điểm
        /// </summary>
        /// <param name="timestamp">Thời điểm</param>
        /// <param name="reverseIndex">Số thứ tự, 0 là bản trước timestamp</param>
        /// <returns></returns>
        public byte[]? Get(long timestamp, int reverseIndex = 0)
        {
            if (Total == 0 || reverseIndex >= Count) return null;

            var iterIndex = Index;
            var iterCount = 0;

            for (var i = 0; i < Count; i++)
            {
                if (Timestamp[iterIndex] > timestamp)
                {
                    iterIndex = GetIndex(iterIndex, -1);
                    iterCount++;
                }
                else break;
            }

            if (iterCount + reverseIndex >= Count) return null;
            if (!Filled && iterIndex - reverseIndex < 0) return null;

            var targetIndex = GetIndex(iterIndex, -reverseIndex);
            return Data[targetIndex];
        }
    }
}
