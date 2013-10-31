/*
 * Task08*
 * 
 * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
 * Write a program to find the majorant of given array (if exists). 
 * 
 * Example:
 * {2, 2, 3, 3, 2, 3, 4, 3, 3} -> 3
 */
using System;
using System.Collections.Generic;

public class FindMajorantInArray
{
    public static void Main(string[] args)
    {
        int[] numbers = FunctionsCollection.ReadIntListInRangeUptoEmptyLine().ToArray();
        Dictionary<int, int> numbersCount = FunctionsCollection.GetNumbersCount(numbers);

        int? majorant = FindMajorant(numbersCount, numbers.Length);

        if (majorant == null)
        {
            Console.WriteLine("There is no majorant of that sequence!");
        }
        else
        {
            Console.WriteLine("The majorant is: {0}", majorant);
        }
    }
  
    private static int? FindMajorant(Dictionary<int, int> numbersCount, int numberOfElements)
    {
        int targetCount = (numberOfElements / 2) + 1;
        foreach (KeyValuePair<int, int> numberCount in numbersCount)
        {
            if (numberCount.Value >= targetCount)
            {
                return numberCount.Key;
            }
        }

        return null;
    }
}
