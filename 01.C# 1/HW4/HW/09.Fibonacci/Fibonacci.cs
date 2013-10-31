using System;
using System.Numerics;

class Fibonacci
{
    static void Main()
    {
        Console.Write("Enter how much numbers from the Fibonacci sequence you want calculated:");
        byte n;

        if ((!byte.TryParse(Console.ReadLine(), out n)) || (n < 1))
        {
            Console.Write("Incorrect number, we will diplay the first 100 numbers.");
            n = 100;
        }

        BigInteger currentNumber = 0;
        BigInteger lastNumber = 1;

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine("Number {0,-3}:{1}", i, currentNumber);
            currentNumber = currentNumber + lastNumber;
            lastNumber = currentNumber - lastNumber;
        }
    }
}
