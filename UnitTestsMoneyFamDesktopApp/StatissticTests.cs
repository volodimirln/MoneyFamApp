using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyFamDestopApp.Data.Models;
using MoneyFamDestopApp.Services;
using System;
using System.Linq;

namespace UnitTestsMoneyFamDesktopApp
{
    [TestClass]
    public class StatissticTests
    {
        [TestMethod]
        public void TestStatisticMonth_ReturnIsNotNull()
        {
            double result = Statistics.GetStatisticMonth(1);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestStatisticTarget_ReturnIsNotNull()
        {
            double result = Statistics.GetStatisticTarget(1);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestStatisticPayment_ReturnIsNotNull()
        {
            double result = Statistics.GetStatisticPayment(1);
            Assert.IsNotNull(result);
        }
    }
}
