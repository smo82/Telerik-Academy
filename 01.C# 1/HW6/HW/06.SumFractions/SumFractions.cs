using System;

class SumFractions
{
    static void Main()
    {
        Console.WriteLine("We will calculate the sum 1 + 1!/X + 2!/x2 + ... + N!/XN.");
        Console.Write("Enter N:");
        int n;

        while ((!int.TryParse(Console.ReadLine(), out n)) || (n < 0))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        Console.Write("Enter X:");
        decimal x;

        while (!decimal.TryParse(Console.ReadLine(), out x))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        decimal sum = 1;
        int factoriel = 1;
        decimal xPower = 1;
        for (int i = 1; i <= n; i++)
        {
            factoriel *= i;
            xPower *= x;
            sum += factoriel / xPower;
        }

        Console.WriteLine("The result is: {0}", sum);
    }
}
