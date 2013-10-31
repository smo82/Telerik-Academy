using System;
using System.Collections.Generic;

class AllPermutations
{
    static List <List<int>> GetAllPermutations(List <int> elementsList)
    {
        List<List<int>> resultElementList = new List<List<int>>(); 
        for (int i = 0; i < elementsList.Count; i++)
        {
            List<int> elementsSubList = new List<int>();
            elementsSubList.AddRange(elementsList);
            elementsSubList.RemoveAt(i);
            List<List<int>> resultSubList = GetAllPermutations(elementsSubList);
            if (resultSubList.Count == 0)
            {
                resultElementList.Add(new List<int>() { elementsList[i] });
            }
            else
            {
                foreach (List<int> resultSubListList in resultSubList)
                {
                    resultSubListList.Add(elementsList[i]);
                    resultElementList.Add(resultSubListList);
                }
            }            
        }

        return resultElementList;
    }
    static void Main()
    {
        Console.Write("Enter the N:");
        int numberElements;

        while ((!int.TryParse(Console.ReadLine(), out numberElements)) || (numberElements <= 0))
        {
            Console.Write("Wrong number. Please try again:");
        }

        List <int> elementsList = new List <int>();

        for (int i = 0; i < numberElements; i++)
        {
            elementsList.Add(i + 1);
        }

        List<List<int>> allPermutations = GetAllPermutations(elementsList);
        int numberRow = 1;
        foreach (List<int> onePermutation in allPermutations)
        {
            Console.WriteLine(numberRow + ") " +String.Join(", ", onePermutation));
            numberRow++;
        }
    }
}
