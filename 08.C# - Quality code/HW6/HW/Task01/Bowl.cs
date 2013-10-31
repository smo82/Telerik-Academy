using System;
using System.Collections.Generic;

public class Bowl
{
    public List<Vegetable> Content { get; set; }

    public Bowl()
    {
    }

    public void Add(Vegetable vegetable)
    {
        Content.Add(vegetable);
    }
}