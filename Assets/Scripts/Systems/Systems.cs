using System;
using UnityEngine;

public class Systems : PersistentSingletonMB<Systems>
{
    public static System.Random Random = new System.Random(GetEpochTime());

    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        Application.targetFrameRate = 144;
        SetScreenRatio();
        Instantiate(Resources.Load("Systems"));
    }

    private static void SetScreenRatio()
    {
        int targetHeight = Screen.width * 9 / 16;
        Screen.SetResolution(Screen.width, targetHeight, true);
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
