/*
 * Task05
 * 
 * Shopping center
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

class ShoppingCenterMain
{
    static StringBuilder output;

    static void Main(string[] args)
    {
        int numberOfCommands = int.Parse(Console.ReadLine());

        ShoppingCenter shoppingCenter = new ShoppingCenter();
        output = new StringBuilder();

        for (int i = 0; i < numberOfCommands; i++)
        {
            string commandLine = Console.ReadLine();

            int indexFirstInterval = commandLine.IndexOf(' ');
            string command = commandLine.Substring(0, indexFirstInterval);
            string commandParametersString = commandLine.Substring(indexFirstInterval + 1);

            string[] commandParameters = commandParametersString.Split(new char[] { ';' });

            switch (command)
            {
                case "AddProduct":
                    shoppingCenter.Add(commandParameters[0], decimal.Parse(commandParameters[1]), commandParameters[2]);
                    output.AppendLine("Product added");
                    break;
                case "FindProductsByName":
                    Product[] findByNameResult = shoppingCenter.FindProductByName(commandParameters[0]);
                    Array.Sort(findByNameResult);
                    PrintProductArray(findByNameResult);
                    break;
                case "FindProductsByPriceRange":
                    Product[] findByPriceResult = 
                        shoppingCenter.FindProductByPriceRange(decimal.Parse(commandParameters[0]), decimal.Parse(commandParameters[1]));
                    Array.Sort(findByPriceResult);
                    PrintProductArray(findByPriceResult);
                    break;
                case "FindProductsByProducer":
                    Product[] findByProducerResult = shoppingCenter.FindProductByProducer(commandParameters[0]);
                    Array.Sort(findByProducerResult);
                    PrintProductArray(findByProducerResult);
                    break;
                case "DeleteProducts":
                    int deletedProducts ;
                    if(commandParameters.Length == 2)
                    {
                        deletedProducts = shoppingCenter.DeleteProduct(commandParameters[0], commandParameters[1]);
                    }
                    else
                    {
                        deletedProducts = shoppingCenter.DeleteProduct(commandParameters[0]);
                    }

                    if (deletedProducts == 0)
                    {
                        output.AppendLine("No products found");
                    }
                    else
                    {
                        output.AppendLine(deletedProducts + " products deleted");
                    }
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine(output.ToString().Trim());
    }

    private static void PrintProductArray(Product[] productArray)
    {
        if (productArray.Length == 0)
        {
            output.AppendLine("No products found");
        }

        StringBuilder printResult = new StringBuilder();
        foreach (Product product in productArray)
        {
            output.AppendLine("{" + product.ToString() + "}");
        }
    }
}

public class Product : IComparable<Product>
{
    public Product(string name, decimal price, string producer)
    {
        this.Name = name;
        this.Price = price;
        this.Producer = producer;
    }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Producer { get; set; }

    public override string ToString()
    {
        return string.Format("{0};{1};{2:F}", this.Name, this.Producer, this.Price);
    }

    public int CompareTo(Product other)
    {
        int compareByName = this.Name.CompareTo(other.Name);
        if (compareByName != 0)
        {
            return compareByName;
        }

        int compareByProducer = this.Producer.CompareTo(other.Producer);
        if (compareByProducer != 0)
        {
            return compareByProducer;
        }

        return this.Price.CompareTo(other.Price);
    }
}

public class ShoppingCenter
{
    public ShoppingCenter()
    {
        this.ProductsByName = new MultiDictionary<string, Product>(true);
        this.ProductsByProducer = new MultiDictionary<string, Product>(true);
        this.ProductsByNameAndProducer = new MultiDictionary<string, Product>(true);
        this.ProductByPrice = new OrderedMultiDictionary<decimal, Product>(true);
    }

    public MultiDictionary<string, Product> ProductsByName { get; private set; }

    public MultiDictionary<string, Product> ProductsByProducer { get; private set; }

    public MultiDictionary<string, Product> ProductsByNameAndProducer { get; private set; }

    public OrderedMultiDictionary<decimal, Product> ProductByPrice { get; private set; }

    public Product[] FindProductByPriceRange(decimal startPrice, decimal endPrice)
    {
        return this.ProductByPrice.Range(startPrice, true, endPrice, true).Values.ToArray();
    }

    public Product[] FindProductByProducer(string producer)
    {
        return this.ProductsByProducer[producer].ToArray();
    }

    public Product[] FindProductByName(string name)
    {
        return this.ProductsByName[name].ToArray();
    }

    public int DeleteProduct(string producer)
    {
        ICollection<Product> productByProducer = this.ProductsByProducer[producer];

        int resultCount = productByProducer.Count;

        if (resultCount == 0)
        {
            return 0;
        }

        foreach (Product product in productByProducer)
        {
            this.ProductsByName.Remove(product.Name, product);
            this.ProductsByNameAndProducer.Remove(product.Name + "-" + producer, product);
            this.ProductByPrice.Remove(product.Price, product);
        }

        this.ProductsByProducer.Remove(producer);

        return resultCount;
    }

    public int DeleteProduct(string name, string producer)
    {
        ICollection<Product> productByNameAndProducer = this.ProductsByNameAndProducer[name + "-" + producer];

        int resultCount = productByNameAndProducer.Count;

        if (resultCount == 0)
        {
            return 0;
        }

        foreach (Product product in productByNameAndProducer)
        {
            this.ProductsByName.Remove(name, product);
            this.ProductsByProducer.Remove(producer, product);
            this.ProductByPrice.Remove(product.Price, product);
        }

        this.ProductsByNameAndProducer.Remove(name + "-" + producer);

        return resultCount;
    }

    public void Add(string name, decimal price, string producer)
    {
        Product newProduct = new Product(name, price, producer);
        
        this.ProductsByName.Add(name, newProduct);
        this.ProductsByProducer.Add(producer, newProduct);
        this.ProductsByNameAndProducer.Add(name + "-" + producer, newProduct);
        this.ProductByPrice.Add(price, newProduct);
    }
}