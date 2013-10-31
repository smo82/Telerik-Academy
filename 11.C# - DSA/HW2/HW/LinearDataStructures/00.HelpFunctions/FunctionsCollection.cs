using System;
using System.Collections.Generic;

public class FunctionsCollection
{
    public static LinkedList<int> ReadIntLinkedListUptoEmptyLine()
    {
        LinkedList<int> intCollection = new LinkedList<int>();
        Console.WriteLine("Enter the sequence of numbers:");
        int? inputInt = ReadIntInRangeOrEmpty();

        while (inputInt != null)
        {
            intCollection.AddLast((int)inputInt);
            Console.WriteLine("Enter the next number:");
            inputInt = ReadIntInRangeOrEmpty();
        }

        return intCollection;
    }
        
    public static List<int> ReadIntListInRangeUptoEmptyLine(
        int startRange = int.MinValue, int endRange = int.MaxValue)
    {
        List<int> intCollection = new List<int>();
        Console.WriteLine("Enter the sequence of numbers:");
        int? inputInt = ReadIntInRangeOrEmpty(startRange, endRange);

        while (inputInt != null)
        {
            intCollection.Add((int)inputInt);
            Console.WriteLine("Enter the next number:");
            inputInt = ReadIntInRangeOrEmpty(startRange, endRange);
        }

        return intCollection;
    }

    public static int? ReadIntInRangeOrEmpty(int startRange = int.MinValue, int endRange = int.MaxValue)
    {
        string input = Console.ReadLine();
        int inputInt = -1;

        while ((input != string.Empty) && (!ParseIntInRange(input, startRange, endRange, out inputInt)))
        {
            Console.WriteLine("Incorrect number! Please try again:");
            input = Console.ReadLine();
        }

        if (input == string.Empty)
        {
            return null;
        }

        return inputInt;
    }

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

    public static Dictionary<int, int> GetNumbersCount(IEnumerable<int> numbers)
    {
        Dictionary<int, int> occurances = new Dictionary<int, int>();

        foreach (int number in numbers)
        {
            if (occurances.ContainsKey(number))
            {
                occurances[number]++;
            }
            else
            {
                occurances[number] = 1;
            }
        }

        return occurances;
    }
    
    public static void PrintIntList(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }
    }

    public static void PrintIntLinkedList(LinkedList<int> numbers)
    {
        foreach (int number in numbers)
        {
            Console.Write("{0} ", number);
        }
    }

    public static void Main()
    {
    }
}