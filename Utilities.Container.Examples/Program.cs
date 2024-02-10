using Utilities.Container.Converter;
using Utilities.Container.Examples;

var data = new Data();
// buildin types
data.Id = 1;
data.Name = "data";
data.CreatedTime = DateTime.Now;
data.Guid = Guid.NewGuid();
data.DataType = DataType.Type1;

// reference types
data.Pairs = new Dictionary<Data2, Data3>();
var data2 = new Data2();
var data3 = new Data3();
data2.Parent = data;
data2.Item3 = data3;
data3.Parent = data;
data3.Item2 = data2;
data.Pairs.Add(data2, data3);

// output
var bytes = DataConvert.Instance.GetBytes(data)!;

// get data reverse
var data_reverse = DataConvert.Instance.GetItem<Data>(bytes)!;
var data_reverse_bytes = DataConvert.Instance.GetBytes(data_reverse)!;

// compares
bool sameValue = data.Id == data_reverse.Id
    && data.Name == data_reverse.Name
    && data.CreatedTime.Equals(data_reverse.CreatedTime)
    && data.Guid.Equals(data_reverse.Guid)
    && data.DataType == data_reverse.DataType
    && data.Pairs.Count == data_reverse.Pairs.Count;

var sameOutput = bytes.SequenceEqual(data_reverse_bytes);

Console.WriteLine("Same: " + sameValue);
Console.WriteLine("Same output: " + sameOutput);
