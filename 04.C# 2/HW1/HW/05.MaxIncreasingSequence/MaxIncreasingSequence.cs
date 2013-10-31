using System;
using System.Collections.Generic;

class MaxIncreasingSequence
{
    static void Main()
    {
        Console.Write("Enter the length of the array:");
        int numberElements;

        while ((!int.TryParse(Console.ReadLine(), out numberElements)) || (numberElements <= 0))
        {
            Console.Write("Wrong length. Please try again:");
        }

        int[] inputArrNumber = new int[numberElements];

        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("Please enter item {0}:", i);
            inputArrNumber[i] = int.Parse(Console.ReadLine());
        }

        List<int> currentIncreasingSequence = new List<int>();
        List<int> longestIncreasingSequence = new List<int>();
        currentIncreasingSequence.Add(inputArrNumber[0]);
        int currentMaxLength = 1;
        int longestMaxLength = 0;

        for (int i = 1; i < inputArrNumber.Length; i++)
        {
            if (inputArrNumber[i] == (currentIncreasingSequence[currentMaxLength-1] + 1))
            {
                currentMaxLength++;
            }
            else if (longestMaxLength < currentMaxLength)
            {
                longestIncreasingSequence.Clear();
                longestIncreasingSequence.AddRange(currentIncreasingSequence);
                longestMaxLength = currentMaxLength;

                currentMaxLength = 1;
                currentIncreasingSequence.Clear(); 
            }
            else
            {
                currentMaxLength = 1;
                currentIncreasingSequence.Clear();
            }

            currentIncreasingSequence.Add(inputArrNumber[i]);
        }

        if (longestMaxLength < currentMaxLength)
        {
            longestIncreasingSequence.Clear();
            longestIncreasingSequence.AddRange(currentIncreasingSequence);
        }

        Console.WriteLine(new String('*', 30));
        Console.WriteLine("The Longest Increasing Sequence is:");

        foreach (int numberInSequence in longestIncreasingSequence)
        {
            Console.Write("{0} ", numberInSequence);
        }
    }
}