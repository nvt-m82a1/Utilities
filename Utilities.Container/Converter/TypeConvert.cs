using System.Collections;
using System.Text;
using Utilities.Container.BaseType;
using Utilities.Container.Option;

namespace Utilities.Container.Converter
{
    /// <summary>
    /// Bộ chuyển đổi dữ liệu
    /// </summary>
    public class TypeConvert
    {
        public static TypeConvert Instance = new TypeConvert();
        private TypeConvert() { }

        /// <summary>
        /// Chuyển dữ liệu sang định dạng bytes
        /// </summary>
        /// <exception cref="TypeConvertException"></exception>
        public byte[]? ItemToBytes(TypeInfo type, object? data)
        {
            if (data == null) return null;

            switch (type.FullName)
            {
                case TypesName.FullName.Boolean:
                    return [(bool)data ? (byte)1 : (byte)0];

                case TypesName.FullName.Byte:
                    return [(byte)data];

                case TypesName.FullName.SByte:
                    return [unchecked((byte)(sbyte)data)];

                case TypesName.FullName.Char:
                    return BitConverter.GetBytes((char)data);

                case TypesName.FullName.Int16:
                    return BitConverter.GetBytes((short)data);

                case TypesName.FullName.UInt16:
                    return BitConverter.GetBytes((ushort)data);

                case TypesName.FullName.Int32:
                    return BitConverter.GetBytes((int)data);

                case TypesName.FullName.UInt32:
                    return BitConverter.GetBytes((uint)data);

                case TypesName.FullName.Single:
                    return BitConverter.GetBytes((float)data);

                case TypesName.FullName.Double:
                    return BitConverter.GetBytes((double)data);

                case TypesName.FullName.Int64:
                    return BitConverter.GetBytes((long)data);

                case TypesName.FullName.UInt64:
                    return BitConverter.GetBytes((ulong)data);

                case TypesName.FullName.Decimal:
                    {
                        var ints = decimal.GetBits((decimal)data);
                        var bytes = ints.SelectMany(BitConverter.GetBytes);
                        return bytes.ToArray();
                    }

                case TypesName.FullName.String:
                    {
                        var bytes = Encoding.UTF8.GetBytes((string)data);
                        var len = BitConverter.GetBytes(bytes.Length);
                        return len.Concat(bytes).ToArray();
                    }

                case TypesName.FullName.DateTime:
                    {
                        var datetime = ((DateTime)data).ToBinary();
                        return BitConverter.GetBytes(datetime);
                    }

                case TypesName.FullName.Guid:
                    return ((Guid)data).ToByteArray();
            }

            throw new TypeConvertException(message: type.FullName);
        }

        /// <summary>
        /// Chuyển mảng sang định dạng byte
        /// </summary>
        /// <exception cref="TypeConvertException"></exception>
        public IEnumerable<byte[]> ArrayToBytes(TypeInfo type, object? arr)
        {
            if (arr == null || arr is not IEnumerable) yield break;

            foreach (var item in (IEnumerable)arr)
            {
                yield return ItemToBytes(type, item)!;
            }
        }

        /// <summary>
        /// Duyệt mảng bytes và trả về item
        /// </summary>
        /// <param name="type"></param>
        /// <param name="length"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <returns>IEnumerable?</returns>
        /// <exception cref="TypeConvertException"></exception>
        public object? BytesToArray(TypeInfo type, int length, byte[]? buffer, int offset)
        {
            if (buffer == null) return null;

            switch (type.FullName)
            {
                case TypesName.FullName.Boolean:
                    {
                        return Enumerable.Range(0, length)
                                .Select(i => buffer![offset + i * sizeof(bool)] == 1);
                    }

                case TypesName.FullName.Byte:
                    {
                        return Enumerable.Range(0, length)
                                .Select(i => buffer![offset + i * sizeof(byte)]);
                    }

                case TypesName.FullName.SByte:
                    {
                        return Enumerable.Range(0, length)
                                .Select(i => (sbyte)buffer![offset + i * sizeof(sbyte)]);
                    }

                case TypesName.FullName.Char:
                    {
                        return Enumerable.Range(0, length)
                                .Select(i => BitConverter.ToChar(buffer!, offset + i * sizeof(char)));
                    }

                case TypesName.FullName.Int16:
                    {
                        return Enumerable.Range(0, length)
                                .Select(i => BitConverter.ToInt16(buffer!, offset + i * sizeof(short)));
                    }

                case TypesName.FullName.UInt16:
                    {
                        return Enumerable.Range(0, length)
                                .Select(i => BitConverter.ToUInt16(buffer!, offset + i * sizeof(ushort)));
                    }

                case TypesName.FullName.Int32:
                    {
                        return Enumerable.Range(0, length)
                                .Select(i => BitConverter.ToInt32(buffer!, offset + i * sizeof(int)));
                    }

                case TypesName.FullName.UInt32:
                    {
                        return Enumerable.Range(0, length)
                                .Select(i => BitConverter.ToUInt32(buffer!, offset + i * sizeof(uint)));
                    }

                case TypesName.FullName.Single:
                    {
                        return Enumerable.Range(0, length)
                                .Select(i => (float)BitConverter.ToSingle(buffer!, offset + i * sizeof(float)));
                    }

                case TypesName.FullName.Double:
                    {
                        return Enumerable.Range(0, length)
                                .Select(i => (double)BitConverter.ToDouble(buffer!, offset + i * sizeof(double)));
                    }

                case TypesName.FullName.Int64:
                    {
                        return Enumerable.Range(0, length)
                                .Select(i => BitConverter.ToInt64(buffer!, offset + i * sizeof(long)));
                    }

                case TypesName.FullName.UInt64:
                    {
                        return Enumerable.Range(0, length)
                                .Select(i => BitConverter.ToUInt64(buffer!, offset + i * sizeof(ulong)));
                    }

                case TypesName.FullName.Decimal:
                    {
                        return Enumerable.Range(0, length)
                                .Select(i => new decimal(new int[]
                                {
                                    BitConverter.ToInt32(buffer!, offset + i * sizeof(decimal)),
                                    BitConverter.ToInt32(buffer!, offset + i * sizeof(decimal) + 4),
                                    BitConverter.ToInt32(buffer!, offset + i * sizeof(decimal) + 8),
                                    BitConverter.ToInt32(buffer!, offset + i * sizeof(decimal) + 12),
                                }));
                    }

                case TypesName.FullName.String:
                    {
                        var strOffset = offset;

                        return Enumerable.Range(0, length)
                            .Select(i =>
                            {
                                var len = BitConverter.ToInt32(buffer, strOffset);
                                var str = Encoding.UTF8.GetString(buffer, strOffset + 4, len);
                                strOffset += 4 + len;
                                return str;
                            });
                    }

                case TypesName.FullName.DateTime:
                    {
                        return Enumerable.Range(0, length)
                                .Select(i => DateTime.FromBinary(BitConverter.ToInt64(buffer, offset + i * sizeof(long))));
                    }

                case TypesName.FullName.Guid:
                    {
                        return Enumerable.Range(0, length)
                            .Select(i =>
                            {
                                var span = new ReadOnlySpan<byte>(buffer, offset + i * 16, 16);
                                return new Guid(span.ToArray());
                            });
                    }

                default:
                    throw new TypeConvertException(message: type.FullName);
            }
        }

    }
}
