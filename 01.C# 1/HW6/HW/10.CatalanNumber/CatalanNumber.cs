using System;

class CatalanNumber
{
    //The Factoriel function is written in such a way that can use calculations of
    //the factoriel for a smaller N
    //For example if we have already calculated n! where n=5 and we want to calculate
    // n! where n = 7, we should execute the function like this Factoriel(7, 5, 5!)
    //This way the function will calculate 7*6*5!
    static int Factoriel(int n, int firstNumberIndex = 1, int FirstNumber= 1)
    {
        if (n > firstNumberIndex)
        {
            return n * Factoriel(n - 1);
        }
        else
        {
            return FirstNumber;
        }
    }

    static void Main()
    {
        Console.WriteLine("We will calculate the Catalan number Cn = (2n)!/((n+1)!*n!)");
        Console.Write("Enter N:");
        int n;

        while ((!int.TryParse(Console.ReadLine(), out n)) || (n < 0))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        int nFactoriel = Factoriel(n);
        int twoTimesNFactoriel = Factoriel(2*n, n, nFactoriel);
        int catalanNumber = twoTimesNFactoriel / ((n + 1) * nFactoriel * nFactoriel);

        Console.WriteLine("The result is: {0}", catalanNumber);
    }
}
