namespace PublicHolidaysCalculator.Tests
{
    using System;
    using Moq;
    using Xunit;
    public class WorkingDaysCalculatorTests
    {
        [Theory]
        [InlineData(2017, 01, 22)]
        [InlineData(2017, 02, 20)]
        [InlineData(2017, 03, 23)]
        [InlineData(2017, 4, 19)]
        [InlineData(2017, 5, 20)]
        [InlineData(2017, 6, 21)]
        [InlineData(2017, 7, 20)]
        [InlineData(2017, 08, 22)]
        [InlineData(2017, 09, 21)]
        [InlineData(2017, 10, 22)]
        [InlineData(2017, 11, 21)]
        [InlineData(2017, 12, 20)]
        public void Test(int year, int month, int expectedWorkingDays)
        {
            var calculator = new WorkingDaysCalculator(new FrenchPublicHolidaysCalculator());
            var workingDays = calculator.GetWorkingDaysByMonth(year, month);
            Assert.Equal(expectedWorkingDays, workingDays);
        }

        [Fact]
        public void CheckDictionary()
        {
            var frenchPublicHolidaysCalculator = new Mock<IPublicHolidaysCalculator>();
            var calculator = new WorkingDaysCalculator(frenchPublicHolidaysCalculator.Object);
            calculator.GetWorkingDaysByMonth(2012, 1);
            calculator.GetWorkingDaysByMonth(2012, 1);
            calculator.GetWorkingDaysByMonth(2012, 1);
            frenchPublicHolidaysCalculator.Verify(e=>e.GetPublicHolidays(2012), Times.Once);
        }
        [Fact]
        public void CheckDictionary2()
        {
            var frenchPublicHolidaysCalculator = new Mock<IPublicHolidaysCalculator>();
            var calculator = new WorkingDaysCalculator(frenchPublicHolidaysCalculator.Object);
            calculator.IsDayOff(new DateTime(2012, 1, 1));
            calculator.IsDayOff(new DateTime(2012, 1, 1));
            calculator.IsDayOff(new DateTime(2012, 1, 1));
            frenchPublicHolidaysCalculator.Verify(e => e.GetPublicHolidays(2012), Times.Once);
        }

        [Fact]
        public void CheckDayOffSunday()
        {
            var calculator = new WorkingDaysCalculator(new FrenchPublicHolidaysCalculator());
            Assert.True(calculator.IsDayOff(new DateTime(2017, 07, 02))); // dimanche
        }

        [Fact]
        public void CheckDayOffSaturday()
        {
            var calculator = new WorkingDaysCalculator(new FrenchPublicHolidaysCalculator());
            Assert.True(calculator.IsDayOff(new DateTime(2017, 07, 01))); // samedi
        }

        [Fact]
        public void CheckDayOffHol()
        {
            var calculator = new WorkingDaysCalculator(new FrenchPublicHolidaysCalculator());
            Assert.True(calculator.IsDayOff(new DateTime(2017, 05, 08))); // ferié
        }
    }
}
