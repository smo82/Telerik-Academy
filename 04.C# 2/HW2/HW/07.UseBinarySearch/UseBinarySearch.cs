using System;

class UseBinarySearch
{
    static int ReadInt(string message = "Enter N:")
    {
        Console.Write(message);

        int resultInt;
        while ((!int.TryParse(Console.ReadLine(), out resultInt)) || (resultInt <= 0))
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

    static void Main()
    {
        int numberElements = ReadInt();
        int k = ReadInt("Enter K:");

        int[] elementsList = new int[numberElements];
        elementsList = ReadArray(numberElements);

        Array.Sort(elementsList);

        int result = Array.BinarySearch(elementsList, k);

        if (result < 0)
        {
            result = result * (-1) - 2;
        }

        if (result < 0)
        {
            Console.WriteLine("No such element was found");
        }
        else
        {
            Console.WriteLine(result);
        }
    }
}
