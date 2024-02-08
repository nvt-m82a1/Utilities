window.pagemodel = [
  {
    "name": "BitContainer",
    "description": "Xử lý dữ liệu boolean",
    "methods": [
      {
        "name": "void Add(bool data)",
        "description": "Thêm một dữ liệu boolean"
      },
      {
        "name": "void AddArray(IEnumerable<bool> data)",
        "description": "Thêm một mảng dữ liệu boolean"
      },
      {
        "name": "bool? Read()",
        "description": "Đọc một dữ liệu boolean"
      },
      {
        "name": "bool? Scan()",
        "description": "Quét một dữ liệu boolean"
      },
      {
        "name": "bool?[] ReadArray(int length)",
        "description": "Đọc một mảng boolean"
      },
      {
        "name": "void ReadReset()",
        "description": "Reset cờ đọc"
      },
      {
        "name": "void Clear()",
        "description": "Làm rỗng container"
      },
      {
        "name": "IEnumerable<byte> Export()",
        "description": "Xuất dữ liệu từ container"
      },
      {
        "name": "int Import(byte[] buffer, int start = 0)",
        "description": "Nhập dữ liệu vào container"
      }
    ]
  },
  {
    "name": "ByteContainer",
    "description": "Xử lý dữ liệu byte",
    "methods": [
      {
        "name": "void AddItem(byte data)",
        "description": "Thêm một dữ liệu byte"
      },
      {
        "name": "void AddItems(byte[] data)",
        "description": "Thêm một danh sách dữ liệu byte"
      },
      {
        "name": "void AddArray(IEnumerable<byte> data",
        "description": "Thêm một mảng dữ liệu"
      },
      {
        "name": "byte? ReadItem()",
        "description": "Đọc một dữ liệu byte"
      },
      {
        "name": "byte[] ReadItems(int length)",
        "description": "Đọc nhiều dữ liệu byte"
      },
      {
        "name": "byte[] ScanItems(int length)",
        "description": "Quét nhiều dữ liệu byte"
      },
      {
        "name": "(int, IEnumerable<byte>?) ReadArray()",
        "description": "Đọc một mảng dữ liệu"
      },
      {
        "name": "void ReadReset()",
        "description": "Reset thông tin đọc"
      },
      {
        "name": "void Clear()",
        "description": "Làm rỗng container"
      },
      {
        "name": "IEnumerable<byte> Export()",
        "description": "Xuất dữ liệu từ container"
      },
      {
        "name": "int Import(byte[] buffer, int start = 0)",
        "description": "Nhập dữ liệu vào container"
      }
    ]
  },
  {
    "name": "DataContainer",
    "description": "Xử lý dữ liệu data",
    "methods": [
      {
        "name": "void AddLength(int data)",
        "description": "Ghi một kích thước byte hoặc integer"
      },
      {
        "name": "int ReadLength()",
        "description": "Đọc một kích thước byte hoặc integer"
      },
      {
        "name": "int ScanLength()",
        "description": "Quét trước kích thước là một byte hoặc integer"
      },
      {
        "name": "void AddBoolean(bool data)",
        "description": "Ghi một giá trị boolean"
      },
      {
        "name": "bool? ReadBoolean()",
        "description": "Đọc một giá trị boolean"
      },
      {
        "name": "void AddBooleanArray(IEnumerable<bool> data)",
        "description": "Ghi một danh sách giá trị boolean"
      },
      {
        "name": "IEnumerable<bool?> ReadBooleanArray(int length)",
        "description": "Đọc một danh sách giá trị boolean"
      },
      {
        "name": "void AddArray(IEnumerable<byte> data)",
        "description": "Ghi một mảng dữ liệu"
      },
      {
        "name": "(int, IEnumerable<byte>?) ReadArray()",
        "description": "Đọc một mảng dữ liệu"
      }
    ]
  },
  {
    "name": "DataBinding",
    "description": "Đọc và ghi thành viên của class",
    "methods": [
      {
        "name": "byte[]? ReadMembers<T>(T item) where T : class",
        "description": "Đọc thuộc tính trong item"
      },
      {
        "name": "void WriteMembers<T>(T item, byte[]? data) where T : class",
        "description": "Ghi vào item những thuộc tính trong data"
      }
    ]
  },
  {
    "name": "DataConvert",
    "description": "Đọc và ghi một kiểu dữ liệu",
    "methods": [
      {
        "name": "byte[]? GetBytes<T>(T? data)",
        "description": "Lấy dữ liệu bytes từ data"
      },
      {
        "name": "T? GetItem<T>(byte[]? data)",
        "description": "Lấy giá trị trong data"
      }
    ]
  },
  {
    "name": "RollbackItem",
    "description": "Rollback một đối tượng",
    "methods": [
      {
        "name": "void Commit()",
        "description": "Lưu trạng thái hiện tại"
      },
      {
        "name": "bool Rollback()",
        "description": "Trở về trạng thái phía trước"
      }
    ]
  },
  {
    "name": "UndoRedoItem",
    "description": "Undo và redo một đối tượng",
    "methods": [
      {
        "name": "void Commit()",
        "description": "Lưu trạng thái hiện tại"
      },
      {
        "name": "void Latest()",
        "description": "Trở về trạng thái mới nhất"
      },
      {
        "name": "bool Undo()",
        "description": "Trở về trạng thái phía trước"
      },
      {
        "name": "bool Redo()",
        "description": "Trở về trạng thái phía sau"
      }
    ]
  },
  {
    "name": "Autosave",
    "description": "Tự động lưu dữ liệu",
    "methods": [
      {
        "name": "bool Create<T>(string key, Func<T?> getValue, int timeInterval = 10, int numberOfBackup = 1)",
        "description": "Thêm một luồng backup dữ liệu"
      },
      {
        "name": "T? Get<T>(string key, int reverseIndex = 0)",
        "description": "Lấy một bản dữ liệu"
      },
      {
        "name": "T? Get<T>(string key, long timestamp, int reverseIndex = 0)",
        "description": "Lấy một bản dữ liệu trước thời điểm"
      },
      {
        "name": "void Stop(string key)",
        "description": "Dừng một luồng sao lưu"
      }
    ]
  },
  {
    "name": "Backup",
    "description": "Tập hợp những bản lưu trữ dữ liệu",
    "methods": [
      {
        "name": "bool Setup(string key, int numberOfBackup)",
        "description": "Tạo một bản lưu trữ dữ liệu"
      },
      {
        "name": "bool Add<T>(string key, T value)",
        "description": "Thêm dữ liệu vào bản lưu trữ"
      },
      {
        "name": "bool Import(string key, byte[] data)",
        "description": "Thêm dữ liệu là một bản ghi backup"
      },
      {
        "name": "byte[]? Export(string key, int reverseIndex = 0)",
        "description": "Lấy một bản ghi backup"
      },
      {
        "name": "byte[]? Export(string key, long timestamp, int reverseIndex = 0)",
        "description": "Lấy một bản ghi backup trước thời điểm"
      },
      {
        "name": "T? Get<T>(string key, int reverseIndex = 0)",
        "description": "Lấy một bản lưu trữ là một class"
      },
      {
        "name": "T? Get<T>(string key, long timestamp, int reverseIndex = 0)",
        "description": "Lấy một bản lưu trữ là một class trước thời điểm"
      }
    ]
  }
]