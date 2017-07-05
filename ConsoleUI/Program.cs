using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[17] { 54, 23, 1, 3, 4, -34, 5, 15, 2, 61, 23, -1, 53, 34, 42, 0, -6 };
            int[] array2 = new int[17] { 54, 23, 1, 3, 4, -34, 5, 15, 2, 61, 23, -1, 53, 34, 42, 0, -6 };
            int[] array3 = new int[9] { 4, 4, -12, 42, 291042, -219042, 0, 12, -0 };
            int[] array4 = new int[9] { 4, 4, -12, 42, 291042, -219042, 0, 12, -0 };
            Console.Write("Array 1: ");
            ShowArray(array1);
            Console.Write("\nArray 2: ");
            ShowArray(array3);

            ArrayExtensions.QuickSort.Sort(array1, NoneDefaultComparer);
            Console.Write("\n\nQuicksorted array1 with nonedefault comparer: ");
            ShowArray(array1);
            ArrayExtensions.QuickSort.Sort(array1);
            Console.Write("\nQuicksorted array1 with default comparer: ");
            ShowArray(array1);
            ArrayExtensions.QuickSort.Sort(array3);
            Console.Write("\nQuicksorted array2: ");
            ShowArray(array3);

            ArrayExtensions.MergeSort.Sort<int>(array2, NoneDefaultComparer);
            Console.Write("\n\nMergesorted array1 with nonedefault comparer: ");
            ShowArray(array2);
            ArrayExtensions.MergeSort.Sort<int>(array2);
            Console.Write("\nMergesorted array1 with default comparer: ");
            ShowArray(array2);
            ArrayExtensions.MergeSort.Sort<int>(array4);
            Console.Write("\nMergesorted array2: ");
            ShowArray(array4);

            Console.ReadKey();
        }

        private static void ShowArray(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
        }
        private static int NoneDefaultComparer(int obj1, int obj2) => Math.Abs(obj1) - Math.Abs(obj2);

    }
}
