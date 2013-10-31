using System;
using System.Globalization;

class CorrectDate
{
    static DateTime ReadDate(string message = "Please enter date:", string format = "dd.MM.yyyy HH:mm:ss")
    {
        Console.Write(message);

        DateTime resultDate;

        while (!DateTime.TryParseExact(Console.ReadLine(), new string[] { format }, CultureInfo.InvariantCulture, DateTimeStyles.None, out resultDate))
        {
            Console.Write("Wrong date, please try again:");
        }

        return resultDate;
    }

    static void Main()
    {
        DateTime userDate = ReadDate("Please enter your date:");

        userDate = userDate.AddHours(6);
        userDate = userDate.AddMinutes(30);

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your new date is: {0:dd.MM.yyyy HH:mm:ss}", userDate);
        Console.WriteLine("The day of the week is: {0}", userDate.ToString("dddd", CultureInfo.GetCultureInfo("bg-BG")));
    }
}