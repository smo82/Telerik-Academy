/*
 * Task05
 * 
 * Implement the data structure "set" in a class HashedSet<T> using your class HashTable<K,T> to hold the elements. 
 * Implement all standard set operations like Add(T), Find(T), Remove(T), Count, Clear(), union and intersect.
 */

using System;

class HashSetMain
{
    static void Main(string[] args)
    {
        HashedSet<int> testHashSet = new HashedSet<int>(2);

        Console.WriteLine("Current HashSet count: {0}", testHashSet.Count);

        testHashSet.Add(1);
        testHashSet.Add(2);
        testHashSet.Add(2);
        testHashSet.Add(2);
        testHashSet.Add(3);
        testHashSet.Add(4);
        testHashSet.Add(5);
        testHashSet.Add(6);

        Console.WriteLine(new String('*', 30));
        Console.WriteLine("Current HashSet content:");
        PrintHashSet(testHashSet);

        Console.WriteLine(new String('*', 30));
        Console.WriteLine("Current HashSet count: {0}", testHashSet.Count);

        Console.WriteLine(new String('*', 30));
        Console.WriteLine("Check if value 1 exist in the HashSet: {0}", testHashSet.Find(1));

        Console.WriteLine(new String('*', 30));
        Console.WriteLine("Check if value 11 exist in the HashSet: {0}", testHashSet.Find(11));

        testHashSet.Remove(5);
        Console.WriteLine(new String('*', 30));
        Console.WriteLine("HashSet content after removing 5:");
        PrintHashSet(testHashSet);

        HashedSet<int> testHashSet2 = new HashedSet<int>(2);
        testHashSet2.Add(1);
        testHashSet2.Add(2);
        testHashSet2.Add(12);

        HashedSet<int> testHashSetUnion = testHashSet.Union(testHashSet2);
        Console.WriteLine(new String('*', 30));
        Console.WriteLine("HashSet union with HashSet [1, 2, 12]:");
        PrintHashSet(testHashSetUnion);

        HashedSet<int> testHashSetIntersection = testHashSet.Intersection(testHashSet2);
        Console.WriteLine(new String('*', 30));
        Console.WriteLine("HashSet intersection with HashSet [1, 2, 12]:");
        PrintHashSet(testHashSetIntersection);
    }

    private static void PrintHashSet(HashedSet<int> hashSet)
    {
        foreach (int item in hashSet)
        {
            Console.WriteLine(item);
        }
    }
}
