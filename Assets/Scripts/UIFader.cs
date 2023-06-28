using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UIFader : MonoBehaviour
{
    public bool IsVisible { get; set; } = true;
    public float Speed = 1;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ToggleVisbility()
    {
        SetVisible(!IsVisible);
    }

    public void SetVisible(bool willBeVisible)
    {
        if (IsVisible)
        {
            if (!willBeVisible)
                StartCoroutine(FadeToZeroAlpha(Speed));
        }
        else
            StartCoroutine(FadeToFullAlpha(Speed));   
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
}
