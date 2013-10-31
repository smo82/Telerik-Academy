using System;
using System.Collections.Generic;

public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
{
    const int INITIAL_CAPACITY = 16;
    private LinkedList<KeyValuePair<K, T>>[] values;

    public HashTable(int capacity)
    {
        this.values = new LinkedList<KeyValuePair<K, T>>[capacity];
    }

    public HashTable()
        : this(INITIAL_CAPACITY)
    {
    }

    public int Capacity
    {
        get
        {
            return this.values.Length;
        }
    }

    public int Count
    {
        get
        {
            int count = 0;
            foreach (LinkedList<KeyValuePair<K, T>> item in this.values)
            {
                if (item != null)
                {
                    foreach (KeyValuePair<K, T> node in item)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }

    public List<K> Keys
    {
        get
        {
            List<K> keys = new List<K>();
            foreach (LinkedList<KeyValuePair<K, T>> item in this.values)
            {
                if (item != null)
                {
                    foreach (KeyValuePair<K, T> node in item)
                    {
                        keys.Add(node.Key);
                    }
                }
            }

            return keys;
        }
    }

    public T this[int index]
    {
        get
        {
            int currentIndex = 0;
            foreach (LinkedList<KeyValuePair<K, T>> item in this.values)
            {
                if (item != null)
                {
                    foreach (KeyValuePair<K, T> node in item)
                    {
                        if (currentIndex == index)
                        {
                            return node.Value;
                        }
                        currentIndex++;
                    }
                }
            }

            throw new IndexOutOfRangeException("Invalid index: " + index);
        }
        set
        {
            int currentIndex = 0;
            foreach (LinkedList<KeyValuePair<K, T>> item in this.values)
            {
                if (item != null)
                {
                    foreach (KeyValuePair<K, T> node in item)
                    {
                        if (currentIndex == index)
                        {
                            item.Find(node).Value = new KeyValuePair<K, T>(node.Key, value);
                        }
                        currentIndex++;
                    }
                }
            }
        }
    }

    public void Add(K key, T value)
    {
        int keyCurrentIndex = GetKeyIndex(key);

        if (this.values[keyCurrentIndex] == null)
        {
            this.values[keyCurrentIndex] = new LinkedList<KeyValuePair<K, T>>();
        }

        this.values[keyCurrentIndex].AddLast(new KeyValuePair<K, T>(key, value));

        Resize();
    }

    public T Find(K key)
    {
        int keyCurrentIndex = GetKeyIndex(key);
        LinkedList<KeyValuePair<K, T>> currentItems = this.values[keyCurrentIndex];

        if (currentItems != null)
        {
            foreach (KeyValuePair<K, T> node in currentItems)
            {
                if (node.Key.Equals(key))
                {
                    return node.Value;
                }
            }
        }

        throw new InvalidOperationException("Unknown key: " + key.ToString() + "!");
    }

    public void Remove(K key)
    {
        int keyCurrentIndex = GetKeyIndex(key);
        LinkedList<KeyValuePair<K, T>> currentItems = this.values[keyCurrentIndex];

        List<KeyValuePair<K, T>> nodesToRemove = new List<KeyValuePair<K, T>>();
        foreach (KeyValuePair<K, T> node in currentItems)
        {
            if (node.Key.Equals(key))
            {
                nodesToRemove.Add(node);
            }
        }

        foreach (KeyValuePair<K, T> node in nodesToRemove)
        {
            currentItems.Remove(node);
        }

        if (currentItems.Count == 0)
        {
            this.values[keyCurrentIndex] = null;
        }
    }

    private void Resize()
    {
        if (this.Count > this.Capacity * 0.75)
        {
            LinkedList<KeyValuePair<K, T>>[] oldValues = this.values;
            this.values = new LinkedList<KeyValuePair<K, T>>[Capacity * 2];

            foreach (LinkedList<KeyValuePair<K, T>> currentItem in oldValues)
            {
                if (currentItem != null)
                {
                    foreach (KeyValuePair<K, T> node in currentItem)
                    {
                        T valueCurrent = node.Value;
                        K keyCurrent = node.Key;
                        int keyCurrentIndex = GetKeyIndex(keyCurrent);

                        if (this.values[keyCurrentIndex] == null)
                        {
                            this.values[keyCurrentIndex] = new LinkedList<KeyValuePair<K, T>>();
                        }

                        this.values[keyCurrentIndex].AddLast(new KeyValuePair<K, T>(keyCurrent, valueCurrent));
                    }
                }
            }
        }
    }

    private int GetKeyIndex(K key)
    {
        int keyHashcode = key.GetHashCode();
        int keyCurrentIndex = keyHashcode % this.Capacity;
        return keyCurrentIndex;
    }

    public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
    {
        foreach (LinkedList<KeyValuePair<K, T>> item in this.values)
        {
            if (item != null)
            {
                foreach (KeyValuePair<K, T> node in item)
                {
                    yield return node;
                }
            }
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}