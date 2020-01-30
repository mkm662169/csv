using Microsoft.VisualStudio.TestTools.UnitTesting;
using Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Query.Tests
{
    [TestClass()]
    public class StatStandDevTests
    {
        [TestMethod()]
        public void StandDevTest()
        {
            int[] values = { 1, 2, 3, 4, 5 };
            var standDev = StatStandDev.StandDev(values);
            Assert.AreEqual(1.41421, Math.Round(standDev, 5, MidpointRounding.AwayFromZero));
        }

        [TestMethod()]
        public void StandDevTest1()
        {
            double[] values = { 1.3, 2.1, 3.7, 4.5, 5.8 };
            var standDev = StatStandDev.StandDev(values);
            Assert.AreEqual(1.62037, Math.Round(standDev, 5, MidpointRounding.AwayFromZero));
        }
    }
}