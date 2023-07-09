using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystemMenu
{
    [MenuItem("Save System/Delete Game Data")]
    public static void DeleteGameData()
    {
        SaveSystem.DeleteGameData();
    }
}