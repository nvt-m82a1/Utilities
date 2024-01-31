using static Utilities.Container.Tests.__models.DataTest;

namespace Utilities.Container.Tests.__models
{
    internal class BindingTest
    {
        public class Item1Field
        {
            public int? Id;
        }

        public class Item1Prop
        {
            public int? Id { get; set; }
        }

        public class  Item2
        {
            public string? Name;
            public string? Address { get; set; }
        }

        public class Buildin1
        {
            public Boolean? Boolean;
            public Byte? Byte;
            public SByte? SByte;
            public Char? Char;
            public Int16? Int16;
            public UInt16? UInt16;
            public Int32? Int32;
            public UInt32? UInt32;
            public Single? Single;
            public Double? Double;
            public Int64? Int64;
            public Decimal? Decimal;
            public String? String;
            public DateTime? DateTime;
            public Guid? Guid;

            public EnumByte? EnumByte;
            public EnumSByte? EnumSByte;
            public EnumInt16? EnumInt16;
            public EnumInt32? EnumInt32;
            public EnumInt64? EnumInt64;
            public EnumUInt16? EnumUInt16;
            public EnumUInt32? EnumUInt32;
            public EnumUInt64? EnumUInt64;
        }
    }
}
