using Utilities.Container.Converter;
using Utilities.Container.Storage;

namespace Utilities.Container.Stage
{
    /// <summary>
    /// Undo và redo một đối tượng
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu</typeparam>
    public class UndoRedoItem<T> : BackupItem where T : class
    {
        protected int RedoCount;
        protected int LatestIndex;
        protected T Item;

        public UndoRedoItem(T item, int numberOfBackup) : base(numberOfBackup)
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
            this.Add(bytes);

            LatestIndex = Index;
        }

        public new bool Add(byte[]? data)
        {
            RedoCount = 0;
            return base.Add(data);
        }

        /// <summary>
        /// Trở về trạng thái mới nhất
        /// </summary>
        public void Latest()
        {
            var bytes = Data[LatestIndex];
            DataBinding.Instance.WriteMembers(Item, bytes);
        }

        /// <summary>
        /// Trở về trạng thái phía trước
        /// </summary>
        public bool Undo()
        {
            if (Count <= 1) return false;

            Count--;
            RedoCount++;
            Index = GetIndex(Index, -1);

            var bytes = Data[Index];
            DataBinding.Instance.WriteMembers(Item, bytes);
            return true;
        }

        /// <summary>
        /// Trở về trạng thái phía sau
        /// </summary>
        public bool Redo()
        {
            if (RedoCount == 0) return false;

            Count++;
            RedoCount--;
            Index = GetIndex(Index, +1);

            var bytes = Data[Index];
            DataBinding.Instance.WriteMembers(Item, bytes);
            return true;
        }
    }
}
