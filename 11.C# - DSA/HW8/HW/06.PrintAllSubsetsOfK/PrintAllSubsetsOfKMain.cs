/*
 * Task06
 * 
 * Write a program for generating and printing all subsets of k strings from given set of strings.
 * Example: 
 * s = {test, rock, fun}, k=2 => (test rock),  (test fun),  (rock fun)
 */

using System;
using System.Collections.Generic;
using System.Text;

public class PrintAllSubsetsOfKMain
{
    private static List<string> subset = new List<string>();

    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter N:");
        int n = int.Parse(Console.ReadLine());

        string[] set = new string[n];
        for (int i = 0; i < n; i++)
        {
            set[i] = Console.ReadLine();
        }

        Console.WriteLine("Please enter K:");
        int k = int.Parse(Console.ReadLine());

        PrintSubsets(0, set, k);
    }

    private static void PrintSubsets(int startIndex, string[] set, int k)
    {
        if (k <= 0)
        {
            PrintSingleSubset();
            return;
        }

        for (int i = startIndex; i < set.Length; i++)
        {
            if (subset.IndexOf(set[i]) == -1)
            {
                subset.Add(set[i]);
                PrintSubsets(i + 1, set, k - 1);
                subset.RemoveAt(subset.Count - 1);
            }
        }
    }

    private static void PrintSingleSubset()
    {
        StringBuilder subsetToPrint = new StringBuilder();
        foreach (string item in subset)
        {
            subsetToPrint.Append(item + " ");
        }

        Console.WriteLine(subsetToPrint.ToString());
    }
}