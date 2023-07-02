using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UIFader : MonoBehaviour
{
    public bool IsVisible = true;
    public float Duration = 1;
    public bool ToggleOnStart = false;
    public int OnStartDelaySeconds = 0;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        SetVisible(IsVisible);

        if (ToggleOnStart)
            StartCoroutine(ToggleAfterDelay(OnStartDelaySeconds));
    }

    public void SetVisible(bool willBeVisible)
    {
        IsVisible = willBeVisible;
        _canvasGroup.alpha = IsVisible ? 1 : 0;
    }

    public void ToggleFade()
    {
        Fade(!IsVisible);
    }

    public void ToggleFade(Action endAction)
    {
        Fade(!IsVisible, endAction);
    }

    public void Fade(bool willBeVisible, Action endAction = null)
    {
        if (IsVisible)
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
        IsVisible = true;
        endAction?.Invoke();
    }

    public IEnumerator FadeToZeroAlpha(float duration, Action tickAction = null, Action endAction = null)
    {
        while (_canvasGroup.alpha > 0f)
        {
            _canvasGroup.alpha -= Time.deltaTime / duration;
            tickAction?.Invoke();
            yield return null;
        }
        IsVisible = false;
        endAction?.Invoke();
    }

    private IEnumerator ToggleAfterDelay(float t)
    {
        yield return new WaitForSeconds(t);
        ToggleFade();
    }
}
