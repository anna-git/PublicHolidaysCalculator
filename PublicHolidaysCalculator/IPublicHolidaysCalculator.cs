using System.Collections.Generic;

namespace PublicHolidaysCalculator
{
    public interface IPublicHolidaysCalculator
    {
        IEnumerable<Date> GetMovingPublicHolidays(int year);
    }
}