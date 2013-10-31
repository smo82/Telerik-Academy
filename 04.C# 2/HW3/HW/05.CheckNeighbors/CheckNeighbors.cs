using System;

class CheckNeighbors
{
    static int ReadInt(string message = "Enter N:", int maxValue = int.MaxValue)
    {
        Console.Write(message);

        int resultInt;
        while ((!int.TryParse(Console.ReadLine(), out resultInt)) || (resultInt < 0) || (resultInt > maxValue))
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

    static bool IsBiggerThenNeighbors (int index, int [] elementsList)
    {
        if (index >= elementsList.Length)
        {
            return false;
        }
        else
        {
            bool isBigger = true;

            if (((index - 1) >= 0) && (elementsList[index]<=elementsList[index-1]))
            {
                isBigger = false;
            }

            if (((index + 1) < elementsList.Length) && (elementsList[index] <= elementsList[index + 1]))
            {
                isBigger = false;
            }

            return isBigger;
        }
    }


    static void Main()
    {
        int numberElements = ReadInt("Enter the number of elements in your array: ");

        int[] elementsList = new int[numberElements];
        elementsList = ReadArray(numberElements);

        int indexChecked = ReadInt("Enter the index you want to check: ", numberElements-1);
        
        Console.WriteLine(new String('*', 20));
        if (IsBiggerThenNeighbors(indexChecked, elementsList))
        {
            Console.WriteLine("The number at your index is bigger then its neighbors!");
        }
        else
        {
            Console.WriteLine("The number at your index is NOT bigger then all its neighbors!");
        }
    }
}
