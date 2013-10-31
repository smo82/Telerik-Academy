using System;
using System.Collections.Generic;

class SequenceWithMaxSum2
{
    static void Main2()
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

        int currentSum = elementsArr[0];
        int biggestSum = elementsArr[0];
        int previousElement = elementsArr[0];
        int indexBiggestSum = 1;
        int latestBiggestSum = elementsArr[0];

        List<int> currentElementsArr = new List<int>();
        currentElementsArr.Add(elementsArr[0]);
        List<int> biggestSumElementsArr = new List<int>();
        biggestSumElementsArr.Add(elementsArr[0]);


        for (int i = 1; i < numberElements; i++)
        {
            if (previousElement < 0)
            {
                if (currentSum > biggestSum)
                {
                    biggestSumElementsArr.Clear();
                    biggestSumElementsArr.AddRange(currentElementsArr.GetRange(0, indexBiggestSum));
                    biggestSum = currentSum;
                }

                currentElementsArr.Clear();
                currentElementsArr.Add(elementsArr[i]);
                currentSum = elementsArr[i];
                previousElement = elementsArr[i];
                indexBiggestSum = 1;
            }
            else if (elementsArr[i] < 0)
            {
                previousElement += elementsArr[i];

                if (previousElement <= 0)
                {
                    if (currentSum > biggestSum)
                    {
                        biggestSumElementsArr.Clear();
                        biggestSumElementsArr.AddRange(currentElementsArr.GetRange(0, indexBiggestSum));
                        biggestSum = currentSum;
                    }

                    currentElementsArr.Clear();
                    currentElementsArr.Add(elementsArr[i]);
                    currentSum = elementsArr[i];
                    previousElement = elementsArr[i];
                    indexBiggestSum = 1;
                }
                else
                {
                    currentElementsArr.Add(elementsArr[i]);
                    currentSum += elementsArr[i];
                }
            }
            else
            {
                currentElementsArr.Add(elementsArr[i]);
                currentSum += elementsArr[i];
                previousElement = elementsArr[i];
                indexBiggestSum = currentElementsArr.Count;
            }
        }

        if (currentSum > biggestSum)
        {
            biggestSumElementsArr.Clear();
            biggestSumElementsArr.AddRange(currentElementsArr.GetRange(0, indexBiggestSum));
            biggestSum = currentSum;
        }

        Console.WriteLine(new String('*', 30));
        Console.WriteLine("The sequence of elements with the biggest sum is:");

        foreach (int element in biggestSumElementsArr)
        {
            Console.WriteLine(element);
        }
    }
}
