using System;

public class BiDictionaryKeyElement<K1, K2> : IComparable<BiDictionaryKeyElement<K1, K2>>
    where K1 : IComparable<K1> 
    where K2 : IComparable<K2>
{
    public BiDictionaryKeyElement(K1 key1, K2 key2)
    {
        this.Kay1 = key1;
        this.Kay2 = key2;
    }

    public K1 Kay1 { get; private set; }

    public K2 Kay2 { get; private set; }

    public int CompareTo(BiDictionaryKeyElement<K1, K2> other)
    {
        int compareByKay1 = this.Kay1.CompareTo(other.Kay1);

        if (compareByKay1 != 0)
        {
            return compareByKay1;
        }

        return this.Kay2.CompareTo(other.Kay2);
    }
}
