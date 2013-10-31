using System;

class GetTheGreaterNumber
{
    static void Main()
    {
        Console.Write("Enter number1:");
        int number1;

        while (!int.TryParse(Console.ReadLine(), out number1))
        {
            Console.Write("Incorrect integer number, please enter it again:");
        }

        Console.Write("Enter number2:");
        int number2;

        while (!int.TryParse(Console.ReadLine(), out number2))
        {
            Console.Write("Incorrect integer number, please enter it again:");
        }

        Console.WriteLine("The greater number is {0}", Math.Max(number1, number2));
    }
}
