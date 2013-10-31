using System;

class ExchangeVariables
{
    static void Main()
    {
        Console.Write("Enter the first number:");
        int number1;

        while (!int.TryParse(Console.ReadLine(), out number1))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        Console.Write("Enter the second number:");
        int number2;

        while (!int.TryParse(Console.ReadLine(), out number2))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        if (number1 > number2)
        {
            int tempNumber = number1;
            number1 = number2;
            number2 = tempNumber;
        }

        Console.WriteLine("The value of the first number is: {0}", number1);
        Console.WriteLine("The value of the second number is: {0}", number2);
    }
}