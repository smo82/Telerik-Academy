using System;
using System.Collections.Generic;

class AllVariations
{
    static List<List<int>> GetAllVariations(List<int> elementsList, int lengthSubset)
    {
        List<List<int>> resultElementList = new List<List<int>>();

        if (lengthSubset > 0)
        {
            for (int i = 0; i < elementsList.Count; i++)
            {
                List<int> elementsSubList = new List<int>();
                elementsSubList.AddRange(elementsList);
                List<List<int>> resultSubList = GetAllVariations(elementsSubList, lengthSubset - 1);
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

        List<int> elementsList = new List<int>();

        for (int i = 0; i < numberElements; i++)
        {
            elementsList.Add(i + 1);
        }

        Console.Write("Enter the K:");
        int lengthSubset;

        while ((!int.TryParse(Console.ReadLine(), out lengthSubset)) || (lengthSubset <= 0))
        {
            Console.Write("Wrong number. Please try again:");
        }

        List<List<int>> allPermutations = GetAllVariations(elementsList, lengthSubset);
        int numberRow = 1;
        foreach (List<int> onePermutation in allPermutations)
        {
            Console.WriteLine(numberRow + ") " + String.Join(", ", onePermutation));
            numberRow++;
        }
    }
}
