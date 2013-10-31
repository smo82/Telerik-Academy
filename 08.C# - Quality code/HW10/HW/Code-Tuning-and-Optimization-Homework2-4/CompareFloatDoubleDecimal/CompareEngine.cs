/*
 * Task03
 * Write a program to compare the performance of square root, natural logarithm, sinus for float, double and decimal values.
 */

using System;
using System.Diagnostics;

internal class CompareEngine
{
    private static void Main(string[] args)
    {
        // SQUARE ROOT METHODS
        PrintSquareRootMethodsComparison();
        Console.WriteLine(new string('-', 50));

        // NATURAL LOGARITHM METHODS
        PrintLnMethodsComparison();
        Console.WriteLine(new string('-', 50));

        // SINUS METHODS
        PrintSinMethodsComparison();
        Console.WriteLine(new string('-', 50));
    }

    private static void PrintSquareRootMethodsComparison()
    {
        Console.Write("{0, -30}", "Square root of float: ");
        DisplayExecutionTime(() =>
        {
            SquareRootMethods.SquareRootFloat(1);
        });

        Console.Write("{0, -30}", "Square root of double: ");
        DisplayExecutionTime(() =>
        {
            SquareRootMethods.SquareRootDouble(1);
        });

        Console.Write("{0, -30}", "Square root of decimal: ");
        DisplayExecutionTime(() =>
        {
            SquareRootMethods.SquareRootDecimal(1);
        });
    }

    private static void PrintLnMethodsComparison()
    {
        Console.Write("{0, -30}", "Natural logarithm of float: ");
        DisplayExecutionTime(() =>
        {
            LnMethods.LnFloat(1);
        });

        Console.Write("{0, -30}", "Natural logarithm of double: ");
        DisplayExecutionTime(() =>
        {
            LnMethods.LnDouble(1);
        });

        Console.Write("{0, -30}", "Natural logarithm of decimal: ");
        DisplayExecutionTime(() =>
        {
            LnMethods.LnDecimal(1);
        });
    }

    private static void PrintSinMethodsComparison()
    {
        Console.Write("{0, -30}", "Sinus of float: ");
        DisplayExecutionTime(() =>
        {
            SinusMethods.SinusFloat(1);
        });

        Console.Write("{0, -30}", "Sinus of double: ");
        DisplayExecutionTime(() =>
        {
            SinusMethods.SinusDouble(1);
        });

        Console.Write("{0, -30}", "Sinus of decimal: ");
        DisplayExecutionTime(() =>
        {
            SinusMethods.SinusDecimal(1);
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