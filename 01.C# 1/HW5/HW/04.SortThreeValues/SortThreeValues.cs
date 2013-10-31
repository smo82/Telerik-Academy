using System;

class SortThreeValues
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

        //Solution1

        if (number1 > number2)
        {
            if (number2 > number3)
            {
                Console.WriteLine("Value1 : {0}", number1);
                Console.WriteLine("Value2 : {0}", number2);
                Console.WriteLine("Value3 : {0}", number3);
            }
            else if (number1 > number3)
            {
                Console.WriteLine("Value1 : {0}", number1);
                Console.WriteLine("Value2 : {0}", number3);
                Console.WriteLine("Value3 : {0}", number2);
            }
            else
            {
                Console.WriteLine("Value1 : {0}", number3);
                Console.WriteLine("Value2 : {0}", number1);
                Console.WriteLine("Value3 : {0}", number2);
            }
        }
        else
        {
            if (number1 > number3)
            {
                Console.WriteLine("Value1 : {0}", number2);
                Console.WriteLine("Value2 : {0}", number1);
                Console.WriteLine("Value3 : {0}", number3);
            }
            else if (number2 > number3)
            {
                Console.WriteLine("Value1 : {0}", number2);
                Console.WriteLine("Value2 : {0}", number3);
                Console.WriteLine("Value3 : {0}", number1);
            }
            else
            {
                Console.WriteLine("Value1 : {0}", number3);
                Console.WriteLine("Value2 : {0}", number2);
                Console.WriteLine("Value3 : {0}", number1);
            }
        }

        //Solution2
        int biggest = number1;
        int middle = number2;
        int smallest = number3;
        int tempNumber;

        if (biggest < middle)
        {
            tempNumber = biggest;
            biggest = middle;
            middle = tempNumber;
        }

        if (biggest < smallest)
        {
            tempNumber = biggest;
            biggest = smallest;
            smallest = tempNumber;
        }

        if (middle < smallest)
        {
            tempNumber = middle;
            middle = smallest;
            smallest = tempNumber;
        }

        Console.WriteLine("Value1 : {0}", biggest);
        Console.WriteLine("Value2 : {0}", middle);
        Console.WriteLine("Value3 : {0}", smallest);
    }
}
