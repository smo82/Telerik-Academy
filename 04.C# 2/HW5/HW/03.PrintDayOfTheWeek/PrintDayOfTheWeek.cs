using System;

class PrintDayOfTheWeek
{
    static void Main()
    {
        DateTime currentDateTime = DateTime.Now;
        Console.WriteLine(currentDateTime.DayOfWeek);
    }
}
