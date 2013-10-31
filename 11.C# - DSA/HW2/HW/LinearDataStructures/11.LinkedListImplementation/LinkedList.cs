using System;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>, ICollection<T>
{
    public ListItem<T> FirstElement { get; private set; }

    public int Count { get; private set; }

    public bool IsReadOnly
    {
        get { return false; }
    }

    public IEnumerator<T> GetEnumerator()
    {
        ListItem<T> node = this.FirstElement;
        while (node != null)
        {
            yield return node.Value;
            node = node.NextItem;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Add(T item)
    {
        this.AddLast(item);
    }

    public void AddFirst(T item)
    {
        ListItem<T> newItem = new ListItem<T>(item, this.FirstElement);
        this.FirstElement = newItem;
        this.Count++;
    }

    public void AddLast(T item)
    {
        this.Count++;

        ListItem<T> newItem = new ListItem<T>(item);

        ListItem<T> node = this.FirstElement;

        if (node == null)
        {
            this.FirstElement = newItem;
            return;
        }

        while (node.NextItem != null)
        {
            node = node.NextItem;
        }

        node.NextItem = newItem;
    }
    
    public ListItem<T> AddAfter(ListItem<T> node, T item)
    {
        if (node == null)
        {
            throw new ArgumentNullException("The node cannot be null!");
        }

        if (!this.ContainsNode(node))
        {
            throw new InvalidOperationException("Unknown node!");
        }
        
        ListItem<T> nextNode = node.NextItem;
        ListItem<T> newItem = new ListItem<T>(item, nextNode);
        node.NextItem = newItem;

        this.Count++;
        return newItem;
    }
    
    public ListItem<T> AddBefore(ListItem<T> node, T item)
    {
        if (node == null)
        {
            throw new ArgumentNullException("The node cannot be null!");
        }
                
        ListItem<T> newItem = new ListItem<T>(item, node);

        ListItem<T> previousNode = this.FindPreviousNode(node);
        if (previousNode == null)
        {
            this.FirstElement = newItem;
        }
        else
        {
            previousNode.NextItem = newItem;
        }

        this.Count++;
        return newItem;
    }

    public void Clear()
    {
        this.FirstElement = null;
        this.Count = 0;
    }

    public bool Contains(T item)
    {
        foreach (T element in this)
        {
            if (element.Equals(item))
            {
                return true;
            }
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentNullException("Null array reference");
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException("Index is out of range");
        }

        if (array.Rank > 1)
        {
            throw new ArgumentException("Array is multi-dimensional");
        }

        foreach (T item in this)
        {
            array.SetValue(item, arrayIndex);
            arrayIndex++;
        }
    }

    public bool Remove(T item)
    {
        if (this.FirstElement == null)
        {
            return false;
        }

        if (item.Equals(this.FirstElement.Value))
        {
            ListItem<T> nextItem = this.FirstElement.NextItem;
            this.FirstElement = nextItem;
            this.Count--;
            return true;
        }

        ListItem<T> previousItem = this.FirstElement;
        ListItem<T> currentItem = previousItem.NextItem;
        while (currentItem != null)
        {
            if (currentItem.Value.Equals(item))
            {
                ListItem<T> nextItem = currentItem.NextItem;
                previousItem.NextItem = nextItem;
                this.Count--;
                return true;
            }

            previousItem = currentItem;
            currentItem = currentItem.NextItem;
        }

        return false;
    }

    public bool RemoveFirst()
    {
        if (this.FirstElement == null)
        {
            return false;
        }

        this.FirstElement = this.FirstElement.NextItem;
        this.Count--;
        return true;
    }

    public bool RemoveLast()
    {
        if (this.FirstElement == null)
        {
            return false;
        }

        ListItem<T> last = this.Last();
        ListItem<T> previousLast = this.FindPreviousNode(last);
        if (previousLast != null)
        {
            previousLast.NextItem = null;
            this.Count--;
            return true;
        }
        else
        {
            return false;
        }
    }

    public ListItem<T> First()
    {
        return this.FirstElement;
    }

    public ListItem<T> Last()
    {
        ListItem<T> node = this.FirstElement;
        ListItem<T> previous = null;
        while (node != null)
        {
            previous = node;
            node = node.NextItem;
        }

        return previous;
    }

    private ListItem<T> FindPreviousNode(ListItem<T> node)
    {
        if (node == null)
        {
            throw new ArgumentNullException("The node cannot be null!");
        }

        ListItem<T> currentNode = this.FirstElement;
        ListItem<T> previousNode = null;

        while (currentNode != node && currentNode.NextItem != null)
        {
            previousNode = currentNode;
            currentNode = currentNode.NextItem;
        }

        if (currentNode != node)
        {
            throw new InvalidOperationException("Unknown node!");
        }

        return previousNode;
    }

    private bool ContainsNode(ListItem<T> node)
    {
        ListItem<T> currentNode = this.FirstElement;

        while (currentNode != node && currentNode.NextItem != null)
        {
            currentNode = currentNode.NextItem;
        }

        if (currentNode != node)
        {
            return false;
        }

        return true;
    }
}
