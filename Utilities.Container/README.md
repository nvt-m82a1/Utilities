## Lưu trữ và phục hồi dữ liệu.

**Kiểu dữ liệu hỗ trợ**
- Dữ liệu có sẵn: int, string, guid, datetime, ...
- Dữ liệu danh sách: list, array, dictionary, ...
- Dữ liệu class
- Hỗ trợ tham chiếu lặp

### Chuyển dữ liệu kiểu class sang bytes và phục hồi lại đối tượng.
```csharp
var item = new ItemType();
var data = DataConvert.Instance.GetBytes(item);
var item_restore = DataConvert.Instance.GetItem<ItemType>(data);
```
