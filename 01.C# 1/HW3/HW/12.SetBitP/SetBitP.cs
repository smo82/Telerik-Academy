using System;

class SetBitP
{
    static void Main()
    {
        Console.Write("Enter number:");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Enter bit position:");
        int position = int.Parse(Console.ReadLine());

        Console.Write("Enter new bit value:");
        int newBitValue = int.Parse(Console.ReadLine());

        int mask = 0;
        int newNumber = 0;

        if (newBitValue == 1)
        {
            mask = 1 << position;
            newNumber = number | mask;
        }
        else
        {
            mask = ~(1 << position);
            newNumber = number & mask;
        }
        
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.WriteLine(Convert.ToString(mask, 2).PadLeft(32, '0'));
        Console.WriteLine(Convert.ToString(newNumber, 2).PadLeft(32, '0'));

        Console.WriteLine("The new number is {0}", newNumber);
    }
}