using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute.Routing.Handlers;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace ArrayExtensions.NUnitTests
{
    [TestFixture]
    class SpecialMethodsTests

    {
        #region Tests of values IndexOfSimmetricSums

        [TestCase(new int[] { 1, 2, 3, 4, 2, 1, 3, 0 }, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 100, 50, -51, 1, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 0, -1, 0, 0, 1, 10 }, ExpectedResult = 5)]
        [TestCase(new int[] { 12, 4, 0, 1, -4, 5, -1, -5, 0 }, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 3, 4, 4 - 1, -51, 15, -14, int.MinValue, 0, -3212, 41422 }, ExpectedResult = -1)]
        [TestCase(new int[] { int.MinValue }, ExpectedResult = 0)]
        [TestCase(new int[] { int.MaxValue, -2133, -42141, 4351, 442142, int.MaxValue, 32432, int.MinValue, 342112, 0, int.MaxValue, 4112422 }, ExpectedResult = -1)]
        [TestCase(new int[] { int.MinValue, int.MinValue, int.MinValue, int.MinValue }, ExpectedResult = -1)]
        [TestCase(new int[] { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue }, ExpectedResult = 2)]
        public int IndexOfSimmetricSums_IntegerArrayWithSizeFrom1To999_IndexOfElementForWitchSumOfLeftElementsEqualsSumOfRightElements(int[] arr)
        {
            return ArrayExtensions.SpecialMethods.IndexOfSimmetricSums(arr);
        }

        [TestCase(false, ExpectedResult = 499)]
        [TestCase(true, ExpectedResult = 499)]
        public int IndexOfSimmetricSums_MaxLenthIntegerArrayOfMinOrMaxIntValues_IndexOfElementForWitchSumOfLeftElementsEqualsSumOfRightElements(bool temp)
        {

            int[] arrayOfMaxValues = new int[999];
            if (temp == false)
            {

                for (int i = 0; i < 999; i++)
                {
                    arrayOfMaxValues[i] = int.MinValue;

                }
                return ArrayExtensions.SpecialMethods.IndexOfSimmetricSums(arrayOfMaxValues);
            }
            else
            {

                for (int i = 0; i < 999; i++)
                {
                    arrayOfMaxValues[i] = int.MaxValue;
                }

                return ArrayExtensions.SpecialMethods.IndexOfSimmetricSums(arrayOfMaxValues);

            }
        }
        #endregion

        #region Tests of exceptions IndexOfSimmetricSums

        [Test]
        public void IndexOfSimmetricSums_NullArgument_ArgumentNullException()
        {
            var ex = Assert.Catch<Exception>(() => ArrayExtensions.SpecialMethods.IndexOfSimmetricSums(null));

            StringAssert.Contains("", ex.Message);
        }

        [Test]
        public void IndexOfSimmetricSums_ArrayWithSizeOver1000_ArgumentException()
        {
            int[] arr = new int[1000];

            var ex = Assert.Catch<Exception>(() => ArrayExtensions.SpecialMethods.IndexOfSimmetricSums(arr));

            StringAssert.Contains("Wrong size of array.\n Size must be : 1<size<1000", ex.Message);
        }

        [Test]
        public void IndexOfSimmetricSums_ArrayWithSizeEquals0_ArgumentException()
        {
            int[] arr = new int[0];

            var ex = Assert.Catch<Exception>(() => ArrayExtensions.SpecialMethods.IndexOfSimmetricSums(arr));

            StringAssert.Contains("Wrong size of array.\n Size must be : 1<size<1000", ex.Message);
        }

        #endregion

        #region Tests of positive values NextBiggerNumber

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(1209631, ExpectedResult = 1210369)]
        [TestCase(-0, ExpectedResult = -1)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(1100, ExpectedResult = -1)]
        [TestCase(1111, ExpectedResult = -1)]
        [TestCase(int.MaxValue, ExpectedResult = -1)]
        public int NextBiggerNumber_AnyPositiveIntNumber_NextBiggerNumberThatConsistOfTheSameElements(int number)
        {
            return ArrayExtensions.SpecialMethods.NextBiggerNumber(number); ;
        }

        #endregion

        #region Test of negative value NextBiggerNumber

        [Test]
        public void NextBiggerNumber_NotAPositiveInteger_ArgumentException()
        {
            var ex = Assert.Catch<Exception>(() => ArrayExtensions.SpecialMethods.NextBiggerNumber(int.MinValue));

            StringAssert.Contains("Argument must be a positive integer", ex.Message);
        }

        #endregion
    }
}
