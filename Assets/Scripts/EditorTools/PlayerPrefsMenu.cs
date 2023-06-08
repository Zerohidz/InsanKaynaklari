using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerPrefsMenu : MonoBehaviour
{
    [MenuItem("Player Prefs/Delete All")]
    public static void DeleteAll()
    {
        SaveSystem.GameData = null;
        PlayerPrefs.DeleteAll();
    }

    [MenuItem("Player Prefs/Delete Game Data")]
    public static void DeleteGameData()
    {
        SaveSystem.GameData = null;
        PlayerPrefs.DeleteKey("GameData");
    }
}