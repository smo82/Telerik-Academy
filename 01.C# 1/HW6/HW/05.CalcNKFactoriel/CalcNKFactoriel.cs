using System;

class CalcNKFactoriel
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
        Console.WriteLine("We will calculate N!*K!/(K-N)!, where 1<N<K.");
        Console.Write("Enter N:");
        int n;

        while ((!int.TryParse(Console.ReadLine(), out n)) || (n <= 1))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        Console.Write("Enter K:");
        int k;

        while ((!int.TryParse(Console.ReadLine(), out k)) || (k <= n))
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

        int knFactoriel = 1;
        for (int i = 1; i <= (k-n); i++)
        {
            knFactoriel *= i;
        }

        Console.WriteLine("Solution1: The result is: {0}", (nFactoriel*kFactoriel)/knFactoriel);

        //Solution 2

        kFactoriel = Factoriel(k);
        nFactoriel = Factoriel(n);
        knFactoriel = Factoriel(k - n);
        Console.WriteLine("Solution2: The result is: {0}", (nFactoriel * kFactoriel) / knFactoriel);
    }
}
