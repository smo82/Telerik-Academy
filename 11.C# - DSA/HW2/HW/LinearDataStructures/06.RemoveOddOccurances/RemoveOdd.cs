/*
 * Task06
 * 
 * Write a program that removes from given sequence all numbers that occur odd number of times. Example:
 * {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}
 */

using System;
using System.Collections.Generic;

public class RemoveOdd
{
    public static void Main(string[] args)
    {
        LinkedList<int> numbers = FunctionsCollection.ReadIntLinkedListUptoEmptyLine();
        numbers = RemoveOddOccuringNumbers(numbers);
        Console.WriteLine("The sequence without the members that occur odd number of times is:");
        FunctionsCollection.PrintIntLinkedList(numbers);
    }

    private static LinkedList<int> RemoveOddOccuringNumbers(LinkedList<int> numbers)
    {
        Dictionary<int, int> occurances = FunctionsCollection.GetNumbersCount(numbers);

        LinkedListNode<int> node = numbers.First;

        while (node != null)
        {
            LinkedListNode<int> next = node.Next;
            if (occurances[node.Value] % 2 != 0)
            {
                numbers.Remove(node);
            }

            node = next;
        }

        return numbers;
    }
}
