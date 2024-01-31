## Một số công cụ lưu trữ và phục hồi dữ liệu.

### 1. Container
Chuyển dữ liệu sang bytes và phục hồi lại dữ liệu ban đầu.
```csharp
var container = new DataContainer();
container.AddLength(20);
container.AddBoolean(true);
container.AddArray(new byte[] { 12, 23, 34 });
var bytes = container.Export().ToArray();

var container_restore = new DataContainer();
container_restore.Import(bytes);
```
### 2. Converter
Chuyển một kiểu dữ liệu sang bytes và phục hồi lại dữ liệu.
```csharp
var item = new ItemType();
var data = DataConvert.Instance.GetBytes(item);
var item_restore = DataConvert.Instance.GetItem<ItemType>(data);
```
### 3. Stage
Chuyển đổi trạng thái của một đối tượng.
```csharp
var status = new Status()
{
    input = "data"
};
var history = new UndoRedoItem(status, 10);

status.input = "data update 1"; history.Commit();
status.input = "data update 2"; history.Commit();

history.Undo();
// status.input == "data update 1"
history.Redo();
// status.input == "data update 2"
```
### 4. Storage
Lưu trữ dữ liệu backup
```csharp
Autosave.Instance.Create("autosave1", () => 123, 10, 5);

var backup = new Backup();
backup.Setup("backup1", 5);
backup.Add("backup1", "data 1");
backup.Add("backup1", "data 2");
```
