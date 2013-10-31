using System;
using System.Diagnostics;
using System.Linq;
using Wintellect.PowerCollections;

public class FindSubrangeMain
{
    public static void Main(string[] args)
    {
        OrderedBag<Product> productsInvetory = new OrderedBag<Product>();
        Random random = new Random();

        for (int i = 0; i < 500000; i++)
        {
            Product product = new Product("product" + i, random.Next(-i, i));
            productsInvetory.Add(product);
        }

        Console.WriteLine("Start");
        Stopwatch watch = new Stopwatch();
        watch.Start();

        for (int i = 0; i < 20000; i++)
        {
            int startRange = random.Next(-i, i);
            int endRange = random.Next(startRange, i);
            Product[] currentSearch = FindFirst20ProductsInRange(productsInvetory, startRange, endRange);
        }

        watch.Stop();
        Console.WriteLine(watch.Elapsed);
    }

    private static Product[] FindFirst20ProductsInRange(OrderedBag<Product> productsInvetory, int startRange, int endRange)
    {
        Product startRangeProduct = new Product(string.Empty, startRange);
        Product endRangeProduct = new Product(string.Empty, endRange);
        Product[] currentSearch = productsInvetory.Range(startRangeProduct, true, endRangeProduct, true).Take(20).ToArray();

        return currentSearch;
    }
}