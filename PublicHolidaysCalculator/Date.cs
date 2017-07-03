
namespace PublicHolidaysCalculator
{
    using System;
    using System.Globalization;

    public struct Date
    {
        public Date(int year, int month, int day)
        {
            Month = month;
            Day = day;
            Year = year;
        }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public DateTime ToDateTime() => new DateTime(Year, Month, Day);
        public string ToString(string format) => ToDateTime().ToString(format);
        public override string ToString() => ToDateTime().ToString(CultureInfo.InvariantCulture);
    }
}
