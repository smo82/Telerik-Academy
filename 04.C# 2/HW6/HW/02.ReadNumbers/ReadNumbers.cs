using System;

class ReadNumbers
{
    static int ReadNumber(int start, int end)
    {
        int result = int.Parse(Console.ReadLine());

        if ((result < start) || (result > end))
        {
            throw new ArgumentOutOfRangeException();
        }

        return result;
    }


    static void Main()
    {
        Console.WriteLine("Enter your 10 numbers:");

        int numberOfElements = 10;
        int[] userNumbersArr = new int[numberOfElements];

        int increment = 1;
        for (int i = 0; i < numberOfElements; i+=increment)
        {
            try 
            {
                Console.Write("[{0}]:", i);
                userNumbersArr[i] = ReadNumber(1, 100);
                increment = 1;
            }
            catch (Exception exception)
            {
                if ((exception is FormatException) ||
                    (exception is ArgumentOutOfRangeException)
                    )
                {
                    Console.WriteLine("Invalid number! Try again!");
                    increment = 0;
                }
                else
                {
                    throw;
                }
                
            }
        }
    }
}
