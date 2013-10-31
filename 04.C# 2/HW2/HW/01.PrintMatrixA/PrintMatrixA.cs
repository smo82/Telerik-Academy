using System;

class PrintMatrixA
{
    static void Main()
    {
        Console.Write("Enter the N:");
        int numberElements;

        while ((!int.TryParse(Console.ReadLine(), out numberElements)) || (numberElements <= 0))
        {
            Console.Write("Wrong number. Please try again:");
        }

        for (int i = 1; i <= numberElements; i++)
        {
            for (int j = 0; j < numberElements; j++)
            {
                Console.Write("{0, 3}", i + j*4);
            }
            Console.WriteLine();
        }
    }
}
