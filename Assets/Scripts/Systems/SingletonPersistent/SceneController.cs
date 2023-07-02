using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : SingletonMB<SceneController>
{
    [SerializeField] private UIFader _transitionFaderPrefab;

    public override void Reset()
    {

    }

    public void LoadSceneWithTransition(string sceneName, float transitionDuration)
    {
        DarkenTheScreen(transitionDuration, () =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }

    private void DarkenTheScreen(float transitionDuration, Action endAction)
    {
        UIFader fader = Instantiate(_transitionFaderPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);
        fader.SetVisible(false);
        fader.Duration = transitionDuration;
        fader.ToggleOnStart = true;
        fader.Fade(true, endAction);
    }
}
