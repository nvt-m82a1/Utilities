## Data binary serialization

**Supported data types**
- Buildin: int, string, guid, datetime, ...
- List: list, array, dictionary, ...
- Class
- Support circular references

### Convert class data to bytes and restore the object
```csharp
var item = new ItemType();
var data = DataConvert.Instance.GetBytes(item);
var item_restore = DataConvert.Instance.GetItem<ItemType>(data);
```
