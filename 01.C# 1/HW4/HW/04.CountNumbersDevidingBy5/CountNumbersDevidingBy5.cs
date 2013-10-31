using System;

class Program
{
    static void Main()
    {
        int lowerEndpoint;
        int upperEndpoint;


        Console.Write("Enter the lower endpoint:");

        while (!int.TryParse(Console.ReadLine(), out lowerEndpoint))
        {
            Console.Write("Incorrect lower endpoint, please enter it again:");
        }

        Console.Write("Enter the upper endpoint:");

        while ((!int.TryParse(Console.ReadLine(), out upperEndpoint)) || (lowerEndpoint > upperEndpoint))
        {
            Console.Write("Incorrect upper endpoint, please enter it again:");
        }

        int numbersDevidedBy5 = 0;
        for (int i = lowerEndpoint; i <= upperEndpoint; i++)
        {
            if (i % 5 == 0)
            {
                numbersDevidedBy5++;
            }
        }

        Console.WriteLine("In the interval [{0},{1}] there are {2} numbers that devide by 5 without a reminder.", lowerEndpoint, upperEndpoint, numbersDevidedBy5);
    }
}
