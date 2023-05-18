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
}
