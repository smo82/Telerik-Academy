using System;

class MinMaxNumber
{
    static void Main()
    {
        Console.Write("Enter N:");
        int number;

        while ((!int.TryParse(Console.ReadLine(), out number)) || (number < 0))
        {
            Console.Write("Incorrect number, please enter it again:");
        }

        int? min = null;
        int? max = null;
        int[] numberArr = new int[number];
        for (int i = 0; i < number; i++)
        {
            do
            {
                Console.Write("Enter number {0}:", i+1);
            }
            while (!int.TryParse(Console.ReadLine(), out numberArr[i]));

            if ((min > numberArr[i])||(min == null))
            {
                min = numberArr[i];
            }

            if ((max < numberArr[i])||(max == null))
            {
                max = numberArr[i];
            }
        }

        Console.WriteLine("The minimal number is {0}", min);
        Console.WriteLine("The maximal number is {0}", max);
    }
}
