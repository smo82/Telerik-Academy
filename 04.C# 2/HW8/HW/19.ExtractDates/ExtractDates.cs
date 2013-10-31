using System;
using System.Text.RegularExpressions;
using System.Globalization;

class ExtractDates
{
    static void Main()
    {
        Console.Write("Enter your text:");
        string userText = Console.ReadLine();

        MatchCollection matches = Regex.Matches(userText, @"[0-9]{2}\.[0-9]{2}\.[0-9]{4}");

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("The dates found are:");
        foreach (Match match in matches)
        {
            DateTime foundDate;
            if (DateTime.TryParseExact(match.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out foundDate))
            {
                Console.WriteLine(foundDate.ToString(CultureInfo.GetCultureInfo("en-CA")));
            }
        }
    }
}

