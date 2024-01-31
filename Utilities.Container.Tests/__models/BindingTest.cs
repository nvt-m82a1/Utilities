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

        public enum EnumByte : Byte
        {
            Item0 = Byte.MinValue,
            Item1 = 100,
            Item2 = Byte.MaxValue,
        }

        public enum EnumSByte : SByte
        {
            Item0 = SByte.MinValue,
            Item1 = 10,
            Item2 = SByte.MaxValue,
        }

        public enum EnumInt16 : Int16
        {
            Item0 = Int16.MinValue,
            Item1 = 10000,
            Item2 = Int16.MaxValue,
        }

        public enum EnumInt32 : Int32
        {
            Item0 = Int32.MinValue,
            Item1 = 100000,
            Item2 = Int32.MaxValue,
        }

        public enum EnumInt64 : Int64
        {
            Item0 = Int64.MinValue,
            Item1 = 1000000,
            Item2 = Int64.MaxValue,
        }

        public enum EnumUInt16 : UInt16
        {
            Item0 = UInt16.MinValue,
            Item1 = 32000,
            Item2 = UInt16.MaxValue,
        }

        public enum EnumUInt32 : UInt32
        {
            Item0 = UInt32.MinValue,
            Item1 = 32000,
            Item2 = UInt32.MaxValue,
        }

        public enum EnumUInt64 : UInt64
        {
            Item0 = UInt64.MinValue,
            Item1 = 320000000,
            Item2 = UInt64.MaxValue,
        }
    }
}
