using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SaveSystemMenu : MonoBehaviour
{
    [MenuItem("Save System/Delete Game Data")]
    public static void DeleteGameData()
    {
        SaveSystem.Initialize();
        SaveSystem.DeleteGameData();
    }
}