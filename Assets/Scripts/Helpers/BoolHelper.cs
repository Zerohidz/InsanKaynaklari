using System;

public static class BoolHelper
{
    public static bool GetRandom()
    {
        return UnityEngine.Random.Range(0f, 1f) < 0.5f;
    }

    public static T GetRandomOneFrom<T>(params T[] values)
    {
        return values[UnityEngine.Random.Range(0, values.Length)];
    }

    /// <returns>Random float between [0f, 1f]. Both ends inclusive.</returns>
    public static float GetRandomFloat()
    {
        return UnityEngine.Random.Range(0, 1f);
    }

    public static bool GetRandomFromPersentage(float persentage)
    {
        return GetRandomFloat() * 100 < persentage;
    }
}
