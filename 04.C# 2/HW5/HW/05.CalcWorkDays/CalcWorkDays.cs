using System;
using System.Collections.Generic;

class CalcWorkDays
{
    static DateTime ReadDate(string message = "Enter your date:")
    {
        Console.Write(message);

        DateTime resultDate;
        while ((!DateTime.TryParse(Console.ReadLine(), out resultDate)) || (resultDate<DateTime.Now))
        {
            Console.Write("Wrong date. Please try again:");
        }

        return resultDate;
    }

    static void Main()
    {
        List<string> publicHolidays = new List<string> { "2013-01-25", "2013-02-01", "2013-02-04" };

        DateTime userDate = ReadDate();

        //------------------------------------------------
        //Note: The end date is not included in the count!
        //------------------------------------------------
        List<string> allDates = new List<string>();
        for (var date = DateTime.Now; date < userDate; date = date.AddDays(1))
        {
            if (((int)date.DayOfWeek != 6) && ((int)date.DayOfWeek != 0) && (publicHolidays.FindIndex(item => item == date.ToString("yyyy-MM-dd")) < 0))
            {
                allDates.Add(date.ToString());
            }
        }

        Console.WriteLine("The number of workdays from now to your date (excluding) is: {0}", allDates.Count);
    }
}
