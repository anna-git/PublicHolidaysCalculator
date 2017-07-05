namespace PublicHolidaysCalculator
{
    using System;
    using GeekLearning.Domain;

    public struct MonthDay
    {
        internal MonthDay(int month, int day)
        {
            Month = month;
            Day = day;
        }
        public int Month { get; set; }
        public int Day { get; set; }

        public DateTime ToDateTime(int year) => new DateTime(year, Month, Day);

        internal Date ToDate(int year) => new Date(year, Month, Day);
    }
}
