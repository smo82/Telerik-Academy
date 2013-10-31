/*
 * Task05
 * 
 * Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
 * Example: 
 * n=3, k=2, set = {hi, a, b} => (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
 */

using System;
using System.Collections.Generic;
using System.Text;

public class PrintOrderedSubsetsMain
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

        PrintSubsets(set, k);
    }

    private static void PrintSubsets(string[] set, int k)
    {
        if (k <= 0)
        {
            PrintSingleSubset();
            return;
        }

        for (int i = 0; i < set.Length; i++)
        {
            subset.Add(set[i]);
            PrintSubsets(set, k - 1);
            subset.RemoveAt(subset.Count - 1);
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