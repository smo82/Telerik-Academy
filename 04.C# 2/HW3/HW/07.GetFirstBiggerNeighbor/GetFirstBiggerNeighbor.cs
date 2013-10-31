using System;

class GetFirstBiggerNeighbor
{
    static int ReadInt(string message = "Enter N:", int maxValue = int.MaxValue)
    {
        Console.Write(message);

        int resultInt;
        while ((!int.TryParse(Console.ReadLine(), out resultInt)) || (resultInt < 0) || (resultInt > maxValue))
        {
            Console.Write("Wrong number. Please try again:");
        }

        return resultInt;
    }

    static int[] ReadArray(int numberElements)
    {
        int[] elementsList = new int[numberElements];

        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("[{0}]:", i);
            while (!int.TryParse(Console.ReadLine(), out elementsList[i]))
            {
                Console.Write("Wrong number. Please try again:");
            }
        }

        return elementsList;
    }

    static bool IsBiggerThenNeighbors(int index, int[] elementsList)
    {
        if (index >= elementsList.Length)
        {
            return false;
        }
        else
        {
            bool isBigger = true;

            if (((index - 1) >= 0) && (elementsList[index] <= elementsList[index - 1]))
            {
                isBigger = false;
            }

            if (((index + 1) < elementsList.Length) && (elementsList[index] <= elementsList[index + 1]))
            {
                isBigger = false;
            }

            return isBigger;
        }
    }

    static int GetFirstBigger (int[] elementsList)
    {
        int indexBiggerElement = -1;

        int i = 0;
        while ((indexBiggerElement == -1) && (i < elementsList.Length))
        {
            if (IsBiggerThenNeighbors(i, elementsList))
            {
                indexBiggerElement = i;
            }
            i++;
        }
        return indexBiggerElement;
    }

    static void Main()
    {
        int numberElements = ReadInt("Enter the number of elements in your array: ");

        int[] elementsList = new int[numberElements];
        elementsList = ReadArray(numberElements);

        int indexBigger = GetFirstBigger(elementsList);
        Console.WriteLine(new String('*', 20));
        if (indexBigger == -1)
        {
            Console.WriteLine("There is no bigger element!");
        }
        else
        {
            Console.WriteLine("The index of the bigger element is: {0}", indexBigger);
        }
    }
}
