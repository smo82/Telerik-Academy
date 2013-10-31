using System;

class PrintMatrixD
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

    static void PrintArray(int[,] inArray, int numberOfElements)
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

        int [,] directionsArray = new int [4,2] {
            {0,1},
            {1,0},
            {0,-1},
            {-1,0}
        };

        int index = 1;
        int indexX = 0;
        int indexY = 0;
        int borderRightX = numberElements - 1;
        int borderLeftX = 1;
        int borderDownY = numberElements-1;
        int borderUpY = 0;
        int direction = 0;
        while (index <= numberElements * numberElements)
        {
            if (((direction == 0) && (indexY == borderDownY)) ||
                ((direction == 1) && (indexX == borderRightX)) ||
                ((direction == 2) && (indexY == borderUpY)) ||
                ((direction == 3) && (indexX == borderLeftX)))
            {
                switch (direction)
                {
                    case 0: 
                        borderDownY--;
                        direction++;
                        break;
                    case 1: 
                        borderRightX--;
                        direction++;
                        break;
                    case 2: 
                        borderUpY++;
                        direction++;
                        break;
                    case 3: 
                        borderLeftX++;
                        direction = 0;
                        break;
                }
            }
            
            elementsList[indexX, indexY] = index;
            index++;

            indexX += directionsArray[direction, 0];
            indexY += directionsArray[direction, 1];
        }

        PrintArray(elementsList, numberElements);
    }
}
