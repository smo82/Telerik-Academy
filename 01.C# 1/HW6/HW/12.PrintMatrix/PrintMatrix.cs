using System;

class PrintMatrix
{
    static void Main()
    {
        Console.Write("Enter the matrix level N:");
        int n;

        while ((!int.TryParse(Console.ReadLine(), out n)) || (n >= 20))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = i; j < n+i; j++)
            {
                Console.Write("{0,3}",j);
            }
            Console.WriteLine();
        }
    }
}
