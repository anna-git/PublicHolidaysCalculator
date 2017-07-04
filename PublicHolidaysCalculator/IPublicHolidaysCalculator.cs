using System.Collections.Generic;

namespace PublicHolidaysCalculator
{
    using SimpleDate.Model;

    public interface IPublicHolidaysCalculator
    {
        IEnumerable<Date> GetPublicHolidays(int year);
    }
}