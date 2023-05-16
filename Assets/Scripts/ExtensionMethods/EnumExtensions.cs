using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

public static class EnumExtensions
{
    public static T GetRandom<T>()
    {
        var values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
    }

    public static T[] GetRandomArray<T>(int count) where T : Enum
    {
        List<T> values = Enum.GetValues(typeof(T)).Cast<T>().ToList();
        if (count < 1)
            count = 1;
        else if (count > values.Count)
            count = values.Count;

        int countToRemove = values.Count - count;
        for (int i = 0; i < countToRemove; i++)
        {
            values.RemoveAt(UnityEngine.Random.Range(0, values.Count - 1));
        }

        return values.ToArray();
    }
}
