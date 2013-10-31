using System;
using System.Collections.Generic;

class DevidorsMain
{
    static int smallestNumber;
    static int smallestNumberDeviders;

    static void Main(string[] args)
    {
        int numbersCount = int.Parse(Console.ReadLine());

        string[] numbers = new string[numbersCount];
        for (int i = 0; i < numbersCount; i++)
        {
            numbers[i] = Console.ReadLine();
        }

        smallestNumber = int.MaxValue;
        smallestNumberDeviders = int.MaxValue;

        GenerateAllCombinations(numbersCount - 1, numbers);

        Console.WriteLine(smallestNumber);
    }
  
    private static void GenerateAllCombinations(int endIndex, string[] numbers)
    {
        if (endIndex < 0)
        {
            return;
        }

        for (int currentIndex = endIndex; currentIndex >= 0; currentIndex--)
        {
            if ((numbers[endIndex] != numbers[currentIndex]) || (currentIndex == endIndex))
            {
                ReplaceValues(numbers, currentIndex, endIndex);
                CheckCurrentNumber(numbers);

                GenerateAllCombinations(endIndex - 1, numbers);

                ReplaceValues(numbers, endIndex, currentIndex);
            }
        }
    }

    private static void CheckCurrentNumber(string[] numbers)
    {
        int generatedNumber = GenerateNumber(numbers);
        int numberOfDeviders = CountDeviders(generatedNumber);
        if (numberOfDeviders < smallestNumberDeviders)
        {
            smallestNumber = generatedNumber;
            smallestNumberDeviders = numberOfDeviders;
        }
        else if (numberOfDeviders == smallestNumberDeviders)
        {
            if (generatedNumber < smallestNumber)
            {
                smallestNumber = generatedNumber;
            }
        }
    }

    private static int GenerateNumber(string[] numbers)
    {
        return int.Parse(string.Join("", numbers));
    }

    private static int CountDeviders(int number)
    {
        int numberOfDeviders = 1;
        for (int i = 2; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                numberOfDeviders += 2;
            }
        }
        return numberOfDeviders;
    }

    private static void ReplaceValues(string[] numbers, int i, int j)
    {
        string temp = numbers[i];
        numbers[i] = numbers[j];
        numbers[j] = temp;
    }
}