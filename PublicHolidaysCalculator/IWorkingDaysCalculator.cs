namespace PublicHolidaysCalculator
{
    public interface IWorkingDaysCalculator
    {
        int GetWorkingDaysByMonth(int year, int month, bool workingOnSaturday = false);
    }
}