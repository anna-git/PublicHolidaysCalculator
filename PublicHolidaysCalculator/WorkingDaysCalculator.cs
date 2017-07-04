namespace PublicHolidaysCalculator
{
    using SimpleDate.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class WorkingDaysCalculator : IWorkingDaysCalculator
    {
        private readonly IPublicHolidaysCalculator _publicHolidaysCalculator;
        private readonly IDictionary<int, IEnumerable<Date>> _publicHolidays;

        public WorkingDaysCalculator(IPublicHolidaysCalculator publicHolidaysCalculator)
        {
            _publicHolidaysCalculator = publicHolidaysCalculator;
            _publicHolidays = new Dictionary<int, IEnumerable<Date>>();
        }

        public int GetWorkingDaysByMonth(int year, int month, bool workingOnSaturday = false)
        {
            if (!_publicHolidays.ContainsKey(year))
                _publicHolidays[year] = _publicHolidaysCalculator.GetPublicHolidays(year);
            var publicHolidays = _publicHolidays[year];
            var currentDay = new DateTime(year, month, 01);
            var currentMonth = month;
            var workingDays = 0;
            while (currentMonth == month)
            {
                //if neither sunday, neither saturday (not working), neither public holiday
                if (currentDay.DayOfWeek != DayOfWeek.Sunday
                    && currentDay.DayOfWeek != DayOfWeek.Saturday && !workingOnSaturday
                    && !publicHolidays.Any(h => h.Month == month && h.Day == currentDay.Day))
                    workingDays++;

                currentDay = currentDay.AddDays(1);
                currentMonth = currentDay.Month;
            }
            return workingDays;
        }

        public virtual bool IsDayOff(DateTime dt)
        {
            var year = dt.Year;
            if (!_publicHolidays.ContainsKey(year))
                _publicHolidays[year] = _publicHolidaysCalculator.GetPublicHolidays(year);
            return dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday || _publicHolidays[year].Contains(dt.ToDate());
        }
    }
}
