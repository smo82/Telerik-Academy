using System;

class SortStringArrayByLength
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

    static void Main()
    {
        int numberElements = ReadInt("Enter the number of elements: ");

        string[] elementsList = new string[numberElements];
        int[] elementsLength = new int[numberElements];

        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("[{0}]:", i);
            elementsList[i] = Console.ReadLine();
            elementsLength[i] = elementsList[i].Length;
        }

        for (int i = 0; i < numberElements-1; i++)
        {
            for (int j = i+1; j < numberElements; j++)
            {
                if (elementsLength[i] > elementsLength[j])
                {
                    int tempInt = elementsLength[i];
                    elementsLength[i] = elementsLength[j];
                    elementsLength[j] = tempInt;

                    string tempString = elementsList[i];
                    elementsList[i] = elementsList[j];
                    elementsList[j] = tempString;
                }
            }
        }

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("The sorted list is:");
        for (int i = 0; i < numberElements; i++)
        {
            Console.WriteLine(elementsList[i]);
        }
    }
}
