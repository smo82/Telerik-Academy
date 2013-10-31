using System;

class GetRandomValues
{
    static void Main()
    {
        Random randomValue = new Random();

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(randomValue.Next(100, 200));
        }
    }
}
