using System;

class ArithmeticOperationsOnSets
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

    static int[] ReadArray(int numberElements)
    {
        int[] elementsList = new int[numberElements];

        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("[{0}]:", i);
            while (!int.TryParse(Console.ReadLine(), out elementsList[i]))
            {
                Console.Write("Wrong number. Please try again:");
            }
        }

        return elementsList;
    }

    static int CalcMinimum (int [] array)
    {
        int min = int.MaxValue;

        for (int i = 0; i < array.Length; i++)
        {
            if (min > array[i])
            {
                min = array[i];
            }
        }

        return min;
    }

    static int CalcMaximum(int[] array)
    {
        int max = int.MinValue;

        for (int i = 0; i < array.Length; i++)
        {
            if (max < array[i])
            {
                max = array[i];
            }
        }

        return max;
    }

    static int CalcSum(int[] array)
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        return sum;
    }

    static int CalcProduct(int[] array)
    {
        int product = 1;
        for (int i = 0; i < array.Length; i++)
        {
            product *= array[i];
        }

        return product;
    }

    static int CalcAvarage(int[] array)
    {
        return CalcSum(array) / array.Length;
    }
    
    static void Main()
    {
        int numberElements = ReadInt("Enter the length of the sequence:", 1);
        int[] elementsList = new int[numberElements];
        elementsList = ReadArray(numberElements);

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
