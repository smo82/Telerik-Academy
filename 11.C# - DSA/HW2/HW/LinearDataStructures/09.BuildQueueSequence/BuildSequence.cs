/*
 * Task09
 * 
 * We are given the following sequence:
 * S1 = N;
 * S2 = S1 + 1;
 * S3 = 2*S1 + 1;
 * S4 = S1 + 2;
 * S5 = S2 + 1;
 * S6 = 2*S2 + 1;
 * S7 = S2 + 2;
 * ...
 * Using the Queue<T> class write a program to print its first 50 members for given N.
 * Example: N=2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
 */

using System;
using System.Collections.Generic;

public class BuildSequence
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter the first number in the sequence (N):");
        int startNumber = FunctionsCollection.ReadIntInRange();

        List<int> newSequence = GenerateSequence(startNumber, 50);

        Console.WriteLine("The result sequence with 50 members is:");
        FunctionsCollection.PrintIntList(newSequence);
    }

    private static List<int> GenerateSequence(int startNumber, int sequenceLength)
    {
        Queue<int> generatedSequence = new Queue<int>();

        generatedSequence.Enqueue(startNumber);

        List<int> resultSequence = new List<int>();
        int genertedSequenceLenght = 1;
        while (genertedSequenceLenght < sequenceLength)
        {
            int currentItem = generatedSequence.Dequeue();
            resultSequence.Add(currentItem);

            generatedSequence.Enqueue(currentItem + 1);
            generatedSequence.Enqueue((2 * currentItem) + 1);
            generatedSequence.Enqueue(currentItem + 2);
            genertedSequenceLenght += 3;
        }

        for (int i = resultSequence.Count; i < sequenceLength; i++)
        {
            int currentItem = generatedSequence.Dequeue();
            resultSequence.Add(currentItem);
        }

        return resultSequence;
    }
}
