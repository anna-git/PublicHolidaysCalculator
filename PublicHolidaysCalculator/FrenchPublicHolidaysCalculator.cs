namespace PublicHolidaysCalculator
{
    using System.Collections.Generic;
    using System.Linq;
    using SimpleDate.Model;

    public class FrenchPublicHolidaysCalculator : IPublicHolidaysCalculator
    {
        static readonly MonthDay[] FixedPublicHolidays = {
            new MonthDay(01, 01),
            new MonthDay(05, 01),
            new MonthDay(05, 08),
            new MonthDay(07, 14),
            new MonthDay(08, 15),
            new MonthDay(11, 1),
            new MonthDay(11, 11),
            new MonthDay(12, 25) };

        public IEnumerable<Date> GetPublicHolidays(int year)
        {
            var allDates = FixedPublicHolidays.Select(e => e.ToDate(year)).ToList();
            var easterSunday = EasterSunday(year).ToDateTime(year);
            var easterMonday = easterSunday.AddDays(1);
            var ascensionThursday = easterSunday.AddDays(39);
            var pentecoteMonday = easterSunday.AddDays(50);
            allDates.Add(easterMonday.ToDate()); //lundi de pâques
            allDates.Add(ascensionThursday.ToDate()); //jeudi ascension 
            allDates.Add(pentecoteMonday.ToDate()); //lundi pentecote
            return allDates;
        }

        private static MonthDay EasterSunday(int year)
        {
            int g = year % 19;
            int c = year / 100;
            int h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            int i = h - h / 28 * (1 - h / 28 * (29 / (h + 1)) * ((21 - g) / 11));
            var day = i - (year + year / 4 + i + 2 - c + c / 4) % 7 + 28;
            var month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }
            return new MonthDay(month, day);
        }
    }
}
