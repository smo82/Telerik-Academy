using System;

class FindGCD
{
    static int CalcGCDIterative(int number1, int number2)
    {
        int tempNumber = 0;
        while (number2 != 0)
        {
            tempNumber = number2;
            number2 = number1%number2;
            number1 = tempNumber;
        }

        return number1;
    }

    static int CalcGCD(int number1, int number2)
    {
        int min = Math.Min(number1, number2);
        int max = Math.Max(number1, number2);

        if (min == 0)
        {
            return max;
        }
        else if (number1 == number2)
        {
            return number1;
        }
        else
        {
            return CalcGCD(min, max - min);
        }
    }

    static int CalcGCDOptimized(int number1, int number2)
    {
        if (number2 == 0)
        {
            return number1;
        }
        else
        {
            return CalcGCD(number2, number1%number2);
        }
    }

    static void Main()
    {
        Console.WriteLine("We will calculate the Greatest Common Devidor (GCD) of 2 numbers.");
        Console.Write("Enter the first number:");
        int number1;

        while (!int.TryParse(Console.ReadLine(), out number1))
        {
            Console.Write("Incorrect number, please enter it again:");
        }
        number1 = Math.Abs(number1);

        Console.Write("Enter the second number:");
        int number2;

        while (!int.TryParse(Console.ReadLine(), out number2))
        {
            Console.Write("Incorrect number, please enter it again:");
        }
        number2 = Math.Abs(number2);

        //Solution1
        Console.WriteLine("The GCD is: {0}", CalcGCDIterative(number1, number2));

        //Solution2
        Console.WriteLine("The GCD is: {0}", CalcGCD(number1, number2));

        //Solution3
        Console.WriteLine("The GCD is: {0}", CalcGCDOptimized(number1, number2));
    }
}
