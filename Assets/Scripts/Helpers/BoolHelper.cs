public static class BoolHelper
{
    public static bool GetRandomBool()
    {
        return UnityEngine.Random.Range(0f, 1f) < 0.5f;
    }

    public static T GetRandomOneFrom<T>(T first, T second)
    {
        return GetRandomBool() ? first : second;
    }
}
