using System;

class SumNNumbers
{
    static void Main()
    {
        Console.Write("Enter how many numbers will be summed:");
        byte numberCount;

        while ((!byte.TryParse(Console.ReadLine(), out numberCount)) || (numberCount < 0))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        int sum = 0;
        int currentNumber = 0;
        for (int i = 0; i < numberCount; i++)
        {
            Console.Write("Enter the next number:");
            while (!int.TryParse(Console.ReadLine(), out currentNumber))
            {
                Console.Write("Incorrect number, please enter it again:");
            }
            sum += currentNumber;
        }

        Console.WriteLine("The sum of the numbers is {0}", sum);
    }
}