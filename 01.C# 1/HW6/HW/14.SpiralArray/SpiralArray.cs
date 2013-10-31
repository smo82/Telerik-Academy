using System;

class SpiralArray
{
    static void Main()
    {
        Console.Write("Enter the matrix level N:");
        int n;

        while ((!int.TryParse(Console.ReadLine(), out n)) || (n >= 20))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        int [,] spiralArray = new int[n,n];

        int x = 0;
        int y = 0;
        int count = 1;
        int xStep = 1;
        int yStep = 0;
        int xLeftBorder = -1;
        int xRightBorder = n;
        int yTopBorder = 0;
        int yBottomBorder = n;
        int tempXDirection = 1;
        int tempYDirection = 1;

        while (count <= (n * n))
        {
            spiralArray[x, y] = count;

            x += xStep;
            y += yStep;

            if ((xStep == 1) && (x == (xRightBorder - 1)))
            {
                xRightBorder--;
                xStep = 0;
                yStep = tempYDirection;
                tempXDirection = -1;
            }
            else if ((xStep == -1) && (x == (xLeftBorder + 1)))
            {
                xLeftBorder++;
                xStep = 0;
                yStep = tempYDirection;
                tempXDirection = 1;
            }
            else if ((yStep == 1) && (y == (yBottomBorder - 1)))
            {
                yBottomBorder--;
                xStep = tempXDirection;
                yStep = 0;
                tempYDirection = -1;
            }
            else if ((yStep == -1) && (y == (yTopBorder + 1)))
            {
                yTopBorder++;
                xStep = tempXDirection;
                yStep = 0;
                tempYDirection = 1;
            }

            count++;
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,4}", spiralArray[j,i]);
            }
            Console.WriteLine();
        }
    }
}
