using System;

class IntDoubleNull
{
    static void Main()
    {
        int? intVariable = null;
        double? doubleVariable = null;

        Console.WriteLine("Int variable: {0}; Double variable: {1} ", intVariable, doubleVariable);

        intVariable = intVariable + 5;
        doubleVariable = doubleVariable + 1.23;

        Console.WriteLine("Int variable: {0}; Double variable: {1} ", intVariable, doubleVariable);

        intVariable = intVariable + null;
        doubleVariable = doubleVariable + null;

        Console.WriteLine("Int variable: {0}; Double variable: {1} ", intVariable, doubleVariable);
    }
}