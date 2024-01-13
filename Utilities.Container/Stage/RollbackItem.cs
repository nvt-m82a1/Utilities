using Utilities.Container.Converter;
using Utilities.Container.Storage;

namespace Utilities.Container.Stage
{
    /// <summary>
    /// Rollback một đối tượng
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu</typeparam>
    public class RollbackItem<T> : BackupItem where T : class
    {
        protected T Item;

        public RollbackItem(T item, int numberOfBackup) : base(numberOfBackup)
        {
            Item = item;
            Commit();
        }

        /// <summary>
        /// Lưu trạng thái hiện tại
        /// </summary>
        public void Commit()
        {
            var bytes = DataBinding.Instance.ReadMembers(Item);
            Add(bytes);
        }

        /// <summary>
        /// Trở về trạng thái phía trước
        /// </summary>
        public bool Rollback()
        {
            if (Count <= 1) return false;

            Count--;
            Index = GetIndex(Index, -1);

            var bytes = Data[Index];
            DataBinding.Instance.WriteMembers(Item, bytes);
            return true;
        }
    }
}
