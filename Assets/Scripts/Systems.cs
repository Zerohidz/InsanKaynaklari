using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Systems : PersistentSingletonMB<Systems>
{
    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        Instantiate(Resources.Load("Systems"));
    }

    [RuntimeInitializeOnLoadMethod]
    private static void SetRandomSeed()
    {
        DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int currentEpochTime = (int)(DateTime.UtcNow - epochStart).TotalSeconds;
        UnityEngine.Random.InitState(currentEpochTime);
    }
}
