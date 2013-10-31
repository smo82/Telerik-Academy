/*
 * Task07
 * 
 * Write a program that finds in given array of integers (all belonging to the range [0..1000])
 * how many times each of them occurs.
 * 
 * Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
 * 2 -> 2 times
 * 3 -> 4 times
 * 4 -> 3 times
 */

using System;
using System.Collections.Generic;

public class CountOccurances
{
    public static void Main(string[] args)
    {
        Console.WriteLine("We expect numbers in the range [0 .. 1000]");
        int[] numbers = FunctionsCollection.ReadIntListInRangeUptoEmptyLine(0, 1000).ToArray();
        Dictionary<int, int> numbersCount = FunctionsCollection.GetNumbersCount(numbers);

        Console.WriteLine("The number occurances count is:");
        foreach (KeyValuePair<int, int> numberCount in numbersCount)
        {
            if (numberCount.Value == 1)
            {
                Console.WriteLine("{0} -> {1} time", numberCount.Key, numberCount.Value);
            }
            else
            {
                Console.WriteLine("{0} -> {1} times", numberCount.Key, numberCount.Value);
            }
        }
    }
}
