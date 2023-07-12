using System;

public static class BoolHelper
{
    public static bool GetRandom()
    {
        return Systems.Random.NextDouble() < 0.5f;
    }

    public static T GetRandomOneFrom<T>(params T[] values)
    {
        return values[Systems.Random.Next(0, values.Length)];
    }

    /// <returns>Random float between [0f, 1f]. Both ends inclusive.</returns>
    public static float GetRandomFloat()
    {
        return (float)Systems.Random.NextDouble();
    }

    public static bool GetRandomFromPersentage(float persentage)
    {
        return GetRandomFloat() * 100 < persentage;
    }
}
