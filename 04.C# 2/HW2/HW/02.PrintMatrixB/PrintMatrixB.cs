using System;

class PrintMatrixB
{
    static void Main()
    {
        Console.Write("Enter the N:");
        int numberElements;

        while ((!int.TryParse(Console.ReadLine(), out numberElements)) || (numberElements <= 0))
        {
            Console.Write("Wrong number. Please try again:");
        }

        int[,] elementsList = new int[numberElements,numberElements];
        for (int i = 0; i < numberElements; i++)
        {
            if ((i & 1) == 0)
            {
                for (int j = 0; j < numberElements; j++)
                {
                    elementsList[i, j] = i * numberElements + j + 1;
                }
            }
            else
            {
                for (int j = 0; j < numberElements; j++)
                {
                    elementsList[i, j] = i * numberElements + numberElements - j;
                }
            }
        }

        for (int i = 0; i < numberElements; i++)
        {
            for (int j = 0; j < numberElements; j++)    
            {
                Console.Write("{0, 3}", elementsList[j, i]);
            }
            Console.WriteLine();
        }
    }
}
