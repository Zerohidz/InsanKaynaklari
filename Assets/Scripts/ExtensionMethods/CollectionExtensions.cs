using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CollectionExtensions
{
    public static T GetRandom<T>(this ICollection<T> collection)
    {
        int randomIdx = UnityEngine.Random.Range(0, collection.Count);
        return collection.ElementAt(randomIdx);
    }

    /// <summary>
    /// If there is not sufficient amount of items, returns maximum amount
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static ICollection<T> GetRandomRange<T>(this ICollection<T> collection, int count)
    {
        List<T> values = collection.ToList();
        List<T> array = new();
        count = Math.Clamp(count, 1, values.Count);

        for (int i = 0; i < count; i++)
        {
            int randomIdx = UnityEngine.Random.Range(0, values.Count);
            array.Add(values[randomIdx]);
            values.RemoveAt(randomIdx);
        }

        return array.ToArray();
    }

    public static ICollection<T> Shuffled<T>(this ICollection<T> collection)
    {
        var list = collection.ToList();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

        return list;
    }
}
