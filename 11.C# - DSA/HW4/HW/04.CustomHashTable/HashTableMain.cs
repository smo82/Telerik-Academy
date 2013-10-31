/*
 * Task04
 * 
 * Implement the data structure "hash table" in a class HashTable<K,T>. 
 * Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) with initial capacity of 16. 
 * When the hash table load runs over 75%, perform resizing to 2 times larger capacity. 
 * Implement the following methods and properties: Add(key, value), Find(key)value, Remove( key), Count, Clear(), this[], Keys. 
 * Try to make the hash table to support iterating over its elements with foreach.
 */
using System;
using System.Collections.Generic;

class HashTableMain
{
    static void Main(string[] args)
    {
        HashTable<int, int> testHashTable = new HashTable<int, int>(2);

        Console.WriteLine("Current HashTable count: {0}", testHashTable.Count);
        Console.WriteLine("Current HashTable capacity: {0}", testHashTable.Capacity);

        testHashTable.Add(1, 2);
        testHashTable.Add(2, 2);

        Console.WriteLine(new String('*', 30));
        Console.WriteLine("Current hashtable content:");
        PrintHashTable(testHashTable);

        Console.WriteLine(new String('*', 30));
        Console.WriteLine("Current HashTable count: {0}", testHashTable.Count);
        Console.WriteLine("Current HashTable capacity: {0}", testHashTable.Capacity);
        
        testHashTable.Add(4, 2);
        testHashTable.Add(3, 7);
        testHashTable.Add(9, 8);

        Console.WriteLine(new String('*', 30));
        Console.WriteLine("Current hashtable content:");
        PrintHashTable(testHashTable);

        Console.WriteLine(new String('*', 30));
        Console.WriteLine("Current HashTable count: {0}", testHashTable.Count);
        Console.WriteLine("Current HashTable capacity: {0}", testHashTable.Capacity);

        testHashTable.Remove(2);
        Console.WriteLine(new String('*', 30));
        Console.WriteLine("Print after remove the item with key = 2:");
        PrintHashTable(testHashTable);

        Console.WriteLine(new String('*', 30));
        Console.WriteLine("Print by index:");
        PrintHashTableByIndex(testHashTable);

        testHashTable[3] = 17;

        Console.WriteLine(new String('*', 30));
        Console.WriteLine("Print after change the value at index 3:");
        PrintHashTableByIndex(testHashTable);
    }

    private static void PrintHashTableByIndex(HashTable<int, int> testHashTable)
    {
        for (int i = 0; i < testHashTable.Count; i++)
        {
            Console.WriteLine("{0, 4} : {1}", i, testHashTable[i]);
        }
    }

    private static void PrintHashTable(HashTable<int, int> testHashTable)
    {
        foreach (KeyValuePair<int, int> keyPair in testHashTable)
        {
            Console.WriteLine("{0, 4} : {1}", keyPair.Key, keyPair.Value);
        }
    }
}