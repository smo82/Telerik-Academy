using System;
using System.Collections.Generic;

public class HashedSet <T> : IEnumerable<T>
{
    const int INITIAL_CAPACITY = 16;
    private HashTable<T, bool> values;

    public HashedSet(int capacity)
    {
        this.values = new HashTable<T, bool>(capacity);
    }

    public HashedSet()
        : this(INITIAL_CAPACITY)
    {
    }

    public int Count
    {
        get
        {
            return this.values.Count;
        }
    }

    public void Clear()
    {
        this.values = new HashTable<T, bool>(this.values.Count);
    }

    public void Add(T value)
    {
        try
        {
            this.values.Find(value);
        }
        catch (InvalidOperationException)
        {
            this.values.Add(value, true);
        }
    }

    public bool Find(T value)
    {
        try
        {
            this.values.Find(value);
        }
        catch (InvalidOperationException)
        {
            return false;
        }

        return true;
    }

    public void Remove(T value)
    {
        this.values.Remove(value);
    }

    public HashedSet<T> Union(HashedSet<T> other)
    {
        HashedSet<T> result = new HashedSet<T>();

        foreach (T item in this)
        {
            result.Add(item);
        }

        foreach (T item in other)
        {
            if (!result.Find(item))
            {
                result.Add(item);
            }
        }

        return result;
    }

    public HashedSet<T> Intersection(HashedSet<T> other)
    {
        HashedSet<T> result = new HashedSet<T>();
        
        foreach (T item in this)
        {
            if (other.Find(item))
            {
                result.Add(item);
            }
        }

        return result;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (KeyValuePair<T, bool> item in this.values)
        {
            yield return item.Key;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}