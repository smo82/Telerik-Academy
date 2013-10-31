using System;
using System.Collections.Generic;

class PrimeNumbersEratosthenes
{
    static void Main()
    {
        const int numberElements = 10000000;
        bool[] elementsArr = new bool[numberElements+1];

        for (int i = 1; i <= numberElements; i++)
        {
            elementsArr[i] = true;
        }

        List<int> primeNumbers = new List<int>();
        primeNumbers.Add(1);
        int currentNumber = 2;

        while (currentNumber <= numberElements)
        {
            primeNumbers.Add(currentNumber);

            long nextNotPrime = (long)currentNumber * currentNumber;
            if (nextNotPrime <= numberElements)
            {
                elementsArr[nextNotPrime] = false;
                
                nextNotPrime += currentNumber;
                while (nextNotPrime <= numberElements)
                {
                    elementsArr[nextNotPrime] = false;
                    nextNotPrime += currentNumber;
                }
            }

            currentNumber++;
            while ((currentNumber <= numberElements) && (!elementsArr[currentNumber]))
            {
                currentNumber++;
            }
        }

        Console.WriteLine(String.Join(", ", primeNumbers));
    }
}
