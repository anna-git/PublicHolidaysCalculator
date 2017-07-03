namespace PublicHolidaysCalculator
{
    using System;

    public interface IWorkingDaysCalculator
    {
        int GetWorkingDaysByMonth(int year, int month, bool workingOnSaturday = false);
        bool IsDayOff(DateTime dt);
    }
}