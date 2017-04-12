namespace PublicHolidaysCalculator.Tester
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                WriteWorkingDaysAMonth();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void WritePublicHolidays()
        {
            while (true)
            {
                Console.WriteLine("Which year do you wanna try ?");
                var wantedYear = Console.ReadLine();
                var res = int.TryParse(wantedYear, out int year);
                if (!res)
                {
                    Console.WriteLine("This is no year !");
                    continue;
                }
                var result = new FrenchPublicHolidaysCalculator().GetPublicHolidays(year);
                foreach (var item in result)
                {
                    Console.WriteLine(item.ToString("D"));
                }
            }
        }

        private static void WriteWorkingDaysAMonth()
        {
            while (true)
            {
                Console.WriteLine("Which year do you wanna try ?");
                var wantedYear = Console.ReadLine();
                var res = int.TryParse(wantedYear, out int year);
                if (!res)
                {
                    Console.WriteLine("This is no year !");
                    continue;
                }
                Console.WriteLine("Which month do you wanna try ?");
                var wantedMonth = Console.ReadLine();
                res = int.TryParse(wantedMonth, out int month);
                if (!res)
                {
                    Console.WriteLine("This is no year !");
                    continue;
                }
                var result = new WorkingDaysCalculator(new FrenchPublicHolidaysCalculator()).GetWorkingDaysByMonth(year, month);
                Console.WriteLine($"{result} working days in {month}/{year}");
            }
        }
    }
}