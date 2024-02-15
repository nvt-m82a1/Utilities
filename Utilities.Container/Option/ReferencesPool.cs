namespace Utilities.Container.Option
{
    /// <summary>
    /// Chứa địa chỉ reference và chỉ số
    /// </summary>
    public class ReferencesPool
    {
        /// <summary>
        /// Map địa chỉ của đối tượng sang chỉ số
        /// </summary>
        private readonly Dictionary<object, int> refId = new();
        private readonly Dictionary<int, object> refIdReverse = new();

        /// <summary>
        /// Tìm chỉ số của đối tượng
        /// </summary>
        /// <param name="obj">Đối tượng</param>
        public (bool Found, int Index) FindValue(object obj)
        {
            if (!refId.ContainsKey(obj))
            {
                var index = refId.Count;
                refId.Add(obj, index);
                refIdReverse.Add(index, obj);
                return (false, -1);
            }

            return (true, refId[obj]);
        }

        /// <summary>
        /// Lấy giá trị từ chỉ số
        /// </summary>
        /// <param name="index">Chỉ số</param>
        public object? GetValue(int index)
        {
            if (refIdReverse.ContainsKey(index))
            {
                return refIdReverse[index];
            }

            return null;
        }
    }
}
