using System;

class Odd_check
{
    static void Main()
    {
        Console.Write("Enter number:");
        int number = int.Parse(Console.ReadLine());

        if (number % 2 == 0)
        {
            Console.WriteLine("The number is even");
        }
        else
        {
            Console.WriteLine("The number is odd");
        }

        if ((number & 1) == 1) 
        {
            Console.WriteLine("The number is odd");
        }
        else
        {
            Console.WriteLine("The number is even");            
        }
    }
}