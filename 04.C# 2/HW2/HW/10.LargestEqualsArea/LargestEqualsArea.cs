using System;

class LargestEqualsArea
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

    static int[,] ReadArray(int numberElementsX, int numberElementsY)
    {
        int[,] elementsList = new int[numberElementsX, numberElementsY];

        for (int i = 0; i < numberElementsX; i++)
        {
            for (int j = 0; j < numberElementsY; j++)
            {
                Console.Write("[{0},{1}]:", i, j);
                while (!int.TryParse(Console.ReadLine(), out elementsList[i,j]))
                {
                    Console.Write("Wrong number. Please try again:");
                }
            }
            Console.WriteLine();
        }

        return elementsList;
    }

    static bool CheckIndexInArray(int[,] elementsList, int indexX, int indexY)
    {
        if ((indexX >= 0) && (indexX < elementsList.GetLength(0)) &&
            (indexY >= 0) && (indexY < elementsList.GetLength(1)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void GetArea(int [,] elementsList, bool [,] checkedElementsList, int indexX, int indexY, out int currentArea, out bool [,] checkedElementsListOut)
    {
        currentArea = 0;
        checkedElementsListOut = (bool[,])checkedElementsList.Clone();

        if ((indexX != elementsList.GetLength(0)) && (indexY != elementsList.GetLength(1)))
        {
            currentArea = 1;
            checkedElementsListOut[indexX, indexY] = true;
            int[,] directions = new int[,]{{-1, 0}, {0, 1}, {1, 0}, {0,-1}};

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int newIndexX = indexX + directions[i, 0];
                int newIndexY = indexY + directions[i, 1];

                if ((CheckIndexInArray(elementsList, newIndexX, newIndexY)) &&
                    (!checkedElementsListOut[newIndexX, newIndexY]) &&
                    (elementsList[newIndexX, newIndexY] == elementsList[indexX, indexY]))
                {
                    int areaChilds = 0;
                    GetArea(elementsList, checkedElementsListOut, newIndexX, newIndexY, out areaChilds, out checkedElementsListOut);
                    currentArea += areaChilds;
                }
            }
        }
    }

    static void Main()
    {
        int numberElementsX = ReadInt("Enter the number of elements by X: ");
        int numberElementsY = ReadInt("Enter the number of elements by Y: ");

        int[,] elementsList = new int[numberElementsX, numberElementsY];
        elementsList = ReadArray(numberElementsX, numberElementsY);

        bool[,] checkedElementsList = new bool[numberElementsX, numberElementsY];

        int lengthLargestArea = 0;
        for (int i = 0; i < numberElementsX; i++)
        {
            for (int j = 0; j < numberElementsY; j++)
            {
                if (!checkedElementsList[i, j])
                {
                    int currentArea;
                    GetArea(elementsList, checkedElementsList, i, j, out currentArea, out checkedElementsList);
                    
                    if (currentArea > lengthLargestArea)
                    {
                        lengthLargestArea = currentArea;
                    }
                }
            }
        }

        Console.WriteLine("The largest area is: {0}.",lengthLargestArea);
    }
}
