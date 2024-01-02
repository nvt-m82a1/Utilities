using System.Collections;
using System.Text;
using Utilities.Container.Datatype;
using Utilities.Container.Typefunction;

namespace Utilities.Container.Converter
{
    public class TypeBinding
    {
        public static TypeBinding Instance = new TypeBinding();
        private TypeBinding() { }

        /// <summary>
        /// Chuyển array bytes sang một định dạng type
        /// </summary>
        /// <param name="ctype">Kiểu dữ liệu lưu trữ của array</param>
        /// <param name="length">Số lượng phần tử của array</param>
        /// <param name="buffer"></param>
        /// <param name="offset">Vị trí bắt đầu đọc dữ liệu trên buffer</param>
        /// <param name="OnArrayResult">Action trên mảng định dạng IEnumerable</param>
        /// <exception cref="TypeNotfoundException"></exception>
        public void ParseArray(CType ctype, int length, byte[]? buffer, int offset, Action<object?> OnArrayResult)
        {
            if (buffer == null)
            {
                OnArrayResult?.Invoke(null);
                return;
            }

            switch (ctype.FullName)
            {
                case Types.FullName.Boolean:
                    {
                        var arr = Enumerable.Range(0, length)
                                .Select(i => (Boolean)(buffer![offset + i * sizeof(Boolean)] == 0));
                        OnArrayResult?.Invoke(arr);
                        break;
                    }

                case Types.FullName.Byte:
                    {
                        var arr = Enumerable.Range(0, length)
                                .Select(i => (Byte)(buffer![offset + i * sizeof(Byte)]));
                        OnArrayResult?.Invoke(arr);
                        break;
                    }

                case Types.FullName.SByte:
                    {
                        var arr = Enumerable.Range(0, length)
                                .Select(i => (SByte)(buffer![offset + i * sizeof(SByte)]));
                        OnArrayResult?.Invoke(arr);
                        break;
                    }

                case Types.FullName.Char:
                    {
                        var arr = Enumerable.Range(0, length)
                                .Select(i => (Char)BitConverter.ToChar(buffer!, offset + i * sizeof(Char)));
                        OnArrayResult?.Invoke(arr);
                        break;
                    }

                case Types.FullName.Int16:
                    {
                        var arr = Enumerable.Range(0, length)
                                .Select(i => (Int16)BitConverter.ToInt16(buffer!, offset + i * sizeof(Int16)));
                        OnArrayResult?.Invoke(arr);
                        break;
                    }

                case Types.FullName.UInt16:
                    {
                        var arr = Enumerable.Range(0, length)
                                .Select(i => (UInt16)BitConverter.ToUInt16(buffer!, offset + i * sizeof(UInt16)));
                        OnArrayResult?.Invoke(arr);
                        break;
                    }

                case Types.FullName.Int32:
                    {
                        var arr = Enumerable.Range(0, length)
                                .Select(i => (Int32)BitConverter.ToInt32(buffer!, offset + i * sizeof(Int32)));
                        OnArrayResult?.Invoke(arr);
                        break;
                    }

                case Types.FullName.UInt32:
                    {
                        var arr = Enumerable.Range(0, length)
                                .Select(i => (UInt32)BitConverter.ToUInt32(buffer!, offset + i * sizeof(UInt32)));
                        OnArrayResult?.Invoke(arr);
                        break;
                    }

                case Types.FullName.Single:
                    {
                        var arr = Enumerable.Range(0, length)
                                .Select(i => (Single)BitConverter.ToSingle(buffer!, offset + i * sizeof(Single)));
                        OnArrayResult?.Invoke(arr);
                        break;
                    }

                case Types.FullName.Double:
                    {
                        var arr = Enumerable.Range(0, length)
                                .Select(i => (Double)BitConverter.ToDouble(buffer!, offset + i * sizeof(Double)));
                        OnArrayResult?.Invoke(arr);
                        break;
                    }

                case Types.FullName.Int64:
                    {
                        var arr = Enumerable.Range(0, length)
                                .Select(i => (Int64)BitConverter.ToInt64(buffer!, offset + i * sizeof(Int64)));
                        OnArrayResult?.Invoke(arr);
                        break;
                    }

                case Types.FullName.Decimal:
                    {
                        var arr = Enumerable.Range(0, length)
                                .Select(i => new decimal(new int[]
                                {
                                    BitConverter.ToInt32(buffer!, offset + i * sizeof(Decimal)),
                                    BitConverter.ToInt32(buffer!, offset + i * sizeof(Decimal) + 4),
                                    BitConverter.ToInt32(buffer!, offset + i * sizeof(Decimal) + 8),
                                    BitConverter.ToInt32(buffer!, offset + i * sizeof(Decimal) + 12),
                                }));
                        OnArrayResult?.Invoke(arr);
                        break;
                    }

                case Types.FullName.String:
                    {
                        var strOffset = offset;

                        var arr = Enumerable.Range(0, length)
                            .Select(i =>
                            {
                                var len = BitConverter.ToInt32(buffer, strOffset);
                                var str = Encoding.UTF8.GetString(buffer, strOffset + 4, len);
                                strOffset += 4 + len;
                                return str;
                            });
                        OnArrayResult?.Invoke(arr);
                        break;
                    }

                case Types.FullName.DateTime:
                    {
                        var arr = Enumerable.Range(0, length)
                                .Select(i => DateTime.FromBinary(BitConverter.ToInt64(buffer, offset + i * sizeof(Int64))));
                        OnArrayResult?.Invoke(arr);
                        break;
                    }

                case Types.FullName.Guid:
                    {
                        var arr = Enumerable.Range(0, length)
                            .Select(i =>
                            {
                                var span = new ReadOnlySpan<byte>(buffer, offset + i * 16, 16);
                                return new Guid(span);
                            });
                        OnArrayResult?.Invoke(arr);
                        break;
                    }

                default:
                    throw new TypeNotfoundException(message: ctype.FullName);
            }
        }

