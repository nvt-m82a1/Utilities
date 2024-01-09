using System.Collections;

namespace Utilities.Container.Option
{
    internal static class Extensions
    {
        public static int Count(this IEnumerable enumerable)
        {
            var count = 0;

            var iter = enumerable.GetEnumerator();
            while (iter.MoveNext())
                count++;

            return count;
        }

        public static object? First(this IEnumerable enumerable)
        {
            var iter = enumerable.GetEnumerator();
            if (iter.MoveNext())
                return iter.Current;
            
            return null;
        }
    }
}
