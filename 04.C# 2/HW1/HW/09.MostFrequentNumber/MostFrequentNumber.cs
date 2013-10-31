using System;
using System.Collections.Generic;

class MostFrequentNumber
{
    static void Main()
    {
        Console.Write("Enter the length of the array:");
        int numberElements;

        while ((!int.TryParse(Console.ReadLine(), out numberElements)) || (numberElements <= 0))
        {
            Console.Write("Wrong length. Please try again:");
        }

        Dictionary<int,int> elementsCountArray = new Dictionary<int,int>();
        int currentItem;
        int maxItem = 0;
        int maxCount = 0;

        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("Enter element {0}:", i);
            currentItem = int.Parse(Console.ReadLine());

            int currentCount = 0;
            if (elementsCountArray.TryGetValue(currentItem, out currentCount))
            {
                //elementsCountArray.Add(currentItem, currentCount + 1);
                elementsCountArray[currentItem] = ++currentCount;
            }
            else
            {
                elementsCountArray.Add(currentItem, 1);
                currentCount = 1;
            }

            if (currentCount>maxCount)
            {
                maxCount = currentCount;
                maxItem = currentItem;
            }
        }

        Console.WriteLine("The most frequent number is {0} with {1} times", maxItem, maxCount);
    }
}