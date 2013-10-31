using System;
using System.Collections.Generic;

public class Solution
{
    public Solution(Product product)
    {
        this.Products = new List<Product>() { product };
        this.Value = product.Value;
        this.Weight = product.Weight;
    }

    public Solution(Solution previousSolution)
    {
        this.Products = new List<Product>();
        this.Products.AddRange(previousSolution.Products);
        this.Value = previousSolution.Value;
        this.Weight = previousSolution.Weight;
    }

    public int Weight { get; set; }

    public int Value { get; set; }

    public List<Product> Products { get; set; }

    public void AddProduct(Product product)
    {
        this.Products.Add(product);
        this.Weight += product.Weight;
        this.Value += product.Value;
    }
}