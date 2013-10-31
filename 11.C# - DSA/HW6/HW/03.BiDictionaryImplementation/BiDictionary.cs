using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class BiDictionary<K1, K2, V>
    where K1 : IComparable<K1>
    where K2 : IComparable<K2>
{
    private OrderedMultiDictionary<K1, V> valuesByKey1;
    private OrderedMultiDictionary<K2, V> valuesByKey2;
    private OrderedMultiDictionary<BiDictionaryKeyElement<K1, K2>, V> valuesByBothKeys;

    public BiDictionary()
    {
        this.valuesByKey1 = new OrderedMultiDictionary<K1, V>(true);
        this.valuesByKey2 = new OrderedMultiDictionary<K2, V>(true);
        this.valuesByBothKeys = new OrderedMultiDictionary<BiDictionaryKeyElement<K1, K2>, V>(true);
    }

    public void Add(K1 key1, K2 key2, V value)
    {
        this.valuesByKey1.Add(key1, value);
        this.valuesByKey2.Add(key2, value);
        
        BiDictionaryKeyElement<K1, K2> keyElement = new BiDictionaryKeyElement<K1, K2>(key1, key2);
        this.valuesByBothKeys.Add(keyElement, value);
    }

    public ICollection<V> GetByKey1(K1 key1)
    {
        return this.valuesByKey1[key1];
    }

    public ICollection<V> GetByKey2(K2 key2)
    {
        return this.valuesByKey2[key2];
    }

    public ICollection<V> GetByBothKeys(K1 key1, K2 key2)
    {
        BiDictionaryKeyElement<K1, K2> keyElement = new BiDictionaryKeyElement<K1, K2>(key1, key2);
        return this.valuesByBothKeys[keyElement];
    }
}
