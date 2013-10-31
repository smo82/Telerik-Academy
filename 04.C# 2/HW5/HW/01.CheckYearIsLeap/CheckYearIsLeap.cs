using System;

class CheckYearIsLeap
{
    static void Main()
    {
        Console.WriteLine("Enter your year:");
        ushort year = ushort.MinValue;

        while ((!ushort.TryParse(Console.ReadLine(), out year)) || (year <= 0) || (year > 9999))
        {
            Console.WriteLine("Wrong year. Please try again!");
        }

        DateTime yearDate = new DateTime(year, 1, 1);

        Console.WriteLine(new String ('*', 20));
        if (DateTime.IsLeapYear((int) year))
        {
            Console.WriteLine("Your year is a leap year!");
        }
        else
        {
            Console.WriteLine("Your year is NOT a leap year!");
        }
    }
}
