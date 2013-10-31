using System;
using System.Collections.Generic;

class FindExactSequence
{
    static void Main()
    {
        Console.Write("Enter the searched sum:");
        int searchedSum;

        while (!int.TryParse(Console.ReadLine(), out searchedSum)) 
        {
            Console.Write("Wrong searched sum. Please try again:");
        }

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

        List<int> exactSumElements = new List<int>();
        int indexSearch = 0;
        while ((exactSumElements.Count == 0) && (indexSearch<numberElements))
        {
            int currentSum = elementsArr[indexSearch];
            int indexSubSearch = indexSearch + 1;
            List<int> subElementsList = new List<int>();
            subElementsList.Add(elementsArr[indexSearch]);

            while ((currentSum != searchedSum) && (indexSubSearch < numberElements))
            {
                currentSum += elementsArr[indexSubSearch];
                subElementsList.Add(elementsArr[indexSubSearch]);
                indexSubSearch++;
            }

            if (currentSum == searchedSum)
            {
                exactSumElements.AddRange(subElementsList);
            }

            indexSearch++;
        }

        if (exactSumElements.Count > 0)
        {
            Console.WriteLine("There is a sequence with that exact sum: " + String.Join(", ", exactSumElements));
        }
        else
        {
            Console.WriteLine("There is no sequence with that exact sum!");
        }
    }
}
