using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayExtensions.MSTests
{
    [TestClass]
    public class SpecailMethodsTests
    {
        [TestMethod]
        public void NextBiggerNumber_1234321_1241233()
        {
            Assert.AreEqual(1241233, SpecialMethods.NextBiggerNumber(1234321));
        }
        [TestMethod]
        public void NextBiggerNumber_513_531()
        {
            Assert.AreEqual(531, SpecialMethods.NextBiggerNumber(513));
        }
        [TestMethod]
        public void NextBiggerNumber_12_21()
        {
            Assert.AreEqual(21, SpecialMethods.NextBiggerNumber(12));
        }
        [TestMethod]
        public void NextBiggerNumber_11109742_11120479()
        {
            Assert.AreEqual(11120479, SpecialMethods.NextBiggerNumber(11109742));
        }
        [TestMethod]
        public void NextBiggerNumber_minus0_minus1()
        {
            Assert.AreEqual(-1, SpecialMethods.NextBiggerNumber(-0));
        }
        [TestMethod]
        public void NextBiggerNumber_111_minus1()
        {
            Assert.AreEqual(-1, SpecialMethods.NextBiggerNumber(111));
        }
        [TestMethod]
        public void NextBiggerNumber_10_minus1()
        {
            Assert.AreEqual(-1, SpecialMethods.NextBiggerNumber(10));
        }
        [TestMethod]
        public void NextBiggerNumber_IntMaxValue_minus1()
        {
            Assert.AreEqual(-1, SpecialMethods.NextBiggerNumber(int.MaxValue));
        }
        [TestMethod]
        public void NextBiggerNumber_minus324_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => SpecialMethods.NextBiggerNumber(-324),
                "Argument must be a positive integer");
        }

        [TestMethod]
        public void NextBiggerNumber_IntMinValue_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => SpecialMethods.NextBiggerNumber(int.MinValue),
                "Argument must be a positive integer");
        }
    }
}
