using System.Text;
using Utilities.Container.Datatype;
using Utilities.Container.Typefunction;

namespace Utilities.Container.Converter
{
    public class TypeConvert
    {
        public static TypeConvert Instance = new TypeConvert();
        private TypeConvert() { }

        /// <summary>
        /// Chuyển dữ liệu sang định dạng bytes
        /// </summary>
        /// <exception cref="TypeNotfoundException"></exception>
        public byte[]? ItemToBytes(CType ctype, object? data)
        {
            if (data == null) return null;

            switch (ctype.FullName)
            {
                case Types.FullName.Boolean:
                    return [(bool)data ? (byte)1 : (byte)0];

                case Types.FullName.Byte:
                    return [(byte)data];

                case Types.FullName.SByte:
                    return [unchecked((byte)((sbyte)data))];

                case Types.FullName.Char:
                    return BitConverter.GetBytes((char)data);

                case Types.FullName.Int16:
                    return BitConverter.GetBytes((short)data);

                case Types.FullName.UInt16:
                    return BitConverter.GetBytes((ushort)data);

                case Types.FullName.Int32:
                    return BitConverter.GetBytes((int)data);

                case Types.FullName.UInt32:
                    return BitConverter.GetBytes((uint)data);

                case Types.FullName.Single:
                    return BitConverter.GetBytes((float)data);

                case Types.FullName.Double:
                    return BitConverter.GetBytes((double)data);

                case Types.FullName.Int64:
                    return BitConverter.GetBytes((long)data);

                case Types.FullName.Decimal:
                    {
                        var ints = decimal.GetBits((decimal)data);
                        var bytes = ints.SelectMany(BitConverter.GetBytes);
                        return bytes.ToArray();
                    }

                case Types.FullName.String:
                    {
                        var bytes = Encoding.UTF8.GetBytes((string)data);
                        var len = BitConverter.GetBytes(bytes.Length);
                        return len.Concat(bytes).ToArray();
                    }

                case Types.FullName.DateTime:
                    {
                        var datetime = ((DateTime)data).ToBinary();
                        return BitConverter.GetBytes(datetime);
                    }

                case Types.FullName.Guid:
                    return ((Guid)data).ToByteArray();
            }

            throw new TypeNotfoundException(message: ctype.FullName);
        }
    }
}
