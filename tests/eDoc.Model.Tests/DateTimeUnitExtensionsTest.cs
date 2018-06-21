using System;
using eDoc.Model.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eDoc.Model.Tests
{
    [TestClass]
    public class DateTimeUnitExtensionsTest
    {
        [TestMethod]
        public void DateTimeUnitExtension_ConvertsNumberWithUnitToMinutes_ReturnsNumberOfMinutes()
        {
            int minutesInDayPrecalculated = 24 * 60;

            int minutesInDayTotal = DateTimeUnit.Day.ToMinutes(1);

            Assert.AreEqual(minutesInDayPrecalculated, minutesInDayTotal);
        }
    }
}
