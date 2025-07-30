using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Serialization<TKey, TValue> : ISerializationCallbackReceiver
{
    [SerializeField]
    private List<TKey> keys = new List<TKey>();

    [SerializeField]
    private List<TValue> values = new List<TValue>();

    private Dictionary<TKey, TValue> target;

    public Dictionary<TKey, TValue> ToDictionary()
    {
        return target;
    }

    public Serialization(Dictionary<TKey, TValue> dict)
    {
        target = dict;
    }

    public Serialization(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
        target = new Dictionary<TKey, TValue>();
        for (int i = 0; i < Math.Min(keys.Count, values.Count); i++)
        {
            target[keys[i]] = values[i];
        }
    }

    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();

        if (target == null) return;

        foreach (var pair in target)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        target = new Dictionary<TKey, TValue>();

        for (int i = 0; i < Math.Min(keys.Count, values.Count); i++)
        {
            target[keys[i]] = values[i];
        }
    }
}