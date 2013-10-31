/*
 * Task10*
 * 
 * We are given numbers N and M and the following operations:
 * N = N+1
 * N = N+2
 * N = N*2
 * Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. 
 * Hint: use a queue.
 * Example: N = 5, M = 16
 * Sequence: 5 -> 7 -> 8 -> 16
 */

using System;
using System.Collections.Generic;

public class FindShortestOperationSequence
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter the first number in the sequence (N):");
        int startNumber = FunctionsCollection.ReadIntInRange();

        Console.WriteLine("Please enter the searched number in the sequence (M > N):");
        int searchedNumber = FunctionsCollection.ReadIntInRange(startNumber + 1);

        List<int> shortestSequence = GenerateShortestSequence(startNumber, searchedNumber);

        Console.WriteLine("The result shortest sequence from {0} to {1} is:", startNumber, searchedNumber);
        FunctionsCollection.PrintIntList(shortestSequence);
    }

    private static List<int> GenerateShortestSequence(int startNumber, int searchedNumber)
    {
        Queue<LinkedNode> generatedSequence = new Queue<LinkedNode>();

        generatedSequence.Enqueue(new LinkedNode(startNumber, null));
        LinkedNode resultNode = null;
        while (true)
        {
            LinkedNode currentItem = generatedSequence.Dequeue();

            int nextValue = currentItem.Value + 1;
            resultNode = new LinkedNode(nextValue, currentItem);
            generatedSequence.Enqueue(resultNode);
            if (nextValue == searchedNumber)
            {
                break;
            }

            nextValue = currentItem.Value + 2;
            resultNode = new LinkedNode(nextValue, currentItem);
            generatedSequence.Enqueue(resultNode);
            if (nextValue == searchedNumber)
            {
                break;
            }

            nextValue = currentItem.Value * 2;
            resultNode = new LinkedNode(nextValue, currentItem);
            generatedSequence.Enqueue(resultNode);
            if (nextValue == searchedNumber)
            {
                break;
            }
        }

        List<int> resultSequence = new List<int>();

        LinkedNode previousNode = resultNode;
        while (previousNode != null)
        {
            resultSequence.Add(previousNode.Value);
            previousNode = previousNode.Previous;
        }

        resultSequence.Reverse();

        return resultSequence;
    }
}
