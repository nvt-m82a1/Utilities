using Utilities.Container.Base;
using Utilities.Container.Converter;

namespace Utilities
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var data = new Data()
            {
                a = 4568745,
                b = "abcd",
                e = new Data2 { c = 6786456, d = "wqe4r543asdf5" },
                f = 4567867,
                g = new Data2 { c = 5467867, d = "w65e4r6sdf654" },
                h = 8665145,
                j = [true, false, true],
                k = DataEnum.No1,
                m = [DataEnum.No1, DataEnum.No2, DataEnum.No0, DataEnum.No1]
            };
            data.ref_this = data;

            var bytes = DataConvert.Instance.GetBytes(data);
            var data2 = DataConvert.Instance.GetItem<Data>(bytes!);
            var bytes2 = DataConvert.Instance.GetBytes(data2);

            Console.WriteLine("same bytes output: " + bytes.SequenceEqual(bytes2));

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
