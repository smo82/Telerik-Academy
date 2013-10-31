using System;

class CheckPrime
{
    static void Main()
    {
        Console.Write("Enter number:");
        byte number = byte.Parse(Console.ReadLine());
        byte i = 2;
        bool devide = false;

        while ((i<number) && !devide)
        {
            if ((number % i) == 0)
            {
                devide = true;
            };
            i++;
        }

        if (devide)
        {
            Console.WriteLine("Not prime number");
        }
        else
        {
            Console.WriteLine("Prime number");
        }
    }
}
