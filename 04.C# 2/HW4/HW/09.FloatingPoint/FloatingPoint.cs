using System;
using System.Text;

class FloatingPoint
{
    static float ReadInt(string message = "Enter N:")
    {
        Console.Write(message);

        float resultInt;
        while (!float.TryParse(Console.ReadLine(), out resultInt))
        {
            Console.Write("Wrong number. Please try again:");
        }

        return resultInt;
    }

    static void Main(string[] args)
    {
        float floatNumber = ReadInt("Enter the floating number you want to see binary represented:");

        byte [] byteArr = BitConverter.GetBytes(floatNumber);
        Array.Reverse(byteArr);
        StringBuilder bytesNumber = new StringBuilder();

        for (int i = 0; i < byteArr.Length; i++)
        {
            bytesNumber.Append(Convert.ToString(byteArr[i], 2).PadLeft(8, '0'));
        }

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Sign: {0}", bytesNumber.ToString(0, 1));
        Console.WriteLine("Exponent: {0}", bytesNumber.ToString(1, 8));
        Console.WriteLine("Mantis: {0}", bytesNumber.ToString(9, 23));
    }
}
