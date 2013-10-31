/*
 * Task13
 * 
 * Implement the ADT queue as dynamic linked list. 
 * Use generics (LinkedQueue<T>) to allow storing different data types in the queue.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ADTQueueMain
{
    public static void Main(string[] args)
    {
        ADTQueue<int> testQueue = new ADTQueue<int>();

        Debug.Assert(testQueue.Count == 0, "The queue count is not 0!");

        Console.WriteLine("Fill the queue with integers!");
        Console.WriteLine(new string('-', 30));

        List<int> userData = FunctionsCollection.ReadIntListInRangeUptoEmptyLine();

        for (int i = 0; i < userData.Count; i++)
        {
            testQueue.Enqueue(userData[i]);
        }

        Debug.Assert(testQueue.Count == userData.Count, "The queue count is not equal to the number of values entered!");
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("The queue count is: {0}", testQueue.Count);

        Console.WriteLine(new string('-', 30));
        try
        {
            Console.WriteLine("Read first item by Peak(): {0}", testQueue.Peek());
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("The queue is empty so Peek() throws an InvalidOperationException!");
        }

        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Read the queue by using Dequeue():");
        for (int i = testQueue.Count - 1; i >= 0; i--)
        {
            Console.WriteLine("{0} : {1}", i, testQueue.Dequeue());
        }

        Debug.Assert(testQueue.Count == 0, "The queue count is not 0!");
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("The queue count is: {0}", testQueue.Count);
    }
}