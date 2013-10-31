using System;

class CheckDivision
{
    static void Main(string[] args)
    {
        Console.Write("Enter number:");
        int number = int.Parse(Console.ReadLine());

        if (((number % 7) == 0) && ((number % 5) == 0))
        {
            Console.WriteLine("Division without remainder");
        }
        else
        {
            Console.WriteLine("Division with remainder");
        }
    }
}
