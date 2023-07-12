#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class GeneralMenu
{
    [MenuItem("General/Play From MainMenu")]
    public static void PlayFromMainMenu()
    {
        if (EditorApplication.isPlaying == true)
            return;

        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        EditorApplication.isPlaying = true;
    }
}

#endif