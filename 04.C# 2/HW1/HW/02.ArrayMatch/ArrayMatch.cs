using System;

class ArrayMatch
{
    static void Main()
    {
        Console.Write("Enter the length of the arrays:");
        int numberElements;

        while ((!int.TryParse(Console.ReadLine(), out numberElements)) || (numberElements <= 0))
        {
            Console.Write("Wrong length. Please try again:");
        }

        int[] numberArr1 = new int[numberElements];
        int[] numberArr2 = new int[numberElements];

        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("Enter element {0} from the first array:", i);
            numberArr1[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine(new String('*', 30));

        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("Enter element {0} from the second array:", i);
            numberArr2[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine(new String('*', 30));

        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("For element number {0} the result is:", i);
            if (numberArr1[i] > numberArr2[i])
            {
                Console.WriteLine("The value in the first array is bigger then the value in the second array ({0}>{1})", numberArr1[i], numberArr2[i]);
            }
            else if (numberArr1[i] < numberArr2[i])
            {
                Console.WriteLine("The value in the second array is bigger then the value in the first array ({1}>{0})", numberArr1[i], numberArr2[i]);
            }
            else
            {
                Console.WriteLine("The values in both arrays are equal ({0}={1})", numberArr1[i], numberArr2[i]);
            }
        }

        Console.WriteLine(new String('*', 30));

        int arrCounter = numberElements - 1;
        while ((arrCounter >= 0) && (numberArr1[arrCounter] == numberArr2[arrCounter]))
        {
            arrCounter--;
        }

        if (arrCounter == -1)
        {
            Console.WriteLine("The two arrays are equal!");
        }
        else
        {
            Console.WriteLine("The two arrays are different!");
        }
    }
}