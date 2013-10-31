using System;

public class Report
{
    public void PrintStatistics(double[] arguments, int argumentsNumber)
    {
        if (arguments == null)
        {
            throw new ArgumentNullException("The arguments array should not be null!");
        }

        if (arguments.Length == 0)
        {
            throw new ArgumentException("The arguments array should not be empty!");
        }

        if (argumentsNumber <= 0)
        {
            throw new ArgumentException("The arguments number should not be zero or smaller then zero!");
        }

        double max = GetMax(arguments, argumentsNumber);
        PrintMax(max);

        double min = GetMin(arguments, argumentsNumber);
        PrintMin(min);

        double sum = GetSum(arguments, argumentsNumber);
        double avg = sum / argumentsNumber;
        PrintAvg(avg);
    }

    public void PrintMax(double max)
    {
        Console.WriteLine("The maximum is: {0}", max);
    }

    public void PrintMin(double min)
    {
        Console.WriteLine("The minimum is: {0}", min);
    }

    public void PrintAvg(double avg)
    {
        Console.WriteLine("The average is: {0}", avg);
    }

    private static double GetSum(double[] arr, int count)
    {
        double sum = 0;
        for (int i = 0; i < count; i++)
        {
            sum += arr[i];
        }
        return sum;
    }

    private static double GetMin(double[] arr, int count)
    {
        double min = arr[0];
        for (int i = 1; i < count; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }
        return min;
    }

    private static double GetMax(double[] arr, int count)
    {
        double max = arr[0];
        for (int i = 1; i < count; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }
}