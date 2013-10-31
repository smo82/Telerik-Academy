using System;

class FindTheBiggestOfThree
{
    static void Main()
    {
        Console.Write("Enter the first number:");
        int number1;

        while (!int.TryParse(Console.ReadLine(), out number1))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        Console.Write("Enter the second number:");
        int number2;

        while (!int.TryParse(Console.ReadLine(), out number2))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        Console.Write("Enter the third number:");
        int number3;

        while (!int.TryParse(Console.ReadLine(), out number3))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        //Solution 1

        int biggestNumber = number1;
        
        if (number1 > number2)
        {
            if (number1 > number3)
            {
                biggestNumber = number1;
            }
            else
            {
                biggestNumber = number3;
            }
        }
        else
        {
            if (number2 > number3)
            {
                biggestNumber = number2;
            }
            else
            {
                biggestNumber = number3;
            }
        }

        Console.WriteLine("The biggest number is: {0}", biggestNumber);

        //Solution2

        biggestNumber = number1;

        if (biggestNumber < number2)
        {
            biggestNumber = number2;
        }

        if (biggestNumber < number3)
        {
            biggestNumber = number3;
        }

        Console.WriteLine("The biggest number is: {0}", biggestNumber);
    }
}
