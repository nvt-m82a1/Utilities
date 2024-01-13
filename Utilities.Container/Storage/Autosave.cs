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
        protected ConcurrentDictionary<string, string> mapException;
        protected CancellationTokenSource cts;

        /// <summary>
        /// Lưu, nhập xuất dữ liệu
        /// </summary>
        public Backup Backup { get; private set; }

        public Autosave()
        {
            mapTimer = new();
            mapKey = new();
            mapException = new();
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
        public bool Create<T>(string key, Func<T?> getValue, int timeInterval = 10, int numberOfBackup = 1)
        {
            if (mapKey.ContainsKey(key)) return false;

            Func<object?> actionGetValue = () => getValue();
            mapKey[key] = (timeInterval, actionGetValue);

            if (!mapTimer.ContainsKey(timeInterval))
            {
                Backup.Setup(key, numberOfBackup);

                var newTimer = new PeriodicTimer(TimeSpan.FromSeconds(timeInterval));
                var newList = new List<string> { key };

                var timerPair = new KeyValuePair<int, List<string>>(timeInterval, newList);
                mapTimer.TryAdd(timerPair.Key, timerPair.Value);

                var value = actionGetValue.Invoke();
                Backup.Add(key, value);

                Task.Factory.StartNew(async () =>
                {
                    while (await newTimer.WaitForNextTickAsync(cts.Token))
                    {
                        if (newList.Count == 0)
                        {
                            mapTimer.TryRemove(timerPair);
                            newTimer.Dispose();
                            break;
                        }

                        for (var i = 0; i < newList.Count; i++)
                        {
                            var (itemTimeInterval, itemActionGetValue) = mapKey[newList[i]];
                            var itemValue = itemActionGetValue.Invoke();
                            Backup.Add(newList[i], itemValue);
                        }
                    }
                });
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
        /// <returns></returns>
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

            var keyPair = new KeyValuePair<string, (int, Func<object?>)>(key, mapKey[key]);
            mapKey.TryRemove(keyPair);
        }
    }
}
