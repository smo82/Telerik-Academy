using System;

public class ListItem<T> : IEquatable<ListItem<T>>
{ 
    public ListItem(T value)
        : this(value, null)
    {
    }

    public ListItem(T value, ListItem<T> next)
    {
        this.Value = value;
        this.NextItem = next;
    }

    public T Value { get; private set; }

    public ListItem<T> NextItem { get; set; }

    public bool Equals(ListItem<T> that)
    {
        if (that == null)
        {
            throw new ArgumentNullException("Entered object is null");
        }

        if (this.Value.Equals(that.Value))
        {
            return true;
        }

        return false;
    }
}
