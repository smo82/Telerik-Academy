using System;

class PrintFirstN
{
    static void Main()
    {
        Console.Write("Enter N:");
        int number;

        while ((!int.TryParse(Console.ReadLine(), out number)) || (number < 0))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        Console.WriteLine("Your numbers are:");
        for (int i = 1; i <= number; i++)
        {
            Console.WriteLine(i);
        }
    }
}
