using System;
using System.Collections.Generic;

class QuickSort
{
    static List <int> CustomQuickSort(List<int> elementsList)
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
        Console.Write("Enter the length of the array:");
        int numberElements;

        while ((!int.TryParse(Console.ReadLine(), out numberElements)) || (numberElements <= 0))
        {
            Console.Write("Wrong length. Please try again:");
        }

        List<int> elementsList = new List<int>();
        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("Enter element {0}:", i);
            elementsList.Add(int.Parse(Console.ReadLine()));
        }

        Console.WriteLine(String.Join(", ", CustomQuickSort(elementsList)));
    }
}
