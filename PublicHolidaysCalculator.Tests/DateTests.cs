namespace PublicHolidaysCalculator.Tests
{
    using System;
    using Xunit;

    public class DateTests
    {
        [Fact]
        public void CheckEquality()
        {
            var date =new Date(2011, 12, 1);
            var date1 =new Date(2011, 12, 1);
            Assert.Equal(date1, date);
            Assert.True(date ==  date1);
        }

        [Fact]
        public void CheckInequality()
        {
            var date = new Date(2011, 12, 2);
            var date1 = new Date(2011, 12, 1);
            Assert.NotEqual(date1, date);
            Assert.False(date == date1);
        }

        [Fact]
        public void CheckMonth() => Assert.Throws<ArgumentOutOfRangeException>(()=>new Date(2011, 13, 2));
    }
}
