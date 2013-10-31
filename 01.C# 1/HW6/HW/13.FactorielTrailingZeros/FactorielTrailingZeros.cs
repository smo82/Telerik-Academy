using System;

class FactorielTrailingZeros
{
    static void Main()
    {
        Console.WriteLine("We will calculate the number of trailing zeros for N!.");
        Console.Write("Enter N:");
        int n;

        while ((!int.TryParse(Console.ReadLine(), out n)) || (n < 1))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        int numberTrailingZeros = 0;
        int devisor = 5;
        while (n >= devisor)
        {
            numberTrailingZeros += n / devisor;
            devisor *= 5;
        }

        Console.WriteLine("The number of trailing zeros is: {0}", numberTrailingZeros);
    }
}
