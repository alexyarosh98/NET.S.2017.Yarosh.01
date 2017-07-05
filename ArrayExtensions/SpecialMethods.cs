using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExtensions
{
    public class SpecialMethods
    {
        const int MAXNUMBER = 0x7fffffff;
        const int MAXBITS = 31;


        /// <summary>
        /// Find an index of an element from both sides of that sums are equal.
        /// </summary>
        /// <param name="arr">Sourse array</param>
        /// <exception cref="ArgumentException">Array size must be form 1 to 1000</exception>
        /// <exception cref="ArgumentNullException">Array is null</exception>
        /// <returns>index of an element</returns>
        public static int IndexOfSimmetricSums(int[] arr)
        {
            if (arr == null) throw new ArgumentNullException();
            if (arr.Length >= 1000 || arr.Length == 0)
                throw new ArgumentException("Wrong size of array.\n Size must be : 1<size<1000");
            long rightSum = 0;
            long leftSum = 0;
            int index = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                rightSum += arr[i];
            }

            while (index != arr.Length)
            {
                if (leftSum == rightSum) return index;
                if (index == arr.Length - 1) break;
                index++;
                leftSum += arr[index - 1];
                rightSum -= arr[index];

            }

            return -1;
        }

        /// <summary>
        /// Find the next bigger number, wich consists of the same digits.
        /// </summary>
        /// <param name="number">Users positive integer</param>
        /// <exception cref="ArgumentException">Users integer must be bigger then 0</exception>
        /// <returns>Integer number</returns>
        public static int NextBiggerNumber(int number)
        {
            if (number < 0) throw new ArgumentException("Argument must be a positive integer");
            int oldnumber = number;
            int index = 1;
            int[] arrNumber = new int[number.ToString().Length + 1];
            arrNumber[0] = number % 10;
            number /= 10;
            while (number > 0)
            {
                arrNumber[index] = number % 10;
                if (arrNumber[index - 1] > arrNumber[index])
                {
                    SwapToNextBiggerNumber(arrNumber, index);
                    number /= 10;
                    break;
                }
                ;
                number /= 10;
                index++;
            }
            Array.Sort(arrNumber, 0, index);
            int newNumber = arrNumber[index];

            for (int i = 0; i < index; i++)
            {
                newNumber *= 10;
                newNumber += arrNumber[i];
            }

            string answer = number.ToString().Insert(number.ToString().Length, newNumber.ToString());
            if (!Int32.TryParse(answer, out number)) return -1;
            return (oldnumber >= Int32.Parse(answer)) ? -1 : Int32.Parse(answer);
        }
        /// <summary>
        /// Inserts bits from positions i and j second number to first number
        /// </summary>
        /// <param name="num1">The number that have to be inserted</param>
        /// <param name="num2">The number some bites of wich have to be inserted into num1</param>
        /// <param name="i">first index of bit</param>
        /// <param name="j">last index of bit</param>
        /// <exception cref="ArgumentException">i must be bigger then j</exception>>
        /// <exception cref="ArgumentOutOfRangeException"> i and j must be bigger then 0 and less then 31</exception>>
        /// <returns>Obtained number</returns>
        public static int SpecialAddition(int num1, int num2, int i, int j)
        {
            if (i < 0 || i > MAXBITS || j < 0 || j > MAXBITS) throw new ArgumentOutOfRangeException();
            if (j < i) throw new ArgumentException();
            int lenthOfBits = j - i + 1;
            int mask;
            mask = MAXNUMBER >> (MAXBITS - lenthOfBits);
            int num2Tail = num2 & mask;
            mask = MAXNUMBER >> (MAXBITS - i);
            int num1Tail = num1 & mask;
            num2Tail = num2Tail << i;
            num2Tail = num2Tail | num1Tail;
            mask = MAXNUMBER >> (MAXBITS - j - 1);
            return (num1 & ~mask) | num2Tail;
        }

        private static void SwapToNextBiggerNumber(int[] array, int index)
        {
            int temp = array[index];
            for (int i = 0; i < index; i++)
            {
                if (array[i] > array[index])
                {
                    array[index] = array[i];
                    array[i] = temp;
                    break;
                }
            }

        }
    }
}
