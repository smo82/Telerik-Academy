using System;

class GetMaxFromThree
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

    static int GetMax (int firstNumber, int secondNumber)
    {
        if (firstNumber >= secondNumber)
        {
            return firstNumber;
        }
        else
        {
            return secondNumber;
        }
    }

    static void Main()
    {
        int firstNumber = ReadInt("Please enter the first number:");
        int secondNumber = ReadInt("Please enter the second number:");
        int thirdNumber = ReadInt("Please enter the third number:");

        int maxNumber = GetMax(GetMax(firstNumber, secondNumber), thirdNumber);
        Console.WriteLine(new String('*', 20));
        Console.WriteLine("The biggest number is: {0}", maxNumber);
    }
}
