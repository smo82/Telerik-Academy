using System;

public class BinaryHeapNode<T> where T : IComparable<T>
{
    public BinaryHeapNode(BinaryHeapNode<T> parent, T value)
    {
        this.Value = value;
        this.Parent = parent;
    }

    public T Value { get; private set; }

    public BinaryHeapNode<T> Parent { get; set; }

    public BinaryHeapNode<T> LeftChild { get; set; }

    public BinaryHeapNode<T> RightChild { get; set; }

    public int CompareTo(BinaryHeapNode<T> that)
    {
        return this.Value.CompareTo(that.Value);
    }
}