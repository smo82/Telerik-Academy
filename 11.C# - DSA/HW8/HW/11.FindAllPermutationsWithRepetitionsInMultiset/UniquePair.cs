using System;

public class UniquePair : IComparable<UniquePair>
{
    public UniquePair(int index, string value)
    {
        this.Index = index;
        this.Value = value;
        this.ValueAsInt = int.Parse(value);
    }

    public int Index { get; private set; }

    public string Value { get; private set; }

    public int ValueAsInt { get; private set; }

    public int CompareTo(UniquePair other)
    {
        return this.ValueAsInt - other.ValueAsInt;
    }
}