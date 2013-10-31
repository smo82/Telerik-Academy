using System;
using System.Collections.Generic;

class SequenceWithMaxSum
{
    static void Main()
    {
        Console.Write("Enter the length of the array:");
        int numberElements;

        while ((!int.TryParse(Console.ReadLine(), out numberElements)) || (numberElements <= 0))
        {
            Console.Write("Wrong length. Please try again:");
        }

        int[] elementsArr = new int[numberElements];
        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("Enter element {0}:", i);
            elementsArr[i] = int.Parse(Console.ReadLine());
        }


        int currentSum = 0;
        int biggestSum = int.MinValue;
        List<int> currentSequence = new List<int>();
        List<int> biggestSequence = new List<int>();

        for (int i = 0; i < numberElements; i++)
        {
            currentSum += elementsArr[i];
            currentSequence.Add(elementsArr[i]);

            if (biggestSum < currentSum)
            {
                biggestSequence.Clear();
                biggestSequence.AddRange(currentSequence);
                biggestSum = currentSum;
            }
            
            if (currentSum <= 0)
            {
                currentSum = 0;
                currentSequence.Clear();
            }
        }

        Console.Write("The sequence with the biggest sum is:");
        Console.WriteLine(String.Join(", ", biggestSequence));
    }
}
