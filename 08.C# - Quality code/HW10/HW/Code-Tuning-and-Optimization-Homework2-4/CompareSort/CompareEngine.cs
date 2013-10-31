/*
 * Task04
 * Write a program to compare the performance of insertion sort, selection sort, quicksort for int, double and string values. 
 * Check also the following cases: random values, sorted values, values sorted in reversed order.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;

internal class CompareEngine
{
    private static readonly int[] INT_ARRAY_RANDOM = new int[] { 2, 1, 4, 1, 7, 5 };
    private static readonly int[] INT_ARRAY_SORTED_ASC = new int[] { 1, 1, 2, 4, 5, 7 };
    private static readonly int[] INT_ARRAY_SORTED_DESC = new int[] { 7, 5, 4, 2, 1, 1 };

    private static readonly double[] DOUBLE_ARRAY_RANDOM = new double[] { 2, 1, 4, 1, 7, 5 };
    private static readonly double[] DOUBLE_ARRAY_SORTED_ASC = new double[] { 1, 1, 2, 4, 5, 7 };
    private static readonly double[] DOUBLE_ARRAY_SORTED_DESC = new double[] { 7, 5, 4, 2, 1, 1 };

    private static readonly string[] STRING_ARRAY_RANDOM = new string[] { "a", "b", "aa", "zzz", "bb", "a" };
    private static readonly string[] STRING_ARRAY_SORTED_ASC = new string[] { "a", "a", "aa", "b", "bb", "zzz" };
    private static readonly string[] STRING_ARRAY_SORTED_DESC = new string[] { "zzz", "bb", "b", "aa", "a", "a" };

    private static readonly List<int> INT_LIST_RANDOM = new List<int>(INT_ARRAY_RANDOM);
    private static readonly List<int> INT_LIST_SORTED_ASC = new List<int>(INT_ARRAY_SORTED_ASC);
    private static readonly List<int> INT_LIST_SORTED_DESC = new List<int>(INT_ARRAY_SORTED_DESC);

    private static readonly List<double> DOUBLE_LIST_RANDOM = new List<double>(DOUBLE_ARRAY_RANDOM);
    private static readonly List<double> DOUBLE_LIST_SORTED_ASC = new List<double>(DOUBLE_ARRAY_SORTED_ASC);
    private static readonly List<double> DOUBLE_LIST_SORTED_DESC = new List<double>(DOUBLE_ARRAY_SORTED_DESC);

    private static readonly List<string> STRING_LIST_RANDOM = new List<string>(STRING_ARRAY_RANDOM);
    private static readonly List<string> STRING_LIST_SORTED_ASC = new List<string>(STRING_ARRAY_SORTED_ASC);
    private static readonly List<string> STRING_LIST_SORTED_DESC = new List<string>(STRING_ARRAY_SORTED_DESC);

    private static void Main(string[] args)
    {
        // INSERTION SORT METHODS
        PrintInsertionSortGenericComparison();

        // PrintInsertionSortComparison();       
        Console.WriteLine(new string('-', 70));

        // SELECTION SORT METHODS
        PrintSelectionSortComparison();

        // PrintSelectionSortGenericComparison();
        Console.WriteLine(new string('-', 70));

        // QUICK SORT METHODS
        PrintQuickSortComparison();

        // PrintQuickSortGenericComparison();
        Console.WriteLine(new string('-', 70));
    }

    private static void PrintInsertionSortComparison()
    {
        Console.Write("{0, -50}", "Insertion Sort of random int array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortInt(INT_ARRAY_RANDOM);
        });

        Console.Write("{0, -50}", "Insertion Sort of asc sorted int array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortInt(INT_ARRAY_SORTED_ASC);
        });

        Console.Write("{0, -50}", "Insertion Sort of desc sorted int array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortInt(INT_ARRAY_SORTED_DESC);
        });

        Console.WriteLine();

        Console.Write("{0, -50}", "Insertion Sort of random double array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortDouble(DOUBLE_ARRAY_RANDOM);
        });

        Console.Write("{0, -50}", "Insertion Sort of asc sorted double array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortDouble(DOUBLE_ARRAY_SORTED_ASC);
        });

        Console.Write("{0, -50}", "Insertion Sort of desc sorted double array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortDouble(DOUBLE_ARRAY_SORTED_DESC);
        });

        Console.WriteLine();

        Console.Write("{0, -50}", "Insertion Sort of random string array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortString(STRING_ARRAY_RANDOM);
        });

        Console.Write("{0, -50}", "Insertion Sort of asc sorted string array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortString(STRING_ARRAY_SORTED_ASC);
        });

        Console.Write("{0, -50}", "Insertion Sort of desc sorted string array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortString(STRING_ARRAY_SORTED_DESC);
        });
    }

    private static void PrintInsertionSortGenericComparison()
    {
        Console.Write("{0, -50}", "Insertion Sort of random int array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortGeneric<int>(INT_ARRAY_RANDOM);
        });

        Console.Write("{0, -50}", "Insertion Sort of asc sorted int array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortGeneric<int>(INT_ARRAY_SORTED_ASC);
        });

        Console.Write("{0, -50}", "Insertion Sort of desc sorted int array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortGeneric<int>(INT_ARRAY_SORTED_DESC);
        });

        Console.WriteLine();
        
        Console.Write("{0, -50}", "Insertion Sort of random double array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortGeneric<double>(DOUBLE_ARRAY_RANDOM);
        });

        Console.Write("{0, -50}", "Insertion Sort of asc sorted double array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortGeneric<double>(DOUBLE_ARRAY_SORTED_ASC);
        });

        Console.Write("{0, -50}", "Insertion Sort of desc sorted double array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortGeneric<double>(DOUBLE_ARRAY_SORTED_DESC);
        });

        Console.WriteLine();

        Console.Write("{0, -50}", "Insertion Sort of random string array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortGeneric<string>(STRING_ARRAY_RANDOM);
        });

        Console.Write("{0, -50}", "Insertion Sort of asc sorted string array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortGeneric<string>(STRING_ARRAY_SORTED_ASC);
        });

        Console.Write("{0, -50}", "Insertion Sort of desc sorted string array: ");
        DisplayExecutionTime(() =>
        {
            InsertionSortMethods.SortGeneric<string>(STRING_ARRAY_SORTED_DESC);
        });
    }

    private static void PrintSelectionSortComparison()
    {
        Console.Write("{0, -50}", "Selection Sort of random int array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortInt(INT_ARRAY_RANDOM);
        });

        Console.Write("{0, -50}", "Selection Sort of asc sorted int array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortInt(INT_ARRAY_SORTED_ASC);
        });

        Console.Write("{0, -50}", "Selection Sort of desc sorted int array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortInt(INT_ARRAY_SORTED_DESC);
        });

        Console.WriteLine();

        Console.Write("{0, -50}", "Selection Sort of random double array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortDouble(DOUBLE_ARRAY_RANDOM);
        });

        Console.Write("{0, -50}", "Selection Sort of asc sorted double array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortDouble(DOUBLE_ARRAY_SORTED_ASC);
        });

        Console.Write("{0, -50}", "Selection Sort of desc sorted double array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortDouble(DOUBLE_ARRAY_SORTED_DESC);
        });

        Console.WriteLine();

        Console.Write("{0, -50}", "Selection Sort of random string array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortString(STRING_ARRAY_RANDOM);
        });

        Console.Write("{0, -50}", "Selection Sort of asc sorted string array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortString(STRING_ARRAY_SORTED_ASC);
        });

        Console.Write("{0, -50}", "Selection Sort of desc sorted string array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortString(STRING_ARRAY_SORTED_DESC);
        });
    }

    private static void PrintSelectionSortGenericComparison()
    {
        Console.Write("{0, -50}", "Selection Sort of random int array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortGeneric<int>(INT_ARRAY_RANDOM);
        });

        Console.Write("{0, -50}", "Selection Sort of asc sorted int array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortGeneric<int>(INT_ARRAY_SORTED_ASC);
        });

        Console.Write("{0, -50}", "Selection Sort of desc sorted int array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortGeneric<int>(INT_ARRAY_SORTED_DESC);
        });

        Console.WriteLine();

        Console.Write("{0, -50}", "Selection Sort of random double array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortGeneric<double>(DOUBLE_ARRAY_RANDOM);
        });

        Console.Write("{0, -50}", "Selection Sort of asc sorted double array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortGeneric<double>(DOUBLE_ARRAY_SORTED_ASC);
        });

        Console.Write("{0, -50}", "Selection Sort of desc sorted double array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortGeneric<double>(DOUBLE_ARRAY_SORTED_DESC);
        });

        Console.WriteLine();

        Console.Write("{0, -50}", "Selection Sort of random string array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortGeneric<string>(STRING_ARRAY_RANDOM);
        });

        Console.Write("{0, -50}", "Selection Sort of asc sorted string array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortGeneric<string>(STRING_ARRAY_SORTED_ASC);
        });

        Console.Write("{0, -50}", "Selection Sort of desc sorted string array: ");
        DisplayExecutionTime(() =>
        {
            SelectionSortMethods.SortGeneric<string>(STRING_ARRAY_SORTED_DESC);
        });
    }

    private static void PrintQuickSortComparison()
    {
        Console.Write("{0, -50}", "QuickSort of random int list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortInt(INT_LIST_RANDOM);
        });

        Console.Write("{0, -50}", "QuickSort of asc sorted int list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortInt(INT_LIST_SORTED_ASC);
        });

        Console.Write("{0, -50}", "QuickSort of desc sorted int list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortInt(INT_LIST_SORTED_DESC);
        });

        Console.WriteLine();

        Console.Write("{0, -50}", "QuickSort of random double list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortDouble(DOUBLE_LIST_RANDOM);
        });

        Console.Write("{0, -50}", "QuickSort of asc sorted double list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortDouble(DOUBLE_LIST_SORTED_ASC);
        });

        Console.Write("{0, -50}", "QuickSort of desc sorted double list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortDouble(DOUBLE_LIST_SORTED_DESC);
        });

        Console.WriteLine();

        Console.Write("{0, -50}", "QuickSort of random string list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortString(STRING_LIST_RANDOM);
        });

        Console.Write("{0, -50}", "QuickSort of asc sorted string list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortString(STRING_LIST_SORTED_ASC);
        });

        Console.Write("{0, -50}", "QuickSort of desc sorted string list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortString(STRING_LIST_SORTED_DESC);
        });
    }

    private static void PrintQuickSortGenericComparison()
    {
        Console.Write("{0, -50}", "QuickSort of random int list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortGeneric<int>(INT_LIST_RANDOM);
        });

        Console.Write("{0, -50}", "QuickSort of asc sorted int list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortGeneric<int>(INT_LIST_SORTED_ASC);
        });

        Console.Write("{0, -50}", "QuickSort of desc sorted int list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortGeneric<int>(INT_LIST_SORTED_DESC);
        });

        Console.WriteLine();

        Console.Write("{0, -50}", "QuickSort of random double list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortGeneric<double>(DOUBLE_LIST_RANDOM);
        });

        Console.Write("{0, -50}", "QuickSort of asc sorted double list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortGeneric<double>(DOUBLE_LIST_SORTED_ASC);
        });

        Console.Write("{0, -50}", "QuickSort of desc sorted double list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortGeneric<double>(DOUBLE_LIST_SORTED_DESC);
        });

        Console.WriteLine();

        Console.Write("{0, -50}", "QuickSort of random string list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortGeneric<string>(STRING_LIST_RANDOM);
        });

        Console.Write("{0, -50}", "QuickSort of asc sorted string list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortGeneric<string>(STRING_LIST_SORTED_ASC);
        });

        Console.Write("{0, -50}", "QuickSort of desc sorted string list: ");
        DisplayExecutionTime(() =>
        {
            QuickSortMethods.SortGeneric<string>(STRING_LIST_SORTED_DESC);
        });
    }

    private static void DisplayExecutionTime(Action action)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            action();
        }

        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
    }
}