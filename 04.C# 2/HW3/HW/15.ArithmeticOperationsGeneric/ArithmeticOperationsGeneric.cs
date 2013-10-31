using System;
using System.ComponentModel;
using System.Collections.Generic;

class ArithmeticOperationsGeneric
{
    static int ReadInt(string message = "Enter N:", int minValue = 0, int maxValue = int.MaxValue)
    {
        Console.Write(message);

        int resultInt;
        while ((!int.TryParse(Console.ReadLine(), out resultInt)) || (resultInt < minValue) || (resultInt > maxValue))
        {
            Console.Write("Wrong number. Please try again:");
        }

        return resultInt;
    }

    static bool TryParse<T>(string input, out T result)
    {
        result = default(T);
        try
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            result = (T)converter.ConvertFromString(input);
        }
        catch
        {
            return false;
        }

        return true;
    }

    static T[] ReadArray<T>(int numberElements)
    {
        T[] elementsList = new T[numberElements];

        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("[{0}]:", i);
            while (!TryParse<T>(Console.ReadLine(), out elementsList[i]))
            {
                Console.Write("Wrong number. Please try again:");
            }
        }

        return elementsList;
    }

    static T CalcMinimum<T>(T[] array)
    {
        dynamic min = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            if (min > array[i])
            {
                min = array[i];
            }
        }

        return min;
    }

    static T CalcMaximum<T>(T[] array)
    {
        dynamic max = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            if (max < array[i])
            {
                max = array[i];
            }
        }

        return max;
    }

    static T CalcSum <T>(T[] array)
    {
        dynamic sum = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            sum += array[i];
        }

        return sum;
    }

    static T CalcProduct <T>(T[] array)
    {
        dynamic product = 1;
        for (int i = 0; i < array.Length; i++)
        {
            product *= array[i];
        }

        return product;
    }

    static T CalcAvarage<T>(T[] array)
    {
        return (dynamic) CalcSum(array) / array.Length;
    }

    static void Main()
    {
        Console.WriteLine("Choose the type of your elements:");
        Console.WriteLine("1 - Byte");
        Console.WriteLine("2 - Short");
        Console.WriteLine("3 - Int");
        Console.WriteLine("4 - Long");
        Console.WriteLine("5 - Float");
        Console.WriteLine("6 - Double");
        Console.WriteLine("7 - Decimal");
        int typeChoise = ReadInt("", 1, 7);

        Console.WriteLine(new String('*', 20));
        int numberElements = ReadInt("Enter the length of the sequence:", 1);

        dynamic elementsList;
        switch (typeChoise)
        {
            case 1:
                elementsList = ReadArray<byte>(numberElements);
                break;
            case 2:
                elementsList = ReadArray<short>(numberElements);
                break;
            case 3:
                elementsList = ReadArray<int>(numberElements);
                break;
            case 4:
                elementsList = ReadArray<long>(numberElements);
                break;
            case 5:
                elementsList = ReadArray<float>(numberElements);
                break;
            case 6:
                elementsList = ReadArray<double>(numberElements);
                break;
            default :
                elementsList = ReadArray<decimal>(numberElements);
                break;
        }       

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Choose the function you want to use:");
        Console.WriteLine("1 - Calculate minimum");
        Console.WriteLine("2 - Calculate maximum");
        Console.WriteLine("3 - Calculate average");
        Console.WriteLine("4 - Calculate sum");
        Console.WriteLine("5 - Calculate product");

        int operation = ReadInt("", 1, 5);

        Console.WriteLine(new String('*', 20));
        switch (operation)
        {
            case 1:
                Console.WriteLine("The minimum is: {0}", CalcMinimum(elementsList));
                break;
            case 2:
                Console.WriteLine("The maximum is: {0}", CalcMaximum(elementsList));
                break;
            case 3:
                Console.WriteLine("The average is: {0}", CalcAvarage(elementsList));
                break;
            case 4:
                Console.WriteLine("The sum is: {0}", CalcSum(elementsList));
                break;
            case 5:
                Console.WriteLine("The product is: {0}", CalcProduct(elementsList));
                break;
        }
    }
}
