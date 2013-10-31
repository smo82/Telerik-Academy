using System;

class BinaryToHexadecimal
{
    static bool CheckBinaryNumberString(string bynaryNumber)
    {
        if (bynaryNumber == "")
        {
            return false;
        }

        bool result = true;       

        int index = 0;
        if (bynaryNumber[0] == '-')
        {
            index = 1;
        }

        while ((result) && (index < bynaryNumber.Length))
        {
            if ((bynaryNumber[index] != '0') && (bynaryNumber[index] != '1'))
            {
                result = false;
            }
            index++;
        }

        return result;
    }

    static string StringReverse(string text)
    {
        if (text == "") return "";

        char[] array = text.ToCharArray();
        Array.Reverse(array);
        return new String(array);
    }

    static string ConvertBinaryToHexadecimal(string binaryNumber)
    {
        string result = "";

        string sign = "";
        if (binaryNumber[0] == '-')
        {
            sign = "-";
            binaryNumber = binaryNumber.Substring(1, binaryNumber.Length - 1);
        }

        while (binaryNumber.Length > 0)
        {
            string subPartBinary = "";
            if (binaryNumber.Length < 4)
            {
                subPartBinary = binaryNumber.PadLeft(4, '0');
                binaryNumber = "";
            }
            else
            {
                subPartBinary = binaryNumber.Substring(binaryNumber.Length - 4);
                binaryNumber = binaryNumber.Substring(0, binaryNumber.Length - 4);
            }

            switch (subPartBinary)
            {
                case "0000":
                    result = "0" + result;
                    break;
                case "0001":
                    result = "1" + result;
                    break;
                case "0010":
                    result = "2" + result;
                    break;
                case "0011":
                    result = "3" + result;
                    break;
                case "0100":
                    result = "4" + result;
                    break;
                case "0101":
                    result = "5" + result;
                    break;
                case "0110":
                    result = "6" + result;
                    break;
                case "0111":
                    result = "7" + result;
                    break;
                case "1000":
                    result = "8" + result;
                    break;
                case "1001":
                    result = "9" + result;
                    break;
                case "1010":
                    result = "A" + result;
                    break;
                case "1011":
                    result = "B" + result;
                    break;
                case "1100":
                    result = "C" + result;
                    break;
                case "1101":
                    result = "D" + result;
                    break;
                case "1110":
                    result = "E" + result;
                    break;
                case "1111":
                    result = "F" + result;
                    break;
            }
        }

        return sign + result;
    }

    static void Main()
    {
        Console.Write("Enter your binary number:");
        string binaryNumber = Console.ReadLine();

        while (!CheckBinaryNumberString(binaryNumber))
        {
            Console.Write("Wrong number. Please try again:");
            binaryNumber = Console.ReadLine();
        }

        Console.WriteLine("Your hexadecimal number is: {0}", ConvertBinaryToHexadecimal(binaryNumber));
    }
}
