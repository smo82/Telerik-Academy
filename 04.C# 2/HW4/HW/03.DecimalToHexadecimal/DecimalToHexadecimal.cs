using System;

class DecimalToHexadecimal
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

    static string ConvertDecimalToHexadecimal(int number)
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
            int currentDigit = number % 16;

            switch (currentDigit)
            {
                case 10:
                    result = "A" + result;
                    break;
                case 11:
                    result = "B" + result;
                    break;
                case 12:
                    result = "C" + result;
                    break;
                case 13:
                    result = "D" + result;
                    break;
                case 14:
                    result = "E" + result;
                    break;
                case 15:
                    result = "F" + result;
                    break;
                default:
                    result = currentDigit + result;
                    break;
            }

            number = number / 16;
        }

        return sign + result;
    }

    static void Main()
    {
        int decimalNumber = ReadInt("Enter your decimal number:", int.MinValue);

        Console.WriteLine("Your hexadecimal number is: {0}",ConvertDecimalToHexadecimal(decimalNumber));
    }
}
