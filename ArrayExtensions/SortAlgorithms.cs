using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExtensions
{
    public static class QuickSort
    {
        /// <summary>
        /// Quick sort algorithm
        /// </summary>
        /// <param name="arr">The array to be sorted</param>
        /// <param name="comparer">The rule that will sort the array</param>
        /// <exception cref="ArgumentNullException">Array is null</exception>
        /// <remarks>The default rule of comparing is comparing by value</remarks>

        public static void Sort(int[] arr, Comparison<int> comparer = null)
        {
            if (arr == null) throw new ArgumentNullException();
            if (comparer == null) comparer = DefaultComparer;
            QSort(arr, 0, arr.Length - 1, comparer);
        }

        private static void QSort(int[] arr, int leftIndex, int rightIndex, Comparison<int> comparer)
        {
            int middle = arr[leftIndex + (rightIndex - leftIndex) / 2];
            int i = leftIndex;
            int j = rightIndex;

            int temp;
            while (i <= j)
            {
                while (comparer(arr[i], middle) < 0) i++;
                while (comparer(arr[j], middle) > 0) j--;
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;

                    i++;
                    j--;
                }
            }
            if (i < rightIndex) QSort(arr, i, rightIndex, comparer);
            if (j > leftIndex) QSort(arr, leftIndex, j, comparer);
        }

        private static int DefaultComparer(int obj1, int obj2) => obj1.CompareTo(obj2);
    }


    public static class MergeSort
    {
        /// <summary>
        /// Merge sort algorithm
        /// </summary>
        /// <typeparam name="T">Type of arguments to be sorted</typeparam>
        /// <param name="array">Array to be sorted</param>
        /// <param name="comparator">The rule that will sort the array</param>
        /// <exception cref="ArgumentNullException">Array is null</exception>
        /// <remarks>Default sorting will sort the array by comparing hashcodes of the objects</remarks>


        public static void Sort<T>(T[] array, Comparison<T> comparator = null)
        {
            if (array == null) throw new ArgumentNullException();
            if (comparator == null) comparator = DefaultComparer;
            Array.Copy(MergeSortP1(array, comparator), array, array.Length);
        }

        private static T[] MergeSortP1<T>(T[] buff, Comparison<T> comparator)
        {
            if (buff.Length > 1)
            {
                T[] left = new T[buff.Length / 2];
                T[] right = new T[buff.Length - left.Length];
                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = buff[i];
                }
                for (int i = 0; i < right.Length; i++)
                {
                    right[i] = buff[left.Length + i];
                }
                if (left.Length > 1)
                    left = MergeSortP1(left, comparator);
                if (right.Length > 1)
                    right = MergeSortP1(right, comparator);
                buff = MergeSortP2<T>(left, right, comparator);
            }
            return buff;
        }
        private static T[] MergeSortP2<T>(T[] left, T[] right, Comparison<T> comparator)
        {
            T[] buff = new T[left.Length + right.Length];
            int leftCounter = 0;
            int rightCounter = 0;
            for (int i = 0; i < buff.Length; i++)
            {
                if (rightCounter >= right.Length)
                {
                    buff[i] = left[leftCounter];
                    leftCounter++;
                }
                else if (leftCounter < left.Length && comparator(left[leftCounter], right[rightCounter]) < 0)
                {
                    buff[i] = left[leftCounter];
                    leftCounter++;
                }
                else
                {
                    buff[i] = right[rightCounter];
                    rightCounter++;
                }
            }
            return buff;
        }
        private static int DefaultComparer<T>(T obj1, T obj2)
        {
            return obj1.GetHashCode().CompareTo(obj2.GetHashCode());
        }
    }

}
