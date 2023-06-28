using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UIFader : MonoBehaviour
{
    public bool IsVisible = true;
    public float Speed = 1;
    public bool ToggleOnStart = false;
    public int OnStartDelaySeconds = 0;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = IsVisible ? 1 : 0;

        if (ToggleOnStart)
            StartCoroutine(ToggleAfterDelay(OnStartDelaySeconds));
    }

    public void ToggleVisbility()
    {
        SetVisible(!IsVisible);
    }

    public void ToggleVisibility(Action endAction)
    {
        SetVisible(!IsVisible, endAction);
    }

    public void SetVisible(bool willBeVisible, Action endAction = null)
    {
        if (IsVisible)
        {
            if (!willBeVisible)
                StartCoroutine(FadeToZeroAlpha(Speed, endAction: endAction));
        }
        else
            StartCoroutine(FadeToFullAlpha(Speed, endAction: endAction));
    }

    public IEnumerator FadeToFullAlpha(float speed, Action tickAction = null, Action endAction = null)
    {
        while (_canvasGroup.alpha < 1.0f)
        {
            _canvasGroup.alpha += Time.deltaTime * speed;
            tickAction?.Invoke();
            yield return null;
        }
        IsVisible = true;
        endAction?.Invoke();
    }

    public IEnumerator FadeToZeroAlpha(float speed, Action tickAction = null, Action endAction = null)
    {
        while (_canvasGroup.alpha > 0f)
        {
            _canvasGroup.alpha -= Time.deltaTime * speed;
            tickAction?.Invoke();
            yield return null;
        }
        IsVisible = false;
        endAction?.Invoke();
    }

    private IEnumerator ToggleAfterDelay(float t)
    {
        yield return new WaitForSeconds(t);
        ToggleVisbility();
    }
}
