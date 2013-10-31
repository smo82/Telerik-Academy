using System;

class ReverseUserNumber
{
    static int ReadInt(string message = "Enter N:")
    {
        Console.Write(message);

        int resultInt;
        while (!int.TryParse(Console.ReadLine(), out resultInt))
        {
            Console.Write("Wrong number. Please try again:");
        }

        return resultInt;
    }

    static int ReverseNumber (int number)
    {
        int sign = 1;
        if (number<0)
        {
            sign = -1;
            number = -number;
        }

        int power = 1;
        int reversedNumber = 0;
        while (number > 0)
        {
            int currentDigit = number % 10;
            reversedNumber = reversedNumber * power + currentDigit;
            number = number / 10;
            power = 10;
        }

        return reversedNumber * sign;
    }

    static void Main()
    {
        int number = ReadInt("Enter your number: ");

        Console.WriteLine("Your reversed number is: {0}", ReverseNumber(number));
    }
}
