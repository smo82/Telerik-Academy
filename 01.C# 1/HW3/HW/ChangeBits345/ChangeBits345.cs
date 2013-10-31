using System;

class ChangeBits345
{
    static void Main()
    {
        Console.Write("Enter number:");
        int number = int.Parse(Console.ReadLine());

        int mask = ~(7 << 3);

        Console.WriteLine(new String('-', 40));
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));

        //Change bits 3, 4 & 5 to zeros
        number = number & mask;

        Console.WriteLine(Convert.ToString(mask, 2).PadLeft(32, '0'));
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.WriteLine(new String('-', 40));

        int newMask = number >> 21;

        Console.WriteLine(Convert.ToString(newMask, 2).PadLeft(32, '0'));

        int maskMask = 7 << 3;
        newMask = newMask & maskMask;

        Console.WriteLine(Convert.ToString(maskMask, 2).PadLeft(32, '0'));
        Console.WriteLine(Convert.ToString(newMask, 2).PadLeft(32, '0'));
        Console.WriteLine(new String('-', 40));

        int newNumber = number | newMask;

        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.WriteLine(Convert.ToString(newMask, 2).PadLeft(32, '0'));
        Console.WriteLine(Convert.ToString(newNumber, 2).PadLeft(32, '0'));
        Console.WriteLine(new String('-', 40));

        Console.WriteLine("The new number is {0}", newNumber);
    }
}