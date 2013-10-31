using System;

public class InsertionSortMethods
{
    public static T[] SortGeneric<T>(T[] array) where T : IComparable
    {
        var arrayLength = array.Length;

        T[] sortedArray = new T[arrayLength];
        array.CopyTo(sortedArray, 0);

        for (int i = 1; i < arrayLength; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (sortedArray[j].CompareTo(sortedArray[j - 1]) < 0)
                {
                    var intermediateValue = sortedArray[j];
                    sortedArray[j] = sortedArray[j - 1];
                    sortedArray[j - 1] = intermediateValue;
                }
            }
        }

        return sortedArray;
    }

    public static int[] SortInt(int[] array)
    {
        var arrayLength = array.Length;

        int[] sortedArray = new int[arrayLength];
        array.CopyTo(sortedArray, 0);

        for (int i = 1; i < arrayLength; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (sortedArray[j].CompareTo(sortedArray[j - 1]) < 0)
                {
                    var intermediateValue = sortedArray[j];
                    sortedArray[j] = sortedArray[j - 1];
                    sortedArray[j - 1] = intermediateValue;
                }
            }
        }

        return sortedArray;
    }

    public static double[] SortDouble(double[] array)
    {
        var arrayLength = array.Length;

        double[] sortedArray = new double[arrayLength];
        array.CopyTo(sortedArray, 0);

        for (int i = 1; i < arrayLength; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (sortedArray[j].CompareTo(sortedArray[j - 1]) < 0)
                {
                    var intermediateValue = sortedArray[j];
                    sortedArray[j] = sortedArray[j - 1];
                    sortedArray[j - 1] = intermediateValue;
                }
            }
        }

        return sortedArray;
    }

    public static string[] SortString(string[] array)
    {
        var arrayLength = array.Length;

        string[] sortedArray = new string[arrayLength];
        array.CopyTo(sortedArray, 0);

        for (int i = 1; i < arrayLength; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (sortedArray[j].CompareTo(sortedArray[j - 1]) < 0)
                {
                    var intermediateValue = sortedArray[j];
                    sortedArray[j] = sortedArray[j - 1];
                    sortedArray[j - 1] = intermediateValue;
                }
            }
        }

        return sortedArray;
    }
}