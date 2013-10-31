using System;
using System.Collections.Generic;

class FindKElementsMaxSum
{
    static void Main()
    {
        Console.Write("Enter the length of the array (N):");
        int numberElements;

        while ((!int.TryParse(Console.ReadLine(), out numberElements)) || (numberElements <= 0))
        {
            Console.Write("Wrong N. Please try again:");
        }

        Console.Write("Enter the length of the sub-array to sum (K):");
        int numberElementsSubArr;

        while ((!int.TryParse(Console.ReadLine(), out numberElementsSubArr)) || 
               (numberElementsSubArr <= 0) || 
               (numberElementsSubArr > numberElements))
        {
            Console.Write("Wrong K. Please try again:");
        }

        int [] elementsArr = new int [numberElements];
        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("Enter element {0}:", i);
            elementsArr[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(elementsArr);

        Console.WriteLine(new String('*', 30));
        Console.WriteLine("The {0} elements with the biggest sum are:", numberElementsSubArr);
        for (int i = 0; i < numberElementsSubArr; i++)
        {
            Console.WriteLine(elementsArr[numberElements - i - 1]);
        }
    }
}
