using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionary<TKey1, TKey2, TValue> : Dictionary<System.Tuple<TKey1, TKey2>, TValue>, IDictionary<System.Tuple<TKey1, TKey2>, TValue>
{

    public TValue this[TKey1 key1, TKey2 key2]
    {
        get { return base[System.Tuple.Create(key1, key2)]; }
        set { base[System.Tuple.Create(key1, key2)] = value; }
    }

    public void Add(TKey1 key1, TKey2 key2, TValue value)
    {
        base.Add(System.Tuple.Create(key1, key2), value);
    }

    public bool ContainsKey(TKey1 key1, TKey2 key2)
    {
        return base.ContainsKey(System.Tuple.Create(key1, key2));
    }

    public bool Remove(TKey1 key1, TKey2 key2)
    {
        return base.Remove(System.Tuple.Create(key1, key2));
    }

}

