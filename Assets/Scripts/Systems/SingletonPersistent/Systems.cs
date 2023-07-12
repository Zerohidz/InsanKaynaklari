using System;
using UnityEngine;

public class Systems : PersistentSingletonMB<Systems>
{
    public static System.Random Random = new System.Random(GetEpochTime());

    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        Instantiate(Resources.Load("Systems"));
    }

    public override void Reset()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            var singleton = child.GetComponent<ISingleton>();
            singleton?.Reset();
        }
    }

    private static int GetEpochTime()
    {
        DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int currentEpochTime = (int)(DateTime.UtcNow - epochStart).TotalSeconds;

        return currentEpochTime;
    }
}
