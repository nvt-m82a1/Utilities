namespace Utilities.Container.Base
{
    /// <summary>
    /// Một đối tượng là container
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public interface IContainer<TData>
    {
        /// <summary>
        /// Tổng số lượng đối tượng
        /// </summary>
        public int TotalElements { get; }

        /// <summary>
        /// Tổng số lượng byte khi export dữ liệu
        /// </summary>
        public int TotalExportBytes { get; }

        /// <summary>
        /// Xuất mảng dữ liệu
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TData> Export();

        /// <summary>
        /// Nhập mảng dữ liệu
        /// </summary>
        /// <param name="buffer">Mảng dữ liệu</param>
        /// <param name="start">Vị trí bắt đầu</param>
        /// <returns>Vị trí bắt đầu tiếp theo</returns>
        public int Import(TData[] buffer, int start = 0);
    }
}
