Container lưu dữ liệu dưới dạng mảng bytes.
Container có thể xuất và phục hồi lại dữ liệu đã lưu trữ.

<code>
var container = new DataContainer();
container.AddLength(20);
container.AddBoolean(true);
container.AddArray(new byte[] { 1, 2, 3 });
</code>


Data convert chuyển dữ liệu của class hoặc mảng thành chuỗi bytes.
Chuỗi bytes có thể phục hồi lại thành class hoặc mảng.

<code>
var data = DataConvert.Instance.GetBytes(item);
var item_restore = DataConvert.Instance.GetItem<item_type>(data);
</code>
