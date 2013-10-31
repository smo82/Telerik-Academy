using System;
using System.Globalization;

class CalcDays
{

    static DateTime ReadDate(string message = "Please enter date:", string format = "d.MM.yyyy")
    {
        Console.Write(message);

        DateTime resultDate;

        while (!DateTime.TryParseExact(Console.ReadLine(), new string[] {format}, CultureInfo.InvariantCulture, DateTimeStyles.None, out resultDate))
        {
            Console.Write("Wrong date, please try again:");
        }

        return resultDate;
    }

    static void Main()
    {
        DateTime firstDate = ReadDate("Please enter the first date:");
        DateTime secondDate = ReadDate("Please enter the second date:");
        
        TimeSpan difference;
        
        if ((firstDate.Month<secondDate.Month) ||
            ((firstDate.Month == secondDate.Month) && (firstDate.Day < secondDate.Day)))
        {
            secondDate = new DateTime(firstDate.Year, secondDate.Month, secondDate.Day);
            difference = secondDate - firstDate;
        }
        else
        {
            firstDate = new DateTime(secondDate.Year, firstDate.Month, firstDate.Day);
            difference = firstDate - secondDate;
        }

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("The difference between the two dates is: {0} days", difference.Days);
    }
}