using System;

class PrintFirstNNotDevisibleTo3And7
{
    static void Main()
    {
        Console.Write("Enter N:");
        int number;

        while ((!int.TryParse(Console.ReadLine(), out number)) || (number < 0))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        Console.WriteLine("The first {0} numbers not devisible 3 and 7 are:", number);

        for (int i = 1; i <= number; i++)
        {
            if ((i % 3 != 0) || (i % 7 != 0))
            {
                Console.WriteLine(i);
            }
        }
    }
}
