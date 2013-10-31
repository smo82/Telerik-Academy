using System;

class CheckTheSign
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

        Console.Write("Enter the third number:");
        int number3;

        while (!int.TryParse(Console.ReadLine(), out number3))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        char sign = ' ';
        if ((number1 == 0) || (number2 == 0) || (number3 == 0))
        {
            sign = '+';
        }
        else if ((number1 > 0) && (number2 > 0) && (number3 > 0))
        {
            sign = '+';
        }
        else if ((number1 < 0) && (number2 < 0) && (number3 < 0))
        {
            sign = '-';
        }
        else if (((number1 > 0) && (number2 > 0)) ||
                 ((number2 > 0) && (number3 > 0)) ||
                 ((number1 > 0) && (number3 > 0)))
        {
            sign = '-';
        }
        else
        {
            sign = '+';
        }

        Console.WriteLine("The sign of the product will be \"{0}\"", sign);
    }
}