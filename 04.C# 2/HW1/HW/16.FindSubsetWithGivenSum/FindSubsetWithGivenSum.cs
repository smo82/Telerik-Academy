using System;
using System.Collections.Generic;

class FindSubsetWithGivenSum
{
    static List<int> getSubsetWithSum(int targetSubSum, List<int> elementsSubListSorted)
    {
        if ((elementsSubListSorted.Count == 0) || (targetSubSum < 0))
        {
            return new List<int>();
        }
        else if (elementsSubListSorted[0] == targetSubSum)
        {
            return elementsSubListSorted.GetRange(0, 1);
        }
        else
        {
            List<int> currentSubList = new List<int>();
            int currentIndex = 0;

            while ((currentIndex < elementsSubListSorted.Count - 1) && 
                   (currentSubList.Count == 0) &&
                   (elementsSubListSorted[currentIndex] <= targetSubSum/2))
            {
                currentSubList = getSubsetWithSum(targetSubSum - elementsSubListSorted[currentIndex], elementsSubListSorted.GetRange(currentIndex + 1, elementsSubListSorted.Count - currentIndex - 1));
                currentIndex++;
            }

            if (currentSubList.Count > 0)
            {
                currentSubList.Add(elementsSubListSorted[currentIndex-1]);
            }
            return currentSubList;
        }
    }

    static List<int> CustomQuickSort(List<int> elementsList)
    {
        if (elementsList.Count <= 1)
        {
            return elementsList;
        }
        else
        {
            int pivotIndex = elementsList.Count / 2;
            int pivotElement = elementsList[pivotIndex];

            List<int> subListLeft = new List<int>();
            List<int> subListRight = new List<int>();

            for (int i = 0; i < pivotIndex; i++)
            {
                if (elementsList[i] < pivotElement)
                {
                    subListLeft.Add(elementsList[i]);
                }
                else
                {
                    subListRight.Add(elementsList[i]);
                }
            }
            for (int i = pivotIndex + 1; i < elementsList.Count; i++)
            {
                if (elementsList[i] < pivotElement)
                {
                    subListLeft.Add(elementsList[i]);
                }
                else
                {
                    subListRight.Add(elementsList[i]);
                }
            }

            subListLeft = CustomQuickSort(subListLeft);
            subListRight = CustomQuickSort(subListRight);

            List<int> resultList = new List<int>();
            resultList.AddRange(subListLeft);
            resultList.Add(pivotElement);
            resultList.AddRange(subListRight);

            return resultList;
        }
    }

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
        List<int> subsetList = new List<int>();
        List<int> elementsList = new List<int>();
        int nextNumber = 0;
        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("Enter element {0}:", i);
            nextNumber = int.Parse(Console.ReadLine());
            if (nextNumber == targetSum)
            {
                subsetList.Add(nextNumber);
            }
            else if (nextNumber < targetSum)
            {
                elementsList.Add(nextNumber);
            }            
        }

        if (subsetList.Count > 0)
        {
            Console.WriteLine(String.Join(", ", subsetList));
        }
        else
        {
            List<int> elementsListSorted = CustomQuickSort(elementsList);

            int index = elementsListSorted.Count - 1;

            while ((index >= 0) && (subsetList.Count == 0))
            {
                List<int> currentSubList = getSubsetWithSum(targetSum - elementsListSorted[index], elementsListSorted.GetRange(0, index));
                if (currentSubList.Count > 0)
                {
                    subsetList.AddRange(currentSubList);
                    subsetList.Add(elementsListSorted[index]);
                }
                else
                {
                    index--;
                }
            }

            if (subsetList.Count > 0)
            {
                Console.WriteLine(String.Join(", ", subsetList));
            }
            else
            {
                Console.WriteLine("There is no subset with that sum!");
            }
        }
    }
}
