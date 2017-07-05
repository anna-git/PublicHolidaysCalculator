using System.Collections.Generic;

namespace PublicHolidaysCalculator
{
    using GeekLearning.Domain;

    public interface IPublicHolidaysCalculator
    {
        IEnumerable<Date> GetPublicHolidays(int year);
    }
}