        /// <summary>
        /// Chuyển item từ bytes sang một định dạng type
        /// </summary>
        /// <param name="ctype">Kiểu dữ liệu của item</param>
        /// <param name="buffer"></param>
        /// <param name="offset">Vị trí bắt đầu đọc dữ liệu trên buffer</param>
        /// <param name="OnItemResult">Action trên item</param>
        /// <exception cref="TypeNotfoundException"></exception>
        public void ParseItem(CType ctype, byte[]? buffer, int offset, Action<object?> OnItemResult)
        {
            ParseArray(ctype, 1, buffer, offset, arr =>
            {
                var itor = ((IEnumerable)arr!).GetEnumerator();
                if (itor.MoveNext())
                {
                    OnItemResult?.Invoke(itor.Current);
                }
            });
        }

        /// <summary>
        /// Đặt giá trị cho thuộc tính của object
        /// </summary>
        /// <param name="obj">Đối tượng</param>
        /// <param name="root">Thuộc tính</param>
        /// <exception cref="TypeNotfoundException"></exception>
        public void BindingItem(object obj, CType root, CType ctype, byte[]? buffer, int offset)
        {
            ParseItem(ctype, buffer, offset, item =>
            {
                root.SetValue!(obj, item);
            });
        }

        /// <summary>
        /// Đặt giá trị cho thuộc tính mảng của object
        /// </summary>
        /// <param name="obj">Đối tượng</param>
        /// <param name="root">Kiểu dữ liệu mảng như List, Stack,...</param>
        /// <param name="ctype">Kiểu dữ liệu phần tử</param>
        /// <param name="length">Độ dài mảng</param>
        public void BindingList(object obj, CType root, CType ctype, int length, byte[]? buffer, int offset)
        {
            ParseArray(ctype, length, buffer, offset, arr =>
            {
                BindingList(obj, root, arr!);
            });
        }

        /// <summary>
        /// Đặt giá trị cho thuộc tính mảng của object
        /// </summary>
        /// <param name="obj">Đối tượng</param>
        /// <param name="ctype">Kiểu dữ liệu mảng</param>
        /// <param name="arr">Độ dài mảng</param>
        public void BindingList(object obj, CType ctype, object arr)
        {
            if (!ctype.IsList)
                ctype.SetValue!(obj, arr);
            else
            {
                var list = Activator.CreateInstance(ctype.CustomType!);
                var addMethod = ctype.CustomType!.GetMethod("Add");
                var itemIter = ((IEnumerable)arr!).GetEnumerator();
                while (itemIter.MoveNext())
                {
                    addMethod!.Invoke(list, [itemIter.Current]);
                }
                ctype.SetValue!(obj, list);
            }
        }

        /// <summary>
        /// Đặt giá trị cho đối tượng định dạng key - value
        /// </summary>
        /// <param name="obj">Đối tượng</param>
        /// <exception cref="TypeNotfoundException"></exception>
        public void BindingPair(object obj, CType ctype, int length, byte[]? keyBytes, byte[]? valueBytes)
        {
            if (length == 0 || keyBytes == null || valueBytes == null)
            {
                ctype.SetValue!(obj, null);
                return;
            }

            ParseArray(ctype.Others![0], length, keyBytes, 0, keys =>
            {
                ParseArray(ctype.Others![1], length, valueBytes, 0, values =>
                {
                    var pair = Activator.CreateInstance(ctype.CustomType!);
                    var addMethod = ctype.CustomType!.GetMethod("Add");

                    var keyItor = ((IEnumerable)keys!).GetEnumerator();
                    var valueItor = ((IEnumerable)values!).GetEnumerator();

                    while (keyItor.MoveNext() && valueItor.MoveNext())
                    {
                        addMethod!.Invoke(pair, [keyItor.Current, valueItor.Current]);
                    }
                    ctype.SetValue!(obj, pair);
                });
            });
        }
    }
}
