using System;

class AreaWithBiggestSum
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

    static int [,] ReadArray (int numberElementsX, int numberElementsY)
    {
        int[,] elementsList = new int[numberElementsX, numberElementsY];

        for (int i = 0; i < numberElementsX; i++)
        {
            for (int j = 0; j < numberElementsY; j++)
            {
                Console.Write("[{0},{1}]:", i, j);
                while (!int.TryParse(Console.ReadLine(), out elementsList[i, j])) 
                {
                    Console.Write("Wrong number. Please try again:");
                }
            }
            Console.WriteLine();
        }

        return elementsList;
    }

    static int GetAreaSum(int startPositionX, int startPositionY, int [,] elementsList)
    {
        int sum = 0;

        for (int i = startPositionX; i < startPositionX+3; i++)
        {
            for (int j = startPositionY; j < startPositionY+3; j++)
            {
                sum += elementsList[i, j];
            }
        }

        return sum;
    }

    static void Main()
    {
        int numberElementsX = ReadInt("Enter the number of elements by X:");
        int numberElementsY = ReadInt("Enter the number of elements by Y:");

        int[,] elementsList = new int[numberElementsX, numberElementsY];

        elementsList = ReadArray(numberElementsX, numberElementsY);

        int maxSum = int.MinValue;
        int maxSumX = 0;
        int maxSumY = 0;
        for (int i = 0; i <= numberElementsX-3; i++)
        {
            for (int j = 0; j <= numberElementsY - 3; j++)
            {
                int sum = GetAreaSum(i, j, elementsList);

                if (maxSum < sum)
                {
                    maxSum = sum;
                    maxSumX = i;
                    maxSumY = j;
                }
            }
        }
        Console.WriteLine("The area with the biggest sum is {0} with position of its left-up corner [{1}, {2}]",maxSum,maxSumX, maxSumY);
    }
}
