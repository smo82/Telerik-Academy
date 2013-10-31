using System;
using System.Text.RegularExpressions;
class HideForbiddenWords
{
    static int ReadInt(string message = "Enter N:", int maxValue = int.MaxValue)
    {
        Console.Write(message);

        int resultInt;
        while ((!int.TryParse(Console.ReadLine(), out resultInt)) || (resultInt < 0) || (resultInt > maxValue))
        {
            Console.Write("Wrong number. Please try again:");
        }

        return resultInt;
    }

    static void Main()
    {
        Console.Write("Enter your string:");
        string userString = Console.ReadLine();

        int lengthForbiddenWords = ReadInt("Enter whats the number of your forbidden words:");

        Console.WriteLine("Please enter your forbidden words:");
        for (int i = 0; i < lengthForbiddenWords; i++)
        {
            string forbiddenWord = Console.ReadLine();
            userString = Regex.Replace(userString, "\\b" + forbiddenWord + "\\b", new String('*', forbiddenWord.Length));
        }

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your result string is:");
        Console.WriteLine(userString);
    }
}
