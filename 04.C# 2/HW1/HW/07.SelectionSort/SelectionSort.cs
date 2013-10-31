using System;

class SelectionSort
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

        for (int i = 0; i < numberElements; i++)
        {
            int minElement = elementsArr[i];
            int minElementIndex = i;
            for (int j = i+1; j < numberElements; j++)
            {
                if (elementsArr[j] < minElement)
                {
                    minElement = elementsArr[j];
                    minElementIndex = j;
                }
            }

            if (minElementIndex != i)
            {
                int tempElement = elementsArr[i];
                elementsArr[i] = minElement;
                elementsArr[minElementIndex] = tempElement;
            }
        }

        Console.WriteLine(new String('*', 30));
        Console.WriteLine("Sorted array:");
        for (int i = 0; i < numberElements; i++)
        {
            Console.WriteLine(elementsArr[i]);
        }
    }
}
