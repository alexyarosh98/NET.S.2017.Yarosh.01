using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ArrayExtensions.NUnitTests
{
    [TestFixture]
    public class SortAlgorithmsTests
    {
        #region QuickSort Tests
        [TestCase(new int[] { 4, 2, 1, int.MaxValue }, new int[] { 1, 2, 4, int.MaxValue })]
        [TestCase(new int[] { -2, 0, -4, 7, -0 }, new int[] { -4, -2, 0, 0, 7 })]
        [TestCase(new int[] { int.MaxValue, 0, 14, -14252, 4, int.MinValue },
            new int[] { int.MinValue, -14252, 0, 4, 14, int.MaxValue })]
        [TestCase(new int[] { -5, -13, -52, -0, int.MinValue, -14, 0 },
            new int[] { int.MinValue, -52, -14, -13, -5, 0, 0 })]
        public void QuickSort_UnsortedArray_SortedArray(int[] unSortedArray, int[] sortedArray)
        {
            ArrayExtensions.QuickSort.Sort(unSortedArray);

            Assert.AreEqual(unSortedArray, sortedArray);
        }

        [Test]
        public void QuickSort_NullArgumentInput_NullArgumentException()
        {
            var ex = Assert.Catch<Exception>(() => ArrayExtensions.QuickSort.Sort(null));

            StringAssert.Contains("", ex.Message);
        }
        #endregion

        #region MergeSort Tests
        [TestCase(new int[] { 4, 2, 1, int.MaxValue }, new int[] { 1, 2, 4, int.MaxValue })]
        [TestCase(new int[] { -2, 0, -4, 7, -0 }, new int[] { -4, -2, 0, 0, 7 })]
        [TestCase(new int[] { int.MaxValue, 0, 14, -14252, 4, int.MinValue }, new int[] { int.MinValue, -14252, 0, 4, 14, int.MaxValue })]
        [TestCase(new int[] { -5, -13, -52, -0, int.MinValue, -14, 0 }, new int[] { int.MinValue, -52, -14, -13, -5, 0, 0 })]
        public void MergeSort_UnsortedArray_SortedArray(int[] unSortedArray, int[] sortedArray)
        {
            ArrayExtensions.MergeSort.Sort(unSortedArray);

            Assert.AreEqual(unSortedArray, sortedArray);
        }

        [Test]
        public void MergeSort_NullArgumentInput_NullArgumentException()
        {
            var ex = Assert.Catch<Exception>(() => ArrayExtensions.MergeSort.Sort<int>(null));

            StringAssert.Contains("", ex.Message);


        }

        #endregion
    }
}
