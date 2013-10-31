using System;

class VariableCompare
{
    static void Main(string[] args)
    {
        Console.Write("Please enter the first number: ");
        decimal variable1 = decimal.Parse(Console.ReadLine());

        Console.Write("Please enter the second number: ");
        decimal variable2 = decimal.Parse(Console.ReadLine());

        bool result;

        if ((variable1 * variable2) > 0)	//Both numbers are with the same sign
        {
            result = (0.000001m > (Math.Abs(variable1 - variable2)));
        }
        else
        {
            result = false;
        }

        Console.WriteLine("The result of the comparison is {0}", result);
    }
}
