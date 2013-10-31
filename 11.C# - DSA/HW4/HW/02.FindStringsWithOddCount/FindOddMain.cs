/*
 * Task02
 * 
 * Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. 
 * Example:
 * {C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL}
 */

using System;
using System.Collections.Generic;

class FindOddMain
{
    static void Main(string[] args)
    {
        List<string> stringCollection = FunctionCollection.ReadStringListUptoEmptyLine();

        Dictionary<string, int> stringsCount = FunctionCollection.CountValues<string>(stringCollection);

        Console.Clear();
        Console.WriteLine("The strings that are present an odd number of times are:");

        foreach (KeyValuePair<string,int> stringKayPair in stringsCount)
        {
            if (stringKayPair.Value % 2 != 0)
            {
                Console.WriteLine("{0, 2} : {1}", stringKayPair.Value, stringKayPair.Key);
            }
        }
    }
}