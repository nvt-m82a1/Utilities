using System.Collections.Concurrent;

namespace Utilities.Container.Storage
{
    /// <summary>
    /// Tự động lưu dữ liệu
    /// </summary>
    public class Autosave
    {
        public static Autosave Instance = new Autosave();

        protected ConcurrentDictionary<string, (int, Func<object?>)> mapKey;
        protected ConcurrentDictionary<int, List<string>> mapTimer;
        protected CancellationTokenSource cts;

        /// <summary>
        /// Lưu, nhập xuất dữ liệu
        /// </summary>
        public Backup Backup { get; private set; }

        public Autosave()
        {
            mapTimer = new();
            mapKey = new();
            cts = new();
            Backup = new Backup();
        }

        ~Autosave()
        {
            cts.Cancel();
        }

        /// <summary>
        /// Thêm một luồng backup dữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <param name="key">Khóa</param>
        /// <param name="getValue">Hàm lấy dữ liệu</param>
        /// <param name="timeInterval">Thời gian tạo một bản lưu trữ, tính theo giây</param>
        /// <param name="numberOfBackup">Số lượng bản ghi backup</param>
        public bool Create<T>(string key, Func<T> getValue, int timeInterval = 10, int numberOfBackup = 1)
        {
            if (mapKey.ContainsKey(key)) return false;

            Func<object?> actionGetValue = () => getValue.Invoke();
            mapKey[key] = (timeInterval, actionGetValue);

            if (!mapTimer.ContainsKey(timeInterval))
            {
                Backup.Setup(key, numberOfBackup);

                var newList = new List<string> { key };

                mapTimer.TryAdd(timeInterval, newList);

                var value = actionGetValue.Invoke();
                Backup.Add(key, value);

                var timer = new System.Timers.Timer(timeInterval * 1000);
                timer.Elapsed += (sender, e) =>
                {
                    for (var i = 0; i < newList.Count; i++)
                    {
                        var (itemTimeInterval, actionGetValue) = mapKey[newList[i]];
                        var itemValue = actionGetValue.Invoke();
                        Backup.Add(newList[i], itemValue);
                    }

                    if (newList.Count == 0)
                    {
                        mapTimer.TryRemove(timeInterval, out _);
                        timer.Stop();
                        timer.Dispose();
                    }
                };
                timer.Start();
            }
            else
            {
                var list = mapTimer[timeInterval];
                if (!list.Contains(key))
                {
                    Backup.Setup(key, numberOfBackup);
                    list.Add(key);
                }

                var value = actionGetValue.Invoke();
                Backup.Add(key, value);
            }
            return true;
        }

        /// <summary>
        /// Lấy một bản dữ liệu
        /// </summary>
        /// <param name="key">Khóa</param>
        /// <param name="reverseIndex">Số thứ tự</param>
        public T? Get<T>(string key, int reverseIndex = 0)
        {
            return Backup.Get<T>(key, reverseIndex);
        }

        /// <summary>
        /// Lấy một bản dữ liệu trước thời điểm
        /// </summary>
        /// <param name="key">Khóa</param>
        /// <param name="timestamp">Thời điểm</param>
        /// <param name="reverseIndex">Số thứ tự</param>
        /// <returns></returns>
        public T? Get<T>(string key, long timestamp, int reverseIndex = 0)
        {
            return Backup.Get<T>(key, timestamp, reverseIndex);
        }

        /// <summary>
        /// Dừng một luồng sao lưu
        /// </summary>
        /// <param name="key">Khóa</param>
        public void Stop(string key)
        {
            if (!mapKey.ContainsKey(key)) return;
            var (timeInterval, actionGetValue) = mapKey[key];
            var list = mapTimer[timeInterval];
            list.Remove(key);

            mapKey.TryRemove(key, out _);
        }
    }
}
