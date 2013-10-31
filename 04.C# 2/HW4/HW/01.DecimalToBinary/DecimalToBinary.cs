using System;

class Program
{
    static int ReadInt(string message = "Enter N:", int minValue = 0, int maxValue = int.MaxValue)
    {
        Console.Write(message);

        int resultInt;
        while ((!int.TryParse(Console.ReadLine(), out resultInt)) || (resultInt < minValue) || (resultInt > maxValue))
        {
            Console.Write("Wrong number. Please try again:");
        }

        return resultInt;
    }

    static string ConvertIntToBinary(int number)
    {
        string result = "";
        string sign = "";

        if (number < 0)
        {
            sign = "-";
            number = -number;
        }
        else if (number == 0)
        {
            result = "0";
        }

        while (number > 0)
        {
            result = number % 2 + result;
            number = number / 2;
        }

        return sign + result;
    }

    static void Main()
    {
        int decimalNumber = ReadInt("Enter your decimal number:", int.MinValue);

        Console.WriteLine("Your binary number is: {0}", ConvertIntToBinary(decimalNumber));
    }
}
