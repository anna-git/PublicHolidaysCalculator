namespace PublicHolidaysCalculator.Tests
{
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
    }
}
