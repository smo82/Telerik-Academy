using System;

class SortCustom
{
    static int ReadInt(string message = "Enter N:", int minValue = 0, int maxValue = int.MaxValue)
    {
        Console.Write(message);

        int resultInt;
        while ((!int.TryParse(Console.ReadLine(), out resultInt)) || (resultInt < minValue) || (resultInt > maxValue))
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

    static void PrintArrayAsc(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("[{0}]:", i);
            Console.WriteLine(array[i]);
        }
    }

    static int GetIndexMaxNumber (int startIndex, int [] elementsList)
    {
        int indexMax = startIndex;
        int maxElement = elementsList[startIndex];
        for (int i = indexMax+1; i < elementsList.Length; i++)
        {
            if (maxElement<elementsList[i])
            {
                maxElement = elementsList[i];
                indexMax = i;
            }
        }

        return indexMax;
    }

    static int[] CustomSort (int typeOfSort, int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int indexMax = GetIndexMaxNumber(i, array);
            if (indexMax != i)
            {
                int maxVal = array[i];
                array[i] = array[indexMax];
                array[indexMax] = maxVal;
            }
        }

        if (typeOfSort == 0)
        {
            Array.Reverse(array);
        }

        return array;
    }

    static void Main()
    {
        int numberElements = ReadInt("Enter the number of elements in your array: ");

        int[] elementsList = new int[numberElements];
        elementsList = ReadArray(numberElements);

        int typeOfSort = ReadInt("Enter the type of sort you want (0 = Asc, 1 = Desc): ", 0, 1);

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your sorted list is:");
        PrintArrayAsc(CustomSort(typeOfSort,elementsList));
    }
}
