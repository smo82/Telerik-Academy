using System;

public class PriorityQueue<T> where T : IComparable<T>
{
    private BinaryHeap<T> queue;

    public PriorityQueue()
    {
        this.queue = new BinaryHeap<T>();
    }

    public BinaryHeap<T> Queue
    {
        get
        {
            return this.queue;
        }
    }

    public int Count
    {
        get
        {
            return this.queue.Count;
        }
    }

    public void Enqueue(T element)
    {
        this.queue.Insert(element);
    }

    public T Dequeue()
    {
        try
        {
            T element = this.queue.Delete();
            return element;
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("Priority Queue Empty");
        }
    }
}