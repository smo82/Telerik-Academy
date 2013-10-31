/*
 * Task01
 * 
 * Write a recursive program that simulates the execution of n nested loops from 1 to n. Examples:
 * 
 *                          1 1 1
 *                          1 1 2
 *                          1 1 3
 *         1 1              1 2 1
 *n=2  ->  1 2      n=3  ->  ...
 *         2 1              3 2 3
 *         2 2              3 3 1
 *                          3 3 2
 *                          3 3 3
 */

using System;

public class SimulateNestedLoopsMain
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter the number of nested loops (N):");
        int n = int.Parse(Console.ReadLine());

        NestedLoopsSimulate(n, string.Empty, n);
    }

    private static void NestedLoopsSimulate(int n, string toPrint, int count)
    {
        if (count <= 0)
        {
            Console.WriteLine(toPrint);
            return;
        }

        for (int i = 1; i <= n; i++)
        {
            NestedLoopsSimulate(n, toPrint + i + " ", count - 1);
        }
    }
}
