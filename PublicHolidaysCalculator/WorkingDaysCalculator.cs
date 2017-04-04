using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHolidaysCalculator
{
    public class WorkingDaysCalculator : IWorkingDaysCalculator
    {
        private readonly Lazy<IEnumerable<Date>> _publicHolidays;

        public WorkingDaysCalculator(IPublicHolidaysCalculator publicDaysCalculator, int year)
        {
            _publicHolidays = new Lazy<IEnumerable<Date>>(() => publicDaysCalculator.GetMovingPublicHolidays(year));
        }

        public int GetWorkingDaysByMonth(int year, int month, bool workingOnSaturday = false)
        {
            var currentDay = new DateTime(year, month, 01);
            var currentMonth = month;
            var workingDays = 0;
            while (currentMonth == month)
            {
                //if neither sunday, neither saturday (not working), neither public holiday
                if (currentDay.DayOfWeek != DayOfWeek.Sunday
                    && (currentDay.DayOfWeek != DayOfWeek.Saturday && !workingOnSaturday)
                    && !_publicHolidays.Value.Any(h => h.Month == month && h.Day == currentDay.Day))
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
