using System;
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

    protected override void Awake()
    {
        base.Awake();
        if (IsBeingDestroyed) return;

        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        UpdateCanvasScaling();
        Debug.Log("Update canvas scaling");
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

    public void UpdateCanvasScaling()
    {
        float screenRatio = Screen.width / (float)Screen.height;
        float targetRatio = 16f / 9f;

        var canvasScaler = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasScaler>();
        if (canvasScaler != null)
            canvasScaler.matchWidthOrHeight = screenRatio > targetRatio ? 1f : 0f;
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
