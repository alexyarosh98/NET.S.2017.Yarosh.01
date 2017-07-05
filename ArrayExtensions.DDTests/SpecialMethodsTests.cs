using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayExtensions.DDTTests
{
    [TestClass()]
    public class SpecialMethodsTests
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\Arguments.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("DDT.Demo.Tests\\Arguments.xml")]
        [TestMethod]
        public void NextBiggerNumber()
        {
            int expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);
            int number = Convert.ToInt32(TestContext.DataRow["FirstArg"]);
            int actual =
                ArrayExtensions.SpecialMethods.NextBiggerNumber(number);

            Assert.AreEqual(expected, actual);

        }


    }
}
