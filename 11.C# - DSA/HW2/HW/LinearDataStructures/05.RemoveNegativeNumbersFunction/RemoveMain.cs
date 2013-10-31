/*
 * Task05
 * 
 * Write a program that removes from given sequence all negative numbers.
 */

using System;
using System.Collections.Generic;

public class RemoveMain
{
    public static void Main(string[] args)
    {
        LinkedList<int> numbers = FunctionsCollection.ReadIntLinkedListUptoEmptyLine();
        numbers = RemoveNegativeMembers(numbers);
        Console.WriteLine("The sequence without its negative members is:");
        FunctionsCollection.PrintIntLinkedList(numbers);
    }

    private static LinkedList<int> RemoveNegativeMembers(LinkedList<int> numbers)
    {
        LinkedListNode<int> node = numbers.First;

        while (node != null)
        {
            LinkedListNode<int> next = node.Next;
            if (node.Value < 0)
            {
                numbers.Remove(node);
            }

            node = next;
        }

        return numbers;
    }
}