using System.Collections.Concurrent;
using Utilities.Container.Converter;
using Utilities.Container.Option;

namespace Utilities.Container.Storage
{
    /// <summary>
    /// Tập hợp những bản lưu trữ dữ liệu
    /// </summary>
    [ClassContainer]
    public class Backup
    {
        public static Backup Instance = new Backup();

        protected ConcurrentDictionary<string, BackupItem> mapKey;
        protected ConcurrentDictionary<string, string?> mapException;

        public Backup()
        {
            mapKey = new();
            mapException = new();
        }

        /// <summary>
        /// Tạo một bản lưu trữ dữ liệu
        /// </summary>
        /// <param name="key">Khóa</param>
        /// <param name="numberOfBackup">Số lượng lưu trữ</param>
        /// <returns></returns>
        public bool Setup(string key, int numberOfBackup)
        {
            if (!mapKey.ContainsKey(key))
            {
                mapKey[key] = new BackupItem(numberOfBackup);
                mapException[key] = null;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Thêm dữ liệu vào bản lưu trữ
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <param name="key">Khóa</param>
        /// <param name="value">Dữ liệu</param>
        /// <returns>Thành công (True), hoặc xảy ra lỗi (False)</returns>
        public bool Add<T>(string key, T value)
        {
            if (mapKey.ContainsKey(key))
            {
                try
                {
                    var backupItem = mapKey[key];
                    var bytes = DataConvert.Instance.GetBytes(value);
                    backupItem.Add(bytes);
                    return true;
                }
                catch (Exception ex)
                {
                    mapException[key] = ex.ToString();
                }
            }

            return false;
        }

        /// <summary>
        /// Thêm dữ liệu là một bản ghi backup
        /// </summary>
        /// <param name="key">Khóa</param>
        /// <param name="data">Bản ghi backup</param>
        /// <returns></returns>
        public bool Import(string key, byte[] data)
        {
            if (mapKey.ContainsKey(key))
            {
                var backupItem = mapKey[key];
                backupItem.Add(data);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lấy một bản ghi backup
        /// </summary>
        /// <param name="key">Khóa</param>
        /// <param name="reverseIndex">Số thứ tự, 0 là bản nhất</param>
        /// <returns></returns>
        public byte[]? Export(string key, int reverseIndex = 0)
        {
            if (mapKey.ContainsKey(key))
            {
                return mapKey[key].Get(reverseIndex);
            }
            return null;
        }

        /// <summary>
        /// Lấy một bản ghi backup trước thời điểm
        /// </summary>
        /// <param name="key">Khóa</param>
        /// <param name="timestamp">Thời điểm</param>
        /// <param name="reverseIndex">Số thứ tự</param>
        /// <returns></returns>
        public byte[]? Export(string key, long timestamp, int reverseIndex = 0)
        {
            if (mapKey.ContainsKey(key))
            {
                return mapKey[key].Get(timestamp, reverseIndex);
            }
            return null;
        }

        /// <summary>
        /// Lấy một bản lưu trữ là một class
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <param name="key">Khóa</param>
        /// <param name="reverseIndex">Số thứ tự, 0 là bản nhất</param>
        /// <returns></returns>
        public T? Get<T>(string key, int reverseIndex = 0)
        {
            var backupItem = mapKey[key];
            var bytes = backupItem.Get(reverseIndex);
            var item = DataConvert.Instance.GetItem<T?>(bytes);
            return item;
        }

        /// <summary>
        /// Lấy một bản lưu trữ là một class trước thời điểm
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <param name="key">Khóa</param>
        /// <param name="timestamp">Thời điểm</param>
        /// <param name="reverseIndex">Số thứ tự, 0 là bản nhất trước timestamp</param>
        /// <returns></returns>
        public T? Get<T>(string key, long timestamp, int reverseIndex = 0)
        {
            var backupItem = mapKey[key];
            var bytes = backupItem.Get(timestamp, reverseIndex);
            var item = DataConvert.Instance.GetItem<T?>(bytes);
            return item;
        }
    }
}
