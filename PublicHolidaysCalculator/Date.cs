
namespace PublicHolidaysCalculator
{
    using System;
    using System.Globalization;

    public struct Date
    {
        public Date(int year, int month, int day)
        {
            if(month > 12)
                throw new ArgumentOutOfRangeException(nameof(month));
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
        public static bool operator ==(Date dt, Date other) => IsEqualTo(dt, other);
        public static bool operator !=(Date dt, Date other) => dt.Year == other.Year || dt.Month != other.Month || dt.Day != other.Day;
        private static bool IsEqualTo(Date dt, Date other) => dt.Day == other.Day && dt.Month == other.Month && dt.Year == other.Year;
        public override bool Equals(object obj)
        {
            if(!(obj is Date)) throw new ArgumentException("Obj is not Date type");
            return IsEqualTo(this, (Date) obj);
        }
        public override int GetHashCode() => ToDateTime().GetHashCode();
    }
}
