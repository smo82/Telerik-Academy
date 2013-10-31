/*
 * Task04
 * 
 * Write a method that finds the longest subsequence of equal numbers in given List<int> and 
 * returns the result as new List<int>. Write a program to test whether the method works correctly.
 */

using System;
using System.Collections.Generic;
using System.Linq;

public class ListMethods
{
    public static void Main(string[] args)
    {
        List<int> numbers = FunctionsCollection.ReadIntListInRangeUptoEmptyLine();
        List<int> longestSubsequence = GetLongestSubsequence(numbers);

        Console.WriteLine("The longest subsequence in the list is:");
        FunctionsCollection.PrintIntList(longestSubsequence);

        // For more test see the test class ListMethodsTest.cs
    }

    public static List<int> GetLongestSubsequence(List<int> numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException("The input list of numbers cannot be null!");
        }

        List<int> resultList = new List<int>();

        if (numbers.Count == 0)
        {
            return resultList;
        }

        int maxSequenceCount = 0;
        int maxSequenceNumber = numbers[0];
        int currentNumber = numbers[0];
        int currentSequenceCount = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (currentNumber != numbers[i])
            {
                currentNumber = numbers[i];
                currentSequenceCount = 1;
            }
            else
            {
                currentSequenceCount++;
            }

            if (currentSequenceCount > maxSequenceCount)
            {
                maxSequenceCount = currentSequenceCount;
                maxSequenceNumber = numbers[i];
            }
        }

        resultList = Enumerable.Repeat(maxSequenceNumber, maxSequenceCount).ToList();
        return resultList;
    }
}