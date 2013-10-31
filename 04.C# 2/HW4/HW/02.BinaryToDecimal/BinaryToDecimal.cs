using System;

class BinaryToDecimal
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

    static int ConvertBynaryToDecimal(string bynaryNumber)
    {
        int result = 0;

        int sign = 1;
        int leftBorderIndex = 0;
        if (bynaryNumber[0] == '-')
        {
            sign = -1;
            leftBorderIndex = 1;
        }

        int index = bynaryNumber.Length-1;
        int power = 1;
        while (index >= leftBorderIndex)
        {
            result += int.Parse(bynaryNumber[index].ToString()) * power;
            power *= 2;
            index--;
        }

        return result*sign;
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

        Console.WriteLine("Your decimal number is: {0}", ConvertBynaryToDecimal(binaryNumber));
    }
}
