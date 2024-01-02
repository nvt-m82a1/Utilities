using System.Reflection.Metadata.Ecma335;
using Utilities.Container.Buildin;
using static Utilities.Container.Datatype.Types;

namespace Utilities.Container.Datatype
{
    public class TypesRead
    {
        /// <summary>
        /// Tạo một CType từ định dạng Type
        /// </summary>
        /// <param name="target"></param>
        public static CType CreateCType(Type target)
        {
            var ctype = new CType();
            FillCType(ctype, target);
            return ctype;
        }

        /// <summary>
        /// Điền một CType từ định dạng Type
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public static void FillCType(CType result, Type target)
        {
            switch (target.Name)
            {
                case Name.Enumerable.Dictionary2:
                case Name.Enumerable.CDictionary2:
                    result.IsPair = true;
                    result.CustomType = target;
                    result.Others = [new CType(), new CType()];
                    FillCType(result.Others[0], target.GenericTypeArguments[0]);
                    FillCType(result.Others[1], target.GenericTypeArguments[1]);
                    break;

                case Name.Enumerable.Stack1:
                case Name.Enumerable.CStack1:
                case Name.Enumerable.Queue1:
                case Name.Enumerable.CQueue1:
                case Name.Enumerable.List1:
                case Name.Enumerable.LinkedList1:
                    {
                        result.IsList = true;
                        goto case Name.Enumerable.ConcatNIterator1;
                    }
                case Name.Enumerable.IEnumerable1:
                case Name.Enumerable.Concat2Iterator1:
                case Name.Enumerable.ConcatNIterator1:
                    result.IsEnumerable = true;
                    if (target.IsGenericType)
                    {
                        result.IsGeneric = true;
                        result.CustomType = target;
                        result.Others = [new CType()];
                        FillCType(result.Others[0], target.GenericTypeArguments[0]);
                    }
                    else
                        FillCType(result, target.GenericTypeArguments[0]);

                    break;

                case Name.Nullable1:
                    result.IsNullable = true;
                    target = target.GenericTypeArguments[0];
                    FillCType(result, target);
                    break;

                case Name.Enumerable.IDictionary2:
                    throw new NotImplementedException();

                default:
                    result.FullName = target.FullName;

                    if (Attribute.IsDefined(target, typeof(ClassContainerAttribute)))
                    {
                        result.IsContainer = true;
                        result.CustomType = target;
                    }

                    if (target.BaseType?.FullName == FullName.Array)
                    {
                        result.IsEnumerable = true;
                        result.FullName = target.FullName?.Replace("[]", "");
                    }

                    if (result.FullName?.Last() == '?')
                    {
                        result.IsNullable = true;
                        result.FullName = result.FullName?.Trim('?');
                    }

                    result.IsBoolean = result.FullName == FullName.Boolean;

                    break;
            }
        }
    }
}
