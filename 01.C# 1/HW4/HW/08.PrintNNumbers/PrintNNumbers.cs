using System;

class PrintNNumbers
{
    static void Main()
    {
        Console.Write("Enter the N-th number:");
        byte n;

        while ((!byte.TryParse(Console.ReadLine(), out n)) || (n < 1))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        Console.WriteLine("All the numbers between [1, {0}] are:", n);
        for (byte i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}
