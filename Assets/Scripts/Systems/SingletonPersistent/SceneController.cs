using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : SingletonMB<SceneController>
{


    public override void Reset()
    {

    }

    public void LoadSceneWithTransition(string sceneName, float transitionSpeed)
    {
        DarkenTheScreen(transitionSpeed, () =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }

    private static void DarkenTheScreen(float transitionSpeed, Action endAction)
    {
        var o = new GameObject("a");
        UIFader fader = o.AddComponent<UIFader>();
        fader.IsVisible = false;
        fader.Speed = transitionSpeed;
        fader.SetVisible(true, endAction);
    }
}
