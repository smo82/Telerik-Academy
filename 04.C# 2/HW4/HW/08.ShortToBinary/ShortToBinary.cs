using System;
using System.Text;

class ShortToBinary
{
    static short ReadInt(string message = "Enter N:", short minValue = short.MinValue, short maxValue = short.MaxValue)
    {
        Console.Write(message);

        short resultInt;
        while ((!short.TryParse(Console.ReadLine(), out resultInt)) || (resultInt < minValue) || (resultInt > maxValue))
        {
            Console.Write("Wrong number. Please try again:");
        }

        return resultInt;
    }

    static string ConvertToBinary(int number)
    {
        StringBuilder result = new StringBuilder();
        char sign = '0';
        int signIncrement = 0;

        if (number < 0)
        {
            sign = '1';
            number = -number - 1;
            signIncrement = 1;
        }
        else if (number == 0)
        {
            return new String('0', 16);
        }

        while (number > 0)
        {
            //We use the signIncrement variable to replace the 0 with 1 and viceversa for the negative numbers
            result.Insert(0, (number + signIncrement) % 2);
            number = number / 2;
        }

        return sign + result.ToString().PadLeft(15, sign);
    }

    static void Main()
    {
        short shortNumber = ReadInt("Enter the number you want to see binary represented:");

        Console.WriteLine(new String('*', 20));

        Console.WriteLine("The binary representation of your number is: {0}", ConvertToBinary(shortNumber));
        
        Console.WriteLine("Control conversion:                          {0}", Convert.ToString(shortNumber, 2).PadLeft(16,'0'));
    }
}
