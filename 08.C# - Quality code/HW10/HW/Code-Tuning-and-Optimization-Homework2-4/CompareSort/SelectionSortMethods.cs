using System;

public class SelectionSortMethods
{
    public static T[] SortGeneric<T>(T[] array) where T : IComparable
    {
        var arrayLength = array.Length;

        T[] sortedArray = new T[arrayLength];
        array.CopyTo(sortedArray, 0);

        for (int i = 0; i < arrayLength; i++)
        {
            T minElement = sortedArray[i];
            int minElementIndex = i;
            for (int j = i + 1; j < arrayLength; j++)
            {
                if (sortedArray[j].CompareTo(minElement) < 0)
                {
                    minElement = sortedArray[j];
                    minElementIndex = j;
                }
            }

            if (minElementIndex != i)
            {
                T tempElement = sortedArray[i];
                sortedArray[i] = minElement;
                sortedArray[minElementIndex] = tempElement;
            }
        }

        return sortedArray;
    }

    public static int[] SortInt(int[] array)
    {
        var arrayLength = array.Length;

        int[] sortedArray = new int[arrayLength];
        array.CopyTo(sortedArray, 0);

        for (int i = 0; i < arrayLength; i++)
        {
            int minElement = sortedArray[i];
            int minElementIndex = i;
            for (int j = i + 1; j < arrayLength; j++)
            {
                if (sortedArray[j].CompareTo(minElement) < 0)
                {
                    minElement = sortedArray[j];
                    minElementIndex = j;
                }
            }

            if (minElementIndex != i)
            {
                int tempElement = sortedArray[i];
                sortedArray[i] = minElement;
                sortedArray[minElementIndex] = tempElement;
            }
        }

        return sortedArray;
    }

    public static double[] SortDouble(double[] array)
    {
        var arrayLength = array.Length;

        double[] sortedArray = new double[arrayLength];
        array.CopyTo(sortedArray, 0);

        for (int i = 0; i < arrayLength; i++)
        {
            double minElement = sortedArray[i];
            int minElementIndex = i;
            for (int j = i + 1; j < arrayLength; j++)
            {
                if (sortedArray[j].CompareTo(minElement) < 0)
                {
                    minElement = sortedArray[j];
                    minElementIndex = j;
                }
            }

            if (minElementIndex != i)
            {
                double tempElement = sortedArray[i];
                sortedArray[i] = minElement;
                sortedArray[minElementIndex] = tempElement;
            }
        }

        return sortedArray;
    }

    public static string[] SortString(string[] array)
    {
        var arrayLength = array.Length;

        string[] sortedArray = new string[arrayLength];
        array.CopyTo(sortedArray, 0);

        for (int i = 0; i < arrayLength; i++)
        {
            string minElement = sortedArray[i];
            int minElementIndex = i;
            for (int j = i + 1; j < arrayLength; j++)
            {
                if (sortedArray[j].CompareTo(minElement) < 0)
                {
                    minElement = sortedArray[j];
                    minElementIndex = j;
                }
            }

            if (minElementIndex != i)
            {
                string tempElement = sortedArray[i];
                sortedArray[i] = minElement;
                sortedArray[minElementIndex] = tempElement;
            }
        }

        return sortedArray;
    }
}