using System;
using System.Numerics;

class Fibonacci
{
    static void Main()
    {
        Console.Write("Enter how much numbers from the Fibonacci sequence you want calculated:");
        byte n;

        while (!byte.TryParse(Console.ReadLine(), out n) || (n == 0))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        BigInteger currentNumber = 0;
        BigInteger lastNumber = 1;
        BigInteger sum = 0;

        for (int i = 1; i <= n; i++)
        {
            sum += currentNumber;
            currentNumber = currentNumber + lastNumber;
            lastNumber = currentNumber - lastNumber;
        }

        Console.WriteLine("The sum of the first {0} Fibonacci numbers is: {1}", n, sum);
    }
}