/*
 * Task02
 * 
 * Write a program that reads N integers from the console and reverses them using a stack. 
 * Use the Stack<int> class.
 */

using System;
using System.Collections.Generic;

public class ReverseIntCollection
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter the numbers count (N):");
        int numbersCount = FunctionsCollection.ReadIntInRange(1);

        Stack<int> numbersStack = ReadIntStack(numbersCount);

        Console.WriteLine("The reversed numbers collection is:");
        PrintIntStack(numbersCount, numbersStack);
    }

    private static void PrintIntStack(int numbersCount, Stack<int> numbersStack)
    {
        for (int i = 0; i < numbersCount; i++)
        {
            Console.Write("{0} ", numbersStack.Pop());
        }
    }

    private static Stack<int> ReadIntStack(int numbersCount)
    {
        Stack<int> numbersStack = new Stack<int>();
        for (int i = 0; i < numbersCount; i++)
        {
            Console.WriteLine("Enter the next number:");
            int currentNumber = FunctionsCollection.ReadIntInRange();
            numbersStack.Push(currentNumber);
        }

        return numbersStack;
    }
}
