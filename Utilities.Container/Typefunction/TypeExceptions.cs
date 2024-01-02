namespace Utilities.Container.Typefunction
{
    /// <summary>
    /// I. Không tìm thấy kiểu dữ liệu chuyển đổi
    /// <para>1. Thêm tên định dạng -> <see cref="Utilities.Container.Datatype.Types"/></para>
    /// <para>2. Thêm bộ chuyển đổi -> <see cref="Utilities.Container.Converter.TypeConvert.ItemToBytes"/></para>
    /// 
    /// II. Kiểu dữ liệu
    /// <para>1. Thêm dữ liệu CType -> <see cref="Utilities.Container.Datatype.TypesRead.FillCType"/></para>
    /// <para>2. Cập nhật bộ ghi, ví dụ -> <see cref="Utilities.Container.Buildin.TypeWriter"/></para>
    /// <para>3. Cập nhật bộ đọc, ví dụ -> <see cref="Utilities.Container.Buildin.TypeReader"/></para>
    /// 
    /// III. Kiểu dữ liệu động
    /// <para>1. Thêm dữ liệu CType -> <see cref="Utilities.Container.Converter.TypeBinding"/></para>
    /// </summary>
    public class TypeNotfoundException : Exception
    {
        public TypeNotfoundException(string message) : base(message) { }
    }
}
