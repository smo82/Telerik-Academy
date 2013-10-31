/*
 * Task02
 * Write a program to compare the performance of add, subtract, increment, multiply, divide 
 * for int, long, float, double and decimal values.
 */

using System;
using System.Diagnostics;

public class CompareEngine
{
    public static void Main(string[] args)
    {
        // ADD METHODS
        PrintAddMethodsComparison();
        Console.WriteLine(new string('-', 50));

        // SUBRACT METHODS
        PrintSubtractMethodsComparison();
        Console.WriteLine(new string('-', 50));

        // INCREMENT METHODS
        PrintIncrementMethodsComparison();
        Console.WriteLine(new string('-', 50));

        // MULTIPLICATION METHODS
        PrintMultiplyMethodsComparison();
        Console.WriteLine(new string('-', 50));

        // DIVISION METHODS
        PrintDivideMethodsComparison();
    }

    private static void PrintAddMethodsComparison()
    {
        Console.Write("{0, -30}", "Sum of ints: ");
        DisplayExecutionTime(() =>
        {
            AddMethods.AddInt(1, 2);
        });

        Console.Write("{0, -30}", "Sum of longs: ");
        DisplayExecutionTime(() =>
        {
            AddMethods.AddLong(1, 2);
        });

        Console.Write("{0, -30}", "Sum of floats: ");
        DisplayExecutionTime(() =>
        {
            AddMethods.AddFloat(1, 2);
        });

        Console.Write("{0, -30}", "Sum of doubles: ");
        DisplayExecutionTime(() =>
        {
            AddMethods.AddDouble(1, 2);
        });

        Console.Write("{0, -30}", "Sum of decimals: ");
        DisplayExecutionTime(() =>
        {
            AddMethods.AddDecimal(1, 2);
        });
    }

    private static void PrintSubtractMethodsComparison()
    {
        Console.Write("{0, -30}", "Subtraction of ints: ");
        DisplayExecutionTime(() =>
        {
            SubtractMethods.SubtractInt(1, 2);
        });

        Console.Write("{0, -30}", "Subtraction of longs: ");
        DisplayExecutionTime(() =>
        {
            SubtractMethods.SubtractLong(1, 2);
        });

        Console.Write("{0, -30}", "Subtraction of floats: ");
        DisplayExecutionTime(() =>
        {
            SubtractMethods.SubtractFloat(1, 2);
        });

        Console.Write("{0, -30}", "Subtraction of doubles: ");
        DisplayExecutionTime(() =>
        {
            SubtractMethods.SubtractDouble(1, 2);
        });

        Console.Write("{0, -30}", "Subtraction of decimals: ");
        DisplayExecutionTime(() =>
        {
            SubtractMethods.SubtractDecimal(1, 2);
        });
    }

    private static void PrintIncrementMethodsComparison()
    {
        Console.Write("{0, -30}", "Incremention of ints: ");
        DisplayExecutionTime(() =>
        {
            IncrementMethods.IncrementInt(1);
        });

        Console.Write("{0, -30}", "Incremention of longs: ");
        DisplayExecutionTime(() =>
        {
            IncrementMethods.IncrementLong(1);
        });

        Console.Write("{0, -30}", "Incremention of floats: ");
        DisplayExecutionTime(() =>
        {
            IncrementMethods.IncrementFloat(1);
        });

        Console.Write("{0, -30}", "Incremention of doubles: ");
        DisplayExecutionTime(() =>
        {
            IncrementMethods.IncrementDouble(1);
        });

        Console.Write("{0, -30}", "Incremention of decimals: ");
        DisplayExecutionTime(() =>
        {
            IncrementMethods.IncrementDecimal(1);
        });
    }

    private static void PrintMultiplyMethodsComparison()
    {
        Console.Write("{0, -30}", "Multiplication of ints: ");
        DisplayExecutionTime(() =>
        {
            MultiplicationMethods.MultiplyInt(1, 2);
        });

        Console.Write("{0, -30}", "Multiplication of longs: ");
        DisplayExecutionTime(() =>
        {
            MultiplicationMethods.MultiplyLong(1, 2);
        });

        Console.Write("{0, -30}", "Multiplication of floats: ");
        DisplayExecutionTime(() =>
        {
            MultiplicationMethods.MultiplyFloat(1, 2);
        });

        Console.Write("{0, -30}", "Multiplication of doubles: ");
        DisplayExecutionTime(() =>
        {
            MultiplicationMethods.MultiplyDouble(1, 2);
        });

        Console.Write("{0, -30}", "Multiplication of decimals: ");
        DisplayExecutionTime(() =>
        {
            MultiplicationMethods.MultiplyDecimal(1, 2);
        });
    }

    private static void PrintDivideMethodsComparison()
    {
        Console.Write("{0, -30}", "Division of ints: ");
        DisplayExecutionTime(() =>
        {
            DivisionMethods.DivideInt(1, 2);
        });

        Console.Write("{0, -30}", "Division of longs: ");
        DisplayExecutionTime(() =>
        {
            DivisionMethods.DivideLong(1, 2);
        });

        Console.Write("{0, -30}", "Division of floats: ");
        DisplayExecutionTime(() =>
        {
            DivisionMethods.DivideFloat(1, 2);
        });

        Console.Write("{0, -30}", "Division of doubles: ");
        DisplayExecutionTime(() =>
        {
            DivisionMethods.DivideDouble(1, 2);
        });

        Console.Write("{0, -30}", "Division of decimals: ");
        DisplayExecutionTime(() =>
        {
            DivisionMethods.DivideDecimal(1, 2);
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