using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your number:");
        decimal userNumber = decimal.Parse(Console.ReadLine());

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your formatted number is:");
        Console.WriteLine("{0, -30} : {1,15:D}", "As decimal", (int)userNumber);
        Console.WriteLine("{0, -30} : {1,15:X}", "As hexadecimal", (int)userNumber);
        Console.WriteLine("{0, -30} : {1,15:P}", "As percentage", userNumber);
        Console.WriteLine("{0, -30} : {1,15:E}", "In scientific notation", userNumber);
    }
}
