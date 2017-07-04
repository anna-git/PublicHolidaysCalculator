namespace SimpleDate.Model
{
    using System;

    public struct MonthDay
    {
        public MonthDay(int month, int day)
        {
            Month = month;
            Day = day;
        }
        public int Month { get; set; }
        public int Day { get; set; }

        public DateTime ToDateTime(int year) => new DateTime(year, Month, Day);

        public Date ToDate(int year) => new Date(year, Month, Day);
    }
}
