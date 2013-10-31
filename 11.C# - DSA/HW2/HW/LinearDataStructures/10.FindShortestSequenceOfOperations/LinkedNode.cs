using System;

public class LinkedNode
{
    public LinkedNode(int value, LinkedNode previous)
    {
        this.Value = value;
        this.Previous = previous;
    }

    public int Value { get; private set; }

    public LinkedNode Previous { get; private set; }
}
