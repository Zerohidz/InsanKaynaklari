using System;
using UnityEngine;
using UnityEngine.UI;

public class Systems : PersistentSingletonMB<Systems>
{
    public static System.Random Random = new System.Random(GetEpochTime());

    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        Application.targetFrameRate = 144;
        Instantiate(Resources.Load("Systems"));
    }

    //private static void SetScreenRatio()
    //{
    //    int currentRatio = Screen.width / Screen.height;
    //    if ((16f / 10f) <= currentRatio && currentRatio <= (16f / 9f))
    //        return;

    //    int targetWidth = Screen.height * 16 / 9;
    //    Screen.SetResolution(targetWidth, Screen.height, true);
    //}

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
