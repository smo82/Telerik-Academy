using System;

public class Functions
{
    public static int ReadIntInRange(int startRange = int.MinValue, int endRange = int.MaxValue)
    {
        string input = Console.ReadLine();
        int inputInt;

        while (!ParseIntInRange(input, startRange, endRange, out inputInt))
        {
            Console.WriteLine("Incorrect number! Please try again:");
            input = Console.ReadLine();
        }

        return inputInt;
    }

    public static bool ParseIntInRange(string input, int startRange, int endRange, out int inputInt)
    {
        bool successParse = int.TryParse(input, out inputInt);
        if (!successParse)
        {
            return false;
        }

        if (inputInt < startRange)
        {
            return false;
        }

        if (inputInt > endRange)
        {
            return false;
        }

        return true;
    }

    public static void Main(string[] args)
    {
    }
}