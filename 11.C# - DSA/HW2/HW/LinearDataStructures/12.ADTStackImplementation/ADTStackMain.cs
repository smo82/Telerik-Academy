/*
 * Task12
 * 
 * Implement the ADT stack as auto-resizable array. 
 * Resize the capacity on demand (when no space is available to add / insert a new element).
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ADTStackMain
{
    // Tests
    public static void Main(string[] args)
    {
        ADTStack<int> testStack = new ADTStack<int>(2);

        Debug.Assert(testStack.Count == 0, "The stack count is not 0!"); 

        Console.WriteLine("Fill the stack with integers.");
        Console.WriteLine("Please enter more then 2 values to force it to resize.");
        Console.WriteLine(new string('-', 30));

        List<int> userData = FunctionsCollection.ReadIntListInRangeUptoEmptyLine();

        for (int i = 0; i < userData.Count; i++)
        {
            testStack.Push(userData[i]);
        }

        Debug.Assert(testStack.Count == userData.Count, "The stack count is not equal to the number of values entered!");
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("The stack count is: {0}", testStack.Count);

        Console.WriteLine(new string('-', 30));
        try
        {
            Console.WriteLine("Read last element by Peek(): {0}", testStack.Peek());
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("The stack is empty so Peek() throws an InvalidOperationException!");
        }

        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Read the stack by using Pop():");

        for (int i = testStack.Count - 1; i >= 0; i--)
        {
            Console.WriteLine("{0} : {1}", i, testStack.Pop());
        }

        Debug.Assert(testStack.Count == 0, "The stack count is not 0!");
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("The stack count is: {0}", testStack.Count);
    }
}