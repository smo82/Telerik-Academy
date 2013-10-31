using System;

class SumThreeNumbers
{
    static void Main()
    {
        Console.Write("Enter number1:");
        int number1;
        while (!int.TryParse(Console.ReadLine(), out number1))
        {
            Console.Write("Incorrect int number, please enter number1:");
        }

        Console.Write("Enter number2:");
        int number2;
        while (!int.TryParse(Console.ReadLine(), out number2))
        {
            Console.Write("Incorrect int number, please enter number2:");
        }

        Console.Write("Enter number3:");
        int number3;
        while (!int.TryParse(Console.ReadLine(), out number3))
        {
            Console.Write("Incorrect int number, please enter number3:");
        }

        Console.WriteLine("The sum is: {0} + {1} + {2} = {3}", number1, number2, number3, number1 + number2 + number3);
    }
}
