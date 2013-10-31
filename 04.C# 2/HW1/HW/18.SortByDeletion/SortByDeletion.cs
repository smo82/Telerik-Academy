using System;

class SortByDeletion
{
    static void Main()
    {
        Console.Write("Enter the length of the array:");
        int numberElements;

        while ((!int.TryParse(Console.ReadLine(), out numberElements)) || (numberElements <= 0))
        {
            Console.Write("Wrong length. Please try again:");
        }

        //We read the elements in a List and filter those that are bigger then our target sum
        int[] elementsList = new int[numberElements];
        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("Enter element {0}:", i);
            elementsList[i] = int.Parse(Console.ReadLine());
        }

        int subSetMask = (int)Math.Pow(2, elementsList.Length) - 1;
        
        int maskIndex = 1;
        int maskMostNumbers = 0;
        int countMostNumbers = 0;
        while (maskIndex <= subSetMask)
        {
            bool sorted = true;
            int elementIndex = 0;
            int previousElement = int.MinValue;
            int currentElementCount = 0;
            int subMask = 1;
            while ((sorted) && (subMask <= maskIndex))
            {
                if ((maskIndex & subMask) == subMask)
                {
                    if (elementsList[elementIndex] < previousElement)
                    {
                        sorted = false;
                    }
                    else
                    {
                        currentElementCount++;
                    }
                    previousElement = elementsList[elementIndex];
                }
                elementIndex++;
                subMask <<= 1;
            }

            if ((sorted) && (countMostNumbers < currentElementCount))
            {
                countMostNumbers = currentElementCount;
                maskMostNumbers = maskIndex;
            }

            maskIndex++;
        }

        int mostNumbersIndex = 0;
        while (maskMostNumbers > 0)
        {
            if ((maskMostNumbers & 1) == 1)
            {
                Console.Write(elementsList[mostNumbersIndex] + ", ");
            }
            maskMostNumbers >>= 1;
            mostNumbersIndex++;
        }
    }
}
