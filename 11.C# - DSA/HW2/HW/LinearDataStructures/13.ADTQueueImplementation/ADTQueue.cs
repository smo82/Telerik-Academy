using System;
using System.Collections.Generic;

public class ADTQueue<T> : IEnumerable<T>
{
    public ADTQueue()
    {
        this.FirstElement = null;
        this.LastElement = null;
    }

    public ADTQueueItem<T> FirstElement { get; private set; }

    public ADTQueueItem<T> LastElement { get; private set; }

    public int Count { get; private set; }

    public IEnumerator<T> GetEnumerator()
    {
        ADTQueueItem<T> node = this.FirstElement;
        while (node != null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Clear()
    {
        this.FirstElement = null;
        this.LastElement = null;
    }

    public void Enqueue(T value)
    {
        ADTQueueItem<T> newItem = new ADTQueueItem<T>(value);
        if (this.LastElement == null)
        {
            this.FirstElement = newItem;
            this.LastElement = newItem;
        }
        else
        {
            this.LastElement.Next = newItem;
            this.LastElement = newItem;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        if (this.FirstElement == null)
        {
            throw new InvalidOperationException("The queue is empty!");
        }

        T firstValue = this.FirstElement.Value;

        this.FirstElement = this.FirstElement.Next;
        if (this.FirstElement == null)
        {
            this.LastElement = null;
        }

        this.Count--;
        return firstValue;
    }

    public T Peek()
    {
        if (this.FirstElement == null)
        {
            throw new InvalidOperationException("The queue is empty!");
        }

        return this.FirstElement.Value;
    }
}