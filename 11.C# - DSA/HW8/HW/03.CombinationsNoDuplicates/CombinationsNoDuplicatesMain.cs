/*
 * Task03
 * 
 * Modify the previous program to skip duplicates:
 * n=4, k=2 -> (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
 */
using System;
using System.Collections.Generic;
using System.Text;

public class CombinationsNoDuplicatesMain
{
    private static List<int> combination = new List<int>();

    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter N:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Please enter K:");
        int k = int.Parse(Console.ReadLine());

        PrintCombinationsNoDuplicates(1, n, k);
    }

    private static void PrintCombinationsNoDuplicates(int startIndex, int n, int k)
    {
        if (k <= 0)
        {
            PrintCombination();
            return;
        }

        for (int i = startIndex; i <= n; i++)
        {
            combination.Add(i);
            PrintCombinationsNoDuplicates(i + 1, n, k - 1);
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