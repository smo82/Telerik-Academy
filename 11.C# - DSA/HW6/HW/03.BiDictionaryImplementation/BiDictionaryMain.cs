using System;
using System.Collections.Generic;
using System.Linq;

public class BiDictionaryMain
{
    public static void Main(string[] args)
    {
        BiDictionary<int, string, decimal> biDictionary = FillBiDictionary();

        decimal[] searchByKey1 = biDictionary.GetByKey1(5).Take(20).ToArray<decimal>();

        Console.WriteLine("Values searched by key1:");
        PrintValuesCollection(searchByKey1);

        decimal[] searchByKey2 = biDictionary.GetByKey2("key2:" + 13).Take(20).ToArray<decimal>();

        Console.WriteLine(new string('*', 20));
        Console.WriteLine("Values searched by key2:");
        PrintValuesCollection(searchByKey2);

        decimal[] searchByBothKeys = biDictionary.GetByBothKeys(5, "key2:" + 13).Take(20).ToArray<decimal>();

        Console.WriteLine(new string('*', 20));
        Console.WriteLine("Values searched by both keys:");
        PrintValuesCollection(searchByBothKeys);
    }

    private static void PrintValuesCollection(ICollection<decimal> valuesCollection)
    {
        foreach (decimal value in valuesCollection)
        {
            Console.WriteLine(value);
        }
    }

    private static BiDictionary<int, string, decimal> FillBiDictionary()
    {
        BiDictionary<int, string, decimal> biDictionary = new BiDictionary<int, string, decimal>();
        Random random = new Random();

        for (int i = 0; i < 10000; i++)
        {
            biDictionary.Add(random.Next(0, 10), "key2:" + random.Next(11, 20), random.Next(0, 100000));
        }

        return biDictionary;
    }
}
