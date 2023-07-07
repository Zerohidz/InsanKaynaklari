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

    public static ICollection<T> GetRandomRange<T>(int count) where T : Enum
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

    public static T GetClamped<T>(T value) where T : Enum
    {
        var underlyingType = Enum.GetUnderlyingType(typeof(T));
        var minValue = Convert.ChangeType(Enum.GetValues(typeof(T)).GetValue(0), underlyingType);
        var maxValue = Convert.ChangeType(Enum.GetValues(typeof(T)).GetValue(Enum.GetValues(typeof(T)).Length - 1), underlyingType);

        return (T)Enum.ToObject(typeof(T), Math.Clamp(Convert.ToInt64(value), Convert.ToInt64(minValue), Convert.ToInt64(maxValue)));
    }

}
