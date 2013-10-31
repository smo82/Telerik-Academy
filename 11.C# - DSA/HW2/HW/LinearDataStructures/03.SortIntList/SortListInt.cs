/*
 * Task03
 * 
 * Write a program that reads a sequence of integers (List<int>) ending with an empty line and 
 * sorts them in an increasing order.
 */

using System;
using System.Collections.Generic;

public class SortListInt
{
    public static void Main(string[] args)
    {
        List<int> numbers = FunctionsCollection.ReadIntListInRangeUptoEmptyLine();
        numbers.Sort();

        Console.WriteLine("The sorted list is:");
        FunctionsCollection.PrintIntList(numbers);
    }
}