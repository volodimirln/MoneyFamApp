using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyFamDestopApp.Services;
using System;

namespace UnitTestsMoneyFamDesktopApp
{
    [TestClass]
    public class PrintTests
    {
        [TestMethod]
        public void TestStatisticsFile_ReturnTrue()
        {
            bool result = PrintStatistics.PrintStatisticsFile(1);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestStatisticsFile_ReturnFalse()
        {
            bool result = PrintStatistics.PrintStatisticsFile(2);
            Assert.IsFalse(result);
        }
    }
}
