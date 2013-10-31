using System;

public class CountMeetings
{
    static int ReadInt(string message = "Enter N:")
    {
        Console.Write(message);

        int resultInt;
        while ((!int.TryParse(Console.ReadLine(), out resultInt)) || (resultInt < 0))
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

    public static int CountNumberMeetings(int numberSearched, int[] elementsList)
    {
        int count = 0;
        for (int i = 0; i < elementsList.Length; i++)
        {
            if (elementsList[i] == numberSearched)
            {
                count++;
            }
        }

        return count;
    }

    static void Main()
    {
        int numberSearched = ReadInt("Enter the number you want to count: ");
        int numberElements = ReadInt("Enter the number of elements in your array: ");

        int[] elementsList = new int[numberElements];
        elementsList = ReadArray(numberElements);

        int count = CountNumberMeetings(numberSearched, elementsList);
        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your number was found {0} times in the array", count);
    }
}
