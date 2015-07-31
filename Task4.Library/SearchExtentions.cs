using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4.Library
{
    public static class SearchExtentions
    {
        /// <summary>
        /// Searches sorted <see cref="array"/> for <see cref="element"/> and returns valid index of found element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Sorted array of <see cref="T"/>.</param>
        /// <param name="element">Element to search.</param>
        /// <param name="comparison"></param>
        /// <returns>Index of <see cref="element"/> in <see cref="array"/> or negative number if not found.</returns>
        public static int BinarySearch<T>(this T[] array, T element, Comparison<T> comparison)
        {
            int left = 0, right = array.Length - 1;
            int mid = right / 2;

            while (left <= right)
            {
                int result = comparison(array[mid], element);
                if (result == 0)
                    return mid;
                else if (result < 0)
                {
                    left = mid + 1;
                    mid = (left + right) / 2;
                }
                else if (true)
                {
                    right = mid - 1;
                    mid = (left + right) / 2;
                }
            }
            return -1;
        }

        public static int BinarySearch<T>(this T[] array, T element, IComparer<T> comparer)
        {
            return BinarySearch<T>(array, element, comparer.Compare);
        }

        public static int BinarySearch<T>(this T[] array, T element)
        {
            if (element is IComparable)
            {
                IComparer<T> comparer = Comparer<T>.Default;
                return BinarySearch<T>(array, element, comparer.Compare);
            }
            else
                throw new InvalidOperationException("Specified type does't implement IComparable<"+ element.GetType() +"> interface");
        }
    }
}
