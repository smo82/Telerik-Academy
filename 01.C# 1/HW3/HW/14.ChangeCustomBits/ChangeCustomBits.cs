using System;

class ChangeCustomBits
{
    static void Main()
    {
        Console.Write("Enter number:");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Enter number of bits to change (k):");
        int numberOfBitsToChange = int.Parse(Console.ReadLine());

        Console.Write("Enter position of first bit to be changed (p):");
        int startingBitToChange = int.Parse(Console.ReadLine());

        Console.Write("Enter position of first bit to take (q) (q>p):");
        int startingBitToTake = int.Parse(Console.ReadLine());

        Console.WriteLine(new String('-', 40));

        int maskOnes = 0;

        for (int i = 0; i < numberOfBitsToChange; i++)
        {
            maskOnes <<= 1;
            maskOnes |= 1;
        }

        Console.WriteLine(Convert.ToString(maskOnes, 2).PadLeft(32, '0'));

        int mask = ~(maskOnes << startingBitToChange);

        Console.WriteLine(new String('-', 40));
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));

        //Change bits p, p+1 ... to zeros
        number = number & mask;

        Console.WriteLine(Convert.ToString(mask, 2).PadLeft(32, '0'));
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.WriteLine(new String('-', 40));

        //Making a new mask with the bits we want to set
        int newMask = number >> startingBitToTake;

        Console.WriteLine(Convert.ToString(newMask, 2).PadLeft(32, '0'));

        newMask = newMask & maskOnes;
        Console.WriteLine(Convert.ToString(maskOnes, 2).PadLeft(32, '0'));
        Console.WriteLine(Convert.ToString(newMask, 2).PadLeft(32, '0'));

        newMask <<= numberOfBitsToChange;

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
