using System;

class MultifunctionalProgram
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

    static int ReverseNumber(int number)
    {
        int sign = 1;
        if (number < 0)
        {
            sign = -1;
            number = -number;
        }

        int power = 1;
        int reversedNumber = 0;
        while (number > 0)
        {
            int currentDigit = number % 10;
            reversedNumber = reversedNumber * power + currentDigit;
            number = number / 10;
            power = 10;
        }

        return reversedNumber * sign;
    }

    static int CalcAvarage (int [] array)
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        return sum / array.Length;
    }

    static int CalcLinearEquation (int a, int b)
    {
        return -b / a;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Choose the function you want to use:");
        Console.WriteLine("1 - Reverse number");
        Console.WriteLine("2 - Calculate average of a sequence of numbers");
        Console.WriteLine("3 - Solve a linear expression");

        int operation = ReadInt("", 1, 3);

        switch (operation)
        {
            case 1:
                int number = ReadInt("Enter your number:", int.MinValue);
                number = ReverseNumber(number);
                Console.WriteLine(new String('*', 20));
                Console.WriteLine("Your reversed number is: {0}", number);
                break;
            case 2:
                int numberElements = ReadInt("Enter the length of the sequence:");
                int[] elementsList = new int[numberElements];
                elementsList = ReadArray(numberElements);
                Console.WriteLine(new String('*', 20));
                Console.WriteLine("The average is: {0}", CalcAvarage(elementsList));
                break;
            case 3:
                int a = ReadInt("Enter coeficient \"a\":", 1);
                int b = ReadInt("Enter coeficient \"b\":");
                Console.WriteLine(new String('*', 20));
                Console.WriteLine("The result is: x={0}", CalcLinearEquation(a, b));
                break;
        }
    }
}
