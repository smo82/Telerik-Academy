/*
 * Task01
 * 
 * Write a program that reads from the console a sequence of positive integer numbers. 
 * The sequence ends when empty line is entered. Calculate and print the sum and average of the elements of the sequence. 
 * Keep the sequence in List<int>.
 */

using System;
using System.Collections.Generic;

public class CalcSumAndAverage
{
    public static void Main(string[] args)
    {
        Console.WriteLine("We expect positive numbers!");
        List<int> numberCollection = FunctionsCollection.ReadIntListInRangeUptoEmptyLine(1, int.MaxValue);

        long sumNumbers = CalcIntCollectionSum(numberCollection);
        Console.WriteLine("The collection sum is: {0}", sumNumbers);

        double averageNumbers = CalcIntCollectionAverage(numberCollection);
        Console.WriteLine("The collection average is: {0}", averageNumbers);
    }

    private static double CalcIntCollectionAverage(List<int> intCollection)
    {
        if (intCollection.Count == 0)
        {
            return 0;
        }

        long sum = CalcIntCollectionSum(intCollection);
        double average = (double)sum / intCollection.Count;

        return average;
    }

    private static long CalcIntCollectionSum(List<int> intCollection)
    {
        long sum = 0;

        foreach (int number in intCollection)
        {
            sum += number;
        }

        return sum;
    }
}