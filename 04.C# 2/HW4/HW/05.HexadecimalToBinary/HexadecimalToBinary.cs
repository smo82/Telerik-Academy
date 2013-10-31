using System;

class HexadecimalToBinary
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

    static string ConvertHexadecimalToBinary(string hexadecimalNumber)
    {
        string result = "";

        string sign = "";
        int leftBorderIndex = 0;
        if (hexadecimalNumber[0] == '-')
        {
            sign = "-";
            leftBorderIndex = 1;
        }

        int index = hexadecimalNumber.Length - 1;
        while (index >= leftBorderIndex)
        {
            switch (hexadecimalNumber[index])
            {
                case '0' :
                    result = "0000" + result;
                    break;
                case '1':
                    result = "0001" + result;
                    break;
                case '2':
                    result = "0010" + result;
                    break;
                case '3':
                    result = "0011" + result;
                    break;
                case '4':
                    result = "0100" + result;
                    break;
                case '5':
                    result = "0101" + result;
                    break;
                case '6':
                    result = "0110" + result;
                    break;
                case '7':
                    result = "0111" + result;
                    break;
                case '8':
                    result = "1000" + result;
                    break;
                case '9':
                    result = "1001" + result;
                    break;
                case 'A':
                    result = "1010" + result;
                    break;
                case 'B':
                    result = "1011" + result;
                    break;
                case 'C':
                    result = "1100" + result;
                    break;
                case 'D':
                    result = "1101" + result;
                    break;
                case 'E':
                    result = "1110" + result;
                    break;
                case 'F':
                    result = "1111" + result;
                    break; 
            }
            index--;
        }

        return sign + result;
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

        Console.WriteLine("Your binary number is: {0}", ConvertHexadecimalToBinary(hexadecimalNumber));
    }
}
