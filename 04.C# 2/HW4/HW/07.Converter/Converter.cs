using System;

class Converter
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

    static bool CheckNumberString(int sourceNumberBase, string hexadecimalNumber)
    {
        bool result = true;
        int index = 0;
        if (hexadecimalNumber[0] == '-')
        {
            index = 1;
        }

        string allowedChar = "0123456789ABCDEF".Substring(0, sourceNumberBase);

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

    static int ConvertToDecimal(int sourseNumberBase, string hexadecimalNumber)
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
            power *= sourseNumberBase;
            index--;
        }

        return result * sign;
    }

    static string ConvertToNumber(int targetNumberBase, int number)
    {
        if (targetNumberBase == 10)
        {
            return number + "";
        }

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
            int currentDigit = number % targetNumberBase;

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

            number = number / targetNumberBase;
        }

        return sign + result;
    }

    static void Main()
    {
        int sourseNumberBase = ReadInt("Enter the base of the source number:", 2, 16);
        int targetNumberBase = ReadInt("Enter the base of the target number:", 2, 16);


        Console.Write("Enter your source number:");
        string sourseNumber = Console.ReadLine();

        while (!CheckNumberString(sourseNumberBase, sourseNumber))
        {
            Console.Write("Wrong number. Please try again:");
            sourseNumber = Console.ReadLine();
        }

        int decimalNumber = ConvertToDecimal(sourseNumberBase, sourseNumber);

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your result number in base {0} is: {1}", targetNumberBase, ConvertToNumber(targetNumberBase, decimalNumber));
    }
}
