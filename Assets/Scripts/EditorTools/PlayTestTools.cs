using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class PlayTestMenu
{
    [MenuItem("PlayTest/End The Day")]
    public static void EndTheDay()
    {
        DayController.Instance.ForceEndTheDay();
    }
}
