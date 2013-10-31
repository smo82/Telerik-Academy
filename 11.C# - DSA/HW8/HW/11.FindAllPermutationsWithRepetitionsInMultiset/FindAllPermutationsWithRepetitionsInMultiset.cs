/*
 * Task11*
 * 
 * Write a program to generate all permutations with repetitions of given multi-set. 
 * For example the multi-set {1, 3, 5, 5} has the following 12 unique permutations:
 * { 1, 3, 5, 5 }   { 1, 5, 3, 5 }
 * { 1, 5, 5, 3 }   { 3, 1, 5, 5 }
 * { 3, 5, 1, 5 }   { 3, 5, 5, 1 }
 * { 5, 1, 3, 5 }   { 5, 1, 5, 3 }
 * { 5, 3, 1, 5 }   { 5, 3, 5, 1 }
 * { 5, 5, 1, 3 }   { 5, 5, 3, 1 }
 * 
 * Ensure your program efficiently avoids duplicated permutations. 
 * Test it with { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FindAllPermutationsWithRepetitionsInMultisetMain
{
    private static List<UniquePair> subset = new List<UniquePair>();

    private static HashSet<string> foundSubsets = new HashSet<string>();
    private static int subsetUsed = 0;

    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter multiset lenght(N) :");
        int n = int.Parse(Console.ReadLine());

        UniquePair[] set = new UniquePair[n];
        for (int i = 0; i < n; i++)
        {
            set[i] = new UniquePair(i, Console.ReadLine());
        }

        PrintSubsets(set, set.Length);
    }

    private static void PrintSubsets(UniquePair[] set, int k)
    {
        if (k <= 0)
        {
            if (AddNewPairToAllFound())
            {
                PrintSingleSubset();
            }

            return;
        }

        for (int i = 0; i < set.Length; i++)
        {
            if ((subsetUsed & (1 << i)) == 0)
            {
                int currentSubsetUsed = subsetUsed;
                subsetUsed = subsetUsed | 1 << i;

                subset.Add(set[i]);
                PrintSubsets(set, k - 1);
                subset.RemoveAt(subset.Count - 1);

                subsetUsed = currentSubsetUsed;
            }
        }
    }

    private static bool AddNewPairToAllFound()
    {
        StringBuilder subsetValues = new StringBuilder();
        for (int i = 0; i < subset.Count; i++)
        {
            subsetValues.Append(subset[i].Value + ";");
        }

        if (foundSubsets.Contains(subsetValues.ToString()))
        {
            return false;
        }

        foundSubsets.Add(subsetValues.ToString());
        return true;
    }

    private static void PrintSingleSubset()
    {
        StringBuilder subsetToPrint = new StringBuilder();
        foreach (UniquePair item in subset)
        {
            subsetToPrint.Append(item.Value + " ");
        }

        Console.WriteLine(subsetToPrint.ToString());
    }
}