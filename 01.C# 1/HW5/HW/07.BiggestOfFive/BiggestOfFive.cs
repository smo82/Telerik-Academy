using System;

class BiggestOfFive
{
    static void Main()
    {
        int[] numbers = new int[5];

        for (int i = 0; i < 5; i++)
        {
            Console.Write("Enter number {0}:", i+1);

            while (!int.TryParse(Console.ReadLine(), out numbers[i]))
            {
                Console.Write("Incorrect number, please enter it again:");
            }
        }

        int tempNumber = 0;
               
        for (int i = 0; i < (numbers.Length - 1); i++)
        {
            for (int j = i+1; j < numbers.Length; j++)
            {
                if (numbers[i] < numbers[j])
                {
                    tempNumber = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = tempNumber;
                }
            }
        }

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Number {0}:{1}", i+1, numbers[i]);
        }
    }
}
