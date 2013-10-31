using System;
using System.Collections.Generic;

public class FunctionCollection
{
    public static HashSet<string> ParsePersonName(string nameString)
    {
        HashSet<string> result = new HashSet<string>();
        string[] names = nameString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (names.Length == 0)
        {
            throw new InvalidOperationException("Empty name!");
        }

        foreach (string name in names)
        {
            result.Add(name);
        }

        return result;
    }

    public static Dictionary<T, int> CountValues<T>(List<T> values)
    {
        Dictionary<T, int> valuesCount = new Dictionary<T, int>();
        foreach (T value in values)
        {
            if (valuesCount.ContainsKey(value))
            {
                valuesCount[value]++;
            }
            else
            {
                valuesCount[value] = 1;
            }
        }

        return valuesCount;
    }

    public static List<string> ReadStringListUptoEmptyLine()
    {
        List<string> stringCollection = new List<string>();
        Console.WriteLine("Enter the sequence of strings:");
        string inputdouble = Console.ReadLine();

        while (inputdouble != string.Empty)
        {
            stringCollection.Add(inputdouble);
            Console.WriteLine("Enter the next number:");
            inputdouble = Console.ReadLine();
        }

        return stringCollection;
    }

    public static List<double> ReadDoubleListInRangeUptoEmptyLine(
       double startRange = double.MinValue, double endRange = double.MaxValue)
    {
        List<double> doubleCollection = new List<double>();
        Console.WriteLine("Enter the sequence of numbers:");
        double? inputdouble = ReadDoubleInRangeOrEmpty(startRange, endRange);

        while (inputdouble != null)
        {
            doubleCollection.Add((double)inputdouble);
            Console.WriteLine("Enter the next number:");
            inputdouble = ReadDoubleInRangeOrEmpty(startRange, endRange);
        }

        return doubleCollection;
    }

    public static double? ReadDoubleInRangeOrEmpty(double startRange = double.MinValue, double endRange = double.MaxValue)
    {
        string input = Console.ReadLine();
        double inputdouble = -1;

        while ((input != string.Empty) && (!ParseDoubleInRange(input, startRange, endRange, out inputdouble)))
        {
            Console.WriteLine("Incorrect number! Please try again:");
            input = Console.ReadLine();
        }

        if (input == string.Empty)
        {
            return null;
        }

        return inputdouble;
    }

    public static bool ParseDoubleInRange(string input, double startRange, double endRange, out double inputdouble)
    {
        bool successParse = double.TryParse(input, out inputdouble);
        if (!successParse)
        {
            return false;
        }

        if (inputdouble < startRange)
        {
            return false;
        }

        if (inputdouble > endRange)
        {
            return false;
        }

        return true;
    }

    public static void Main() { }
}
