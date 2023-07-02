using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : SingletonMB<SceneController>
{
    [SerializeField] private UIFader _transitionFaderPrefab;
    public float TransitionDuration = 2;

    public override void Reset()
    {

    }

    private void Start()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        Fade(false, TransitionDuration, terminateOnFade: true);
    }

    public void LoadSceneWithTransition(string sceneName, float? transitionDuration = null)
    {
        float duration = transitionDuration ?? TransitionDuration;

        var loadOperation = SceneManager.LoadSceneAsync(sceneName);
        loadOperation.allowSceneActivation = false;
        Fade(true, duration, endAction: () =>
        {
            loadOperation.allowSceneActivation = true;
        });
    }

    private void Fade(bool willGetVisible, float transitionDuration, bool terminateOnFade = false, Action endAction = null)
    {
        UIFader fader = Instantiate(_transitionFaderPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);
        fader.TerminateOnFade = terminateOnFade;
        fader.Duration = transitionDuration;
        fader.SetVisible(!willGetVisible);
        fader.Fade(willGetVisible, endAction);
    }
}
