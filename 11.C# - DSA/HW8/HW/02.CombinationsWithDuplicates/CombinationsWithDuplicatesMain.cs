/*
 * Task02
 * 
 * Write a recursive program for generating and printing all the combinations with duplicates of k elements from n-element set. 
 * Example:
 * n=3, k=2  (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
 */

using System;
using System.Collections.Generic;
using System.Text;

public class CombinationsWithDuplicatesMain
{
    private static List<int> combination = new List<int>();

    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter N:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Please enter K:");
        int k = int.Parse(Console.ReadLine());

        PrintCombinationsWithDuplicates(1, n, k);
    }

    private static void PrintCombinationsWithDuplicates(int startIndex, int n, int k)
    {
        if (k <= 0)
        {
            PrintCombination();
            return;
        }

        for (int i = startIndex; i <= n; i++)
        {
            combination.Add(i);
            PrintCombinationsWithDuplicates(i, n, k - 1);
            combination.RemoveAt(combination.Count - 1);
        }
    }

    private static void PrintCombination()
    {
        StringBuilder combinationToPrint = new StringBuilder();
        foreach (int item in combination)
        {
            combinationToPrint.Append(item + " ");
        }

        Console.WriteLine(combinationToPrint.ToString());
    }
}