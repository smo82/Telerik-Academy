/*
 * Task01
 * Add assertions in the code from the project "Assertions-Homework" to ensure all possible preconditions and postconditions are checked.
 */

using System;
using System.Diagnostics;

public class AssertionsHomework
{
    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        if (arr == null)
        {
            throw new ArgumentNullException("The input array should not be null");
        }

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        // I added a special function to check if the array is sorted. 
        // This way when the sorce is compiled in Release mode no additional checks will be done.
        Debug.Assert(IsArrayAscSorted<T>(arr), "The array is not correctly sorted");
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        if (arr == null)
        {
            throw new ArgumentNullException("The input array should not be null");
        }

        if (!IsArrayAscSorted<T>(arr))
        {
            throw new ArgumentException("The input array should be sorted");
        }

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "The input array should not be null");

        Debug.Assert(startIndex >= 0, "The start index should be bigger or equal to zero");

        Debug.Assert(startIndex < endIndex, "The end index should be bigger then the start index");

        Debug.Assert(endIndex < arr.Length, "The end index should be smaller then the number of elements of the array");
        
        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        Debug.Assert(IsMinElementIndex<T>(arr, startIndex, endIndex, minElementIndex), "The minimal index is not identified correctly");
        
        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "The input array should not be null");

        Debug.Assert(startIndex >= 0, "The start index should be bigger or equal to zero");

        Debug.Assert(startIndex < endIndex, "The end index should be bigger then the start index");

        Debug.Assert(endIndex < arr.Length, "The end index should be smaller then the number of elements of the array");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }

            Debug.Assert(arr[midIndex].CompareTo(value) != 0, "The value was found, but the method is not returning the correct index");
        }

        // Searched value not found
        return -1;
    }

    /*
     * The IsArrayAscSorted and the IsMinElementIndex methods are helping methods for checking the result of the other methods
     */
    private static bool IsArrayAscSorted<T>(T[] arr) where T : IComparable<T>
    {
        bool isArraySorted = true;
        for (int index = 0; index < arr.Length - 1; index++)
        {
            if (arr[index].CompareTo(arr[index + 1]) > 0)
            {
                isArraySorted = false;
                break;
            }
        }

        return isArraySorted;
    }

    private static bool IsMinElementIndex<T>(T[] arr, int startIndex, int endIndex, int minElementIndex)
        where T : IComparable<T>
    {
        bool isMinElementIndex = true;
        for (int i = startIndex; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                isMinElementIndex = false;
                break;
            }
        }

        return isMinElementIndex;
    }
}
