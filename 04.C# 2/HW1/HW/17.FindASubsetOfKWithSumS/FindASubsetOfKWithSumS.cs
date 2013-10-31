using System;
using System.Collections.Generic;

class FindASubsetOfKWithSumS
{
    static void Main()
    {
        Console.Write("Enter the target sum:");
        int targetSum;

        while ((!int.TryParse(Console.ReadLine(), out targetSum)) || (targetSum <= 0))
        {
            Console.Write("Wrong sum. Please try again:");
        }

        Console.Write("Enter the length of the array:");
        int numberElements;

        while ((!int.TryParse(Console.ReadLine(), out numberElements)) || (numberElements <= 0))
        {
            Console.Write("Wrong length. Please try again:");
        }

        //We read the elements in a List and filter those that are bigger then our target sum
        List<int> elementsList = new List<int>();
        int nextNumber = 0;
        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("Enter element {0}:", i);
            nextNumber = int.Parse(Console.ReadLine());
            if (nextNumber < targetSum)
            {
                elementsList.Add(nextNumber);
            }
        }

        Console.Write("Enter the length of the target subset:");
        int targetSubsetLength;

        while ((!int.TryParse(Console.ReadLine(), out targetSubsetLength)) || (targetSubsetLength <= 0))
        {
            Console.Write("Wrong sum. Please try again:");
        }

        int subSetMask = (int)Math.Pow(2, elementsList.Count) - 1;
        List<int> subsetList = new List<int>();

        int maskIndex = (int)Math.Pow(2, targetSubsetLength) - 1;
        int currentSum = 0;
        while ((maskIndex <= subSetMask) && (currentSum != targetSum))
        {
            subsetList.Clear();
            currentSum = 0;
            int elementsCount = 0;
            int elementIndex = 0;
            while ((elementsCount < targetSubsetLength) && (elementIndex < elementsList.Count))
            {
                int subMask = 1 << elementIndex;
                if ((maskIndex & subMask) == subMask)
                {
                    elementsCount++;
                    currentSum += elementsList[elementIndex];
                    subsetList.Add(elementsList[elementIndex]);
                }
                elementIndex++;
            }

            maskIndex++;
        }

        if (currentSum == targetSum)
        {
            Console.WriteLine(String.Join(", ", subsetList));
        }
        else
        {
            Console.WriteLine("There is no subset with that sum!");
        }
    }
}
