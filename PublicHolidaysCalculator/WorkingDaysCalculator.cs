namespace PublicHolidaysCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class WorkingDaysCalculator : IWorkingDaysCalculator
    {
        private readonly IPublicHolidaysCalculator _publicDaysCalculator;
        private readonly IDictionary<int, IEnumerable<Date>> _publicHolidays;

        public WorkingDaysCalculator(IPublicHolidaysCalculator publicDaysCalculator)
        {
            _publicDaysCalculator = publicDaysCalculator;
            _publicHolidays = new Dictionary<int, IEnumerable<Date>>();
        }

        public int GetWorkingDaysByMonth(int year, int month, bool workingOnSaturday = false)
        {
            if (!_publicHolidays.ContainsKey(year))
            {
                _publicHolidays[year] = _publicDaysCalculator.GetPublicHolidays(year);
            }
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
                {
                    workingDays++;
                }

                currentDay = currentDay.AddDays(1);
                currentMonth = currentDay.Month;
            }
            return workingDays;
        }
    }
}
