using Utilities.Container.Option;

namespace Utilities.Container.Storage
{
    /// <summary>
    /// Một bản lưu trữ dữ liệu
    /// </summary>
    [ClassContainer]
    public class BackupItem
    {
        /// <summary>
        /// Số lượng bản ghi tối đa
        /// </summary>
        public int Total { get; private set; }

        /// <summary>
        /// Vị trí bản ghi mới nhất
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Đã ghi đủ tất cả số lượng bản ghi
        /// </summary>
        public bool Filled { get; private set; }

        /// <summary>
        /// Dữ liệu bản ghi
        /// </summary>
        public byte[]?[] Data { get; private set; }

        /// <summary>
        /// Thời gian lưu bản ghi
        /// </summary>
        public long[] Timestamp { get; private set; }

        public BackupItem(int numberOfBackup)
        {
            Total = numberOfBackup;
            Index = -1;
            Data = new byte[]?[numberOfBackup];
            Timestamp = new long[numberOfBackup];
        }

        /// <summary>
        /// Thêm một bản
        /// </summary>
        /// <param name="data">Dữ liệu</param>
        /// <returns>Thành công (True)</returns>
        public bool Add(byte[]? data)
        {
            Index++;
            if (Index >= Total)
            {
                Index = 0;
                Filled = true;
            }

            if (Total == 0) return false;
            Data[Index] = data;
            Timestamp[Index] = DateTime.Now.Ticks;

            return true;
        }

        /// <summary>
        /// Lấy một bản
        /// </summary>
        /// <param name="reverseIndex">Số thứ tự, 0 là bản nhất</param>
        /// <returns>Dữ liệu</returns>
        public byte[]? Get(int reverseIndex)
        {
            if (Total == 0 || reverseIndex > Total) return null;

            var targetIndex = (Index + Total - reverseIndex) % Total;

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
            if (Total == 0 || reverseIndex > Total) return null;

            // Chỉ số max index là Total - 1 nếu đã fill, hoặc Index nếu chưa fill
            var maxIndex = Filled ? Total - 1 : Index;

            var timestampIndex = Index;
            var timestampCount = 0;

            for (var i = 0; i <= maxIndex; i++)
            {
                if (Timestamp[timestampIndex] > timestamp)
                {
                    timestampIndex = (timestampIndex + Total - 1) % Total;
                    timestampCount++;
                }
                else break;
            }

            if (timestampCount + reverseIndex > maxIndex) return null;
            if (!Filled && timestampIndex - reverseIndex < 0) return null;
            
            var targetIndex = (timestampIndex + Total - reverseIndex) % Total;
            return Data[targetIndex];
        }
    }
}
