namespace PublicHolidaysCalculator.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class FrenchPublicHolidaysTests
    {
        public static IEnumerable<Date> GetPholidaysDatas(int year)
        {
            switch (year)
            {
                case 2017:
                    return new List<Date> { new Date(year, 4, 17), new Date(year, 05, 05), new Date(year, 05, 25) };
                case 2016:
                    return new List<Date> { new Date(year, 3, 28), new Date(year, 05, 05), new Date(year, 05, 16) };
                case 2018:
                    return new List<Date> { new Date(year, 4, 2), new Date(year, 05, 10), new Date(year, 05, 21) };
                case 2019:
                    return new List<Date> { new Date(year, 4, 22), new Date(year, 05, 30), new Date(year, 06, 10) };
                default:
                    throw new ArgumentException($"Year {year} wasn't expected");
            }
        }

        [Theory]
        [InlineData(2017)]
        [InlineData(2016)]
        [InlineData(2018)]
        [InlineData(2019)]
        public void Test(int year)
        {
            var calculator = new FrenchPublicHolidaysCalculator();
            var datas = GetPholidaysDatas(year);
            var publicHolidays = calculator.GetPublicHolidays(year);
            Assert.All(datas, e => publicHolidays.Contains(e));
        }
    }
}
