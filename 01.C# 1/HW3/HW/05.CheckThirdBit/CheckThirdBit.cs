using System;

class CheckThirdBit
{
    static void Main()
    {
        Console.Write("Enter number:");
        int number = int.Parse(Console.ReadLine());

        int mask = 1 << 3;
        int numberAndMask = number & mask;
        int numberThirdBit = numberAndMask >> 3;

        if (numberThirdBit == 1)
        {
            Console.WriteLine("Third bit is 1");
        }
        else
        {
            Console.WriteLine("Third bit is not 1");
        }
    }
}
