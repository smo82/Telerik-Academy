using System;

class CalcNFactorielDevidedByK
{
    static int Factoriel(int n)
    {
        if (n > 1)
        {
            return n * Factoriel(n - 1);
        }
        else
        {
            return 1;
        }
    }

    static void Main()
    {
        Console.WriteLine("We will calculate N!/K!, where 1<K<N.");
        Console.Write("Enter K:");
        int k;

        while ((!int.TryParse(Console.ReadLine(), out k)) || (k <= 1))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        Console.Write("Enter N:");
        int n;

        while ((!int.TryParse(Console.ReadLine(), out n)) || (n <= k))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        //Solution 1
        int kFactoriel = 1;
        for (int i = 1; i <= k; i++)
        {
            kFactoriel *= i;
        }

        int nFactoriel = 1;
        for (int i = 1; i <= n; i++)
        {
            nFactoriel *= i;
        }

        Console.WriteLine("Solution1: The result is: {0}", nFactoriel / kFactoriel);

        //Solution 2

        kFactoriel = Factoriel(k);
        nFactoriel = Factoriel(n);
        Console.WriteLine("Solution2: The result is: {0}", nFactoriel / kFactoriel);
    }
}