using System;

class HexadecimalToDecimal
{
    static bool CheckHexadecimalNumberString(string hexadecimalNumber)
    {
        bool result = true;
        int index = 0;
        if (hexadecimalNumber[0] == '-')
        {
            index = 1;
        }

        string allowedChar = "0123456789ABCDEF";

        while ((result) && (index < hexadecimalNumber.Length))
        {
            if (allowedChar.IndexOf(hexadecimalNumber[index]) == -1)
            {
                result = false;
            }
            index++;
        }

        return result;
    }

    static int ConvertHexadecimalToDecimal(string hexadecimalNumber)
    {
        int result = 0;

        int sign = 1;
        int leftBorderIndex = 0;
        if (hexadecimalNumber[0] == '-')
        {
            sign = -1;
            leftBorderIndex = 1;
        }

        string allowedChar = "0123456789ABCDEF";
        int index = hexadecimalNumber.Length - 1;
        int power = 1;
        while (index >= leftBorderIndex)
        {
            result += allowedChar.IndexOf(hexadecimalNumber[index]) * power;
            power *= 16;
            index--;
        }

        return result * sign;
    }

    static void Main()
    {
        Console.Write("Enter your binary number:");
        string hexadecimalNumber = Console.ReadLine();

        while (!CheckHexadecimalNumberString(hexadecimalNumber))
        {
            Console.Write("Wrong number. Please try again:");
            hexadecimalNumber = Console.ReadLine();
        }

        Console.WriteLine("Your decimal number is: {0}", ConvertHexadecimalToDecimal(hexadecimalNumber));
    }
}
