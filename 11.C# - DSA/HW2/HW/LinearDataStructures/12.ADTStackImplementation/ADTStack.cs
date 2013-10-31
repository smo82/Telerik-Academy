using System;
using System.Collections.Generic;

public class ADTStack<T> : IEnumerable<T>
{
    private const int INITIAL_DATA_SIZE = 64;
    private T[] data;
    
    public ADTStack()
        : this(INITIAL_DATA_SIZE)
    {
    }

    public ADTStack(int dataSize)
    {
        if (dataSize < 0)
        {
            throw new InvalidOperationException(
                string.Format("The data size cannot be smaller then zero! : {0}", dataSize));
        }

        this.data = new T[dataSize];
        this.Count = 0;
    }

    public int Count { get; private set; }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this.data[i];
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Push(T element)
    {
        this.ManageDataSize();
        this.data[this.Count] = element;
        this.Count++;
    }

    public T Peek()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack empty!");
        }

        return this.data[this.Count - 1];
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack empty!");
        }

        T currentElement = this.data[this.Count - 1];
        this.data[this.Count - 1] = default(T);

        this.Count--;
        return currentElement;
    }

    private void ManageDataSize()
    {
        if (this.Count == this.data.Length) 
        {
            T[] newData = new T[this.data.Length * 2];
            this.data.CopyTo(newData, 0);
            this.data = newData;
        }
    }
}