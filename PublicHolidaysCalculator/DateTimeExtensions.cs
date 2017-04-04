namespace PublicHolidaysCalculator
{
    using System;

    public static class DateTimeExtensions
    {
        public static Date ToDate(this DateTime datetime) => new Date(datetime.Year, datetime.Month, datetime.Day);
    }
}
