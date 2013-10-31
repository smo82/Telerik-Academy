﻿using System;

public class Product
{
    public Product(string name, int weight, int cost)
    {
        this.Name = name;
        this.Weight = weight;
        this.Cost = cost;
    }

    public string Name { get; private set; }

    public int Weight { get; private set; }

    public int Cost { get; private set; }

    public int Value
    {
        get
        {
            // Here we can implement different ways to calculate the value - only by cost or for example: by cost and by usefulness
            return this.Cost;
        }
    }

    public override string ToString()
    {
        return string.Format("{0} - weight={1}, cost={2}", this.Name, this.Weight, this.Cost);
    }
}