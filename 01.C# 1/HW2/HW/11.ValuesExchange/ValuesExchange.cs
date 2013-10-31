using System;



class ValuesExchange
{
    static void Main()
    {
        int intVariable1 = 5;
        int intVariable2 = 10;

        Console.WriteLine("Value of Variable1: {0}; Value of Variable2: {1} ", intVariable1, intVariable2);

        int transitVarible = intVariable2;
        intVariable2 = intVariable1;
        intVariable1 = transitVarible;

        Console.WriteLine("Value of Variable1: {0}; Value of Variable2: {1} ", intVariable1, intVariable2);
    }
}