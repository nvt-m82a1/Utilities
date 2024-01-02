﻿using Utilities.Container.Buildin;

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
            };

            var writer = new TypeWriter();
            writer.AddClass(data);

            var bytes = writer.Container.Export();
            var reader = new TypeReader(bytes.ToArray());
            var bytes2 = reader.Container.Export();

            var instance = new Data();
            reader.FillInstance(instance);

            Console.WriteLine("same bytes output: " + bytes.SequenceEqual(bytes2));

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}