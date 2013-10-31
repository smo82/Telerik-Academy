/*
 * Task04
 * 
 * Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n. 
 * Example:
 * n=3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}
 */

using System;
using System.Collections.Generic;
using System.Text;

public class PrintPermutationsMain
{
    private static List<int> permutations = new List<int>();

    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter N:");
        int n = int.Parse(Console.ReadLine());

        PrintPermutations(n, n);
    }

    private static void PrintPermutations(int n, int k)
    {
        if (k <= 0)
        {
            PrintSinglePermutation();
            return;
        }

        for (int i = 1; i <= n; i++)
        {
            if (permutations.IndexOf(i) == -1)
            {
                permutations.Add(i);
                PrintPermutations(n, k - 1);
                permutations.RemoveAt(permutations.Count - 1);
            }
        }
    }

    private static void PrintSinglePermutation()
    {
        StringBuilder combinationToPrint = new StringBuilder();
        foreach (int item in permutations)
        {
            combinationToPrint.Append(item + " ");
        }

        Console.WriteLine(combinationToPrint.ToString());
    }
}