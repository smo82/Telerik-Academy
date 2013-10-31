using System;

class BinarySearch
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

        Console.Write("Enter the searched element:");
        int searchedElement;

        while (!int.TryParse(Console.ReadLine(), out searchedElement))
        {
            Console.Write("Wrong searched element. Please try again:");
        }

        int indexMatch = -1;
        int lowerBorder = 0;
        int upperBorder = numberElements - 1;

        //We check the border cases. If our number is bigger then the biggest element or smaller then the smallest
        //then we know it is not present in the array
        if ((searchedElement < elementsArr[lowerBorder]) || (searchedElement > elementsArr[upperBorder]))
        {
            indexMatch = -2;
        }

        while ((indexMatch == -1) && (upperBorder - lowerBorder >= 0))
        {
            int currentIndex = (upperBorder + lowerBorder) / 2;
                    
            int currentNumer = elementsArr[currentIndex];
            if (currentNumer == searchedElement)
            {
                indexMatch = currentIndex;
            }
            else if (currentNumer > searchedElement)
            {
                upperBorder = currentIndex - 1;
            }
            else
            {
                lowerBorder = currentIndex + 1;
            }
        }

        if (indexMatch > -1)
        {
            Console.WriteLine("The index of the searched element is: " + indexMatch);
        }
        else
        {
            Console.WriteLine("The searched element was not found!");
        }
    }
}
