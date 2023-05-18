using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumHelper
{
    public static IEnumerable<T> GetValues<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }

    public static T GetRandom<T>() where T : Enum
    {
        var values = GetValues<T>().ToArray();
        return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
    }

    public static T[] GetRandomArray<T>(int count) where T : Enum
    {
        List<T> values = GetValues<T>().ToList();
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
}
