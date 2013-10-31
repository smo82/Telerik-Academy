using System;

class PrintMatrixC
{
    static int ReadInt (string message = "Enter N:")
    {
        Console.Write(message);

        int resultInt;
        while ((!int.TryParse(Console.ReadLine(), out resultInt)) || (resultInt <= 0))
        {
            Console.Write("Wrong number. Please try again:");
        }

        return resultInt;
    }

    static void PrintArray (int [,] inArray, int numberOfElements)
    {
        for (int i = 0; i < numberOfElements; i++)
        {
            for (int j = 0; j < numberOfElements; j++)
            {
                Console.Write("{0, 3}", inArray[j, i]);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int numberElements = ReadInt();

        int[,] elementsList = new int[numberElements, numberElements];

        int index = 1;
        int startX = 0;
        int startY = numberElements;
        while (startX < numberElements)
        {
            if (startY == 0)
            {
                startX++;
            }
            else
            {
                startY--;
            }
            int indexX = startX;
            int indexY = startY;
            while ((indexX<numberElements) && (indexY < numberElements))
            {
                elementsList[indexX, indexY] = index;
                index++;
                indexX++;
                indexY++;
            }
        }

        PrintArray(elementsList, numberElements);
    }
}
