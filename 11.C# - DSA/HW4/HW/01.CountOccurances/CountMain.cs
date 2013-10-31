/*
 * Task01
 * 
 * Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
 * Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
 * -2.5 -> 2 times
 * 3 -> 4 times
 * 4 -> 3 times
 */

using System;
using System.Collections.Generic;

class CountMain
{
    static void Main(string[] args)
    {
        Dictionary<double, int> valuesCount = new Dictionary<double, int>();

        List<double> values = FunctionCollection.ReadDoubleListInRangeUptoEmptyLine();

        valuesCount = FunctionCollection.CountValues<double>(values);

        Console.Clear();
        Console.WriteLine("The values count is:");

        PrintDictionary(valuesCount);
    }

    private static void PrintDictionary(Dictionary<double, int> valuesCount)
    {
        foreach (KeyValuePair<double, int> valueCount in valuesCount)
        {
            Console.WriteLine("{0, 8} : {1,4}", valueCount.Key, valueCount.Value);
        }
    }
}