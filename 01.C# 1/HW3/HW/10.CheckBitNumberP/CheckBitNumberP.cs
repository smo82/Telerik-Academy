using System;

class CheckBitNumberP
{
    static void Main()
    {
        Console.Write("Enter number:");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Enter bit position:");
        int p = int.Parse(Console.ReadLine());

        int mask = 1 << p;
        int maskAndNumber = number & mask;
        int pInNumber = maskAndNumber >> p;

        if (pInNumber == 1)
        {
            Console.WriteLine("Success: In number {0} bit at position {1} is 1", number, p);
        }
        else
        {
            Console.WriteLine("Fail: In number {0} bit at position {1} is not 1", number, p);
        }
    }
}