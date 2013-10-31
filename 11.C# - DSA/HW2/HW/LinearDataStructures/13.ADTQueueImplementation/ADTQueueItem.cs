using System;

public class ADTQueueItem<T>
{
    public ADTQueueItem(T value)
        : this(value, null)
    {
    }

    public ADTQueueItem(T value, ADTQueueItem<T> next)
    {
        this.Value = value;
        this.Next = next;
    }

    public T Value { get; private set; }

    public ADTQueueItem<T> Next { get; set; }
}