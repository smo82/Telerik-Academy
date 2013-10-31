using System;

class LastDigit
{
    static int ReadInt(string message = "Enter N:")
    {
        Console.Write(message);

        int resultInt;
        while ((!int.TryParse(Console.ReadLine(), out resultInt)) || (resultInt <= 0))
        {
            Console.Write("Wrong number. Please try again:");
        }

        return resultInt;
    }

    static string GetLastDigit(int number)
    {
        int lastDigit = number % 10;
        string lastDigitString = "";

        switch (lastDigit)
        {
            case 0:
                lastDigitString = "Zero";
                break;
            case 1:
                lastDigitString = "One";
                break;
            case 2:
                lastDigitString = "Two";
                break;
            case 3:
                lastDigitString = "Three";
                break;
            case 4:
                lastDigitString = "Four";
                break;
            case 5:
                lastDigitString = "Five";
                break;
            case 6:
                lastDigitString = "Six";
                break;
            case 7:
                lastDigitString = "Seven";
                break;
            case 8:
                lastDigitString = "Eight";
                break;
            case 9:
                lastDigitString = "Nine";
                break;            
        }

        return lastDigitString;
    }
    static void Main()
    {
        int number = ReadInt("Please enter your number:");

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("The last digit of your number is: {0}", GetLastDigit(number));
    }
}
