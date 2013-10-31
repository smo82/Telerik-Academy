using System;

class LengthMaxSequence
{
    static void Main()
    {
        Console.Write("Please enter the array:");
        string inputCharArray = Console.ReadLine();

        while (inputCharArray.Length < 1)
        {
            Console.Write("Please enter the array again:");
            inputCharArray = Console.ReadLine();
        }

        char currentChar = inputCharArray[0];
        int currentMaxLength = 1;
        int lastMaxLength = 1;

        for (int i = 1; i < inputCharArray.Length; i++)
        {
            if (inputCharArray[i] == currentChar)
            {
                currentMaxLength++;
            }
            else if (currentMaxLength > lastMaxLength)
            {
                lastMaxLength = currentMaxLength;
                currentMaxLength = 1;
                currentChar = inputCharArray[i];
            }
            else
            {
                currentMaxLength = 1;
                currentChar = inputCharArray[i];
            }
        }

        if (currentMaxLength > lastMaxLength)
        {
            lastMaxLength = currentMaxLength;
        }

        Console.WriteLine("The length of the max sequence is: {0}", lastMaxLength);
    }
}