using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UIFader : MonoBehaviour
{
    public bool StartVisible = false;
    public bool ToggleOnStart = false;
    public bool TerminateOnFade = false;
    public float Duration = 1;
    public int OnStartDelaySeconds = 0;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        SetVisible(StartVisible);

        if (ToggleOnStart)
            StartCoroutine(ToggleAfterDelay(OnStartDelaySeconds));
    }

    public void SetVisible(bool willBeVisible)
    {
        StartVisible = willBeVisible;
        _canvasGroup.alpha = StartVisible ? 1 : 0;
    }

    public void ToggleFade()
    {
        Fade(!StartVisible);
    }

    public void ToggleFade(Action endAction)
    {
        Fade(!StartVisible, endAction);
    }

    public void Fade(bool willBeVisible, Action endAction = null)
    {
        if (StartVisible)
        {
            if (!willBeVisible)
                StartCoroutine(FadeToZeroAlpha(Duration, endAction: endAction));
        }
        else
            StartCoroutine(FadeToFullAlpha(Duration, endAction: endAction));
    }

    public IEnumerator FadeToFullAlpha(float duration, Action tickAction = null, Action endAction = null)
    {
        while (_canvasGroup.alpha < 1.0f)
        {
            _canvasGroup.alpha += Time.deltaTime / duration;
            tickAction?.Invoke();
            yield return null;
        }
        StartVisible = true;
        endAction?.Invoke();
        if (TerminateOnFade) Destroy(gameObject);
    }

    public IEnumerator FadeToZeroAlpha(float duration, Action tickAction = null, Action endAction = null)
    {
        while (_canvasGroup.alpha > 0f)
        {
            _canvasGroup.alpha -= Time.deltaTime / duration;
            tickAction?.Invoke();
            yield return null;
        }
        StartVisible = false;
        endAction?.Invoke();
        if (TerminateOnFade) Destroy(gameObject);
    }

    private IEnumerator ToggleAfterDelay(float t)
    {
        yield return new WaitForSeconds(t);
        ToggleFade();
    }
}
