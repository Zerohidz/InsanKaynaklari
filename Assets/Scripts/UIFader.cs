using System.Collections;
using System.Collections.Generic;
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

    public IEnumerator FadeToFullAlpha(float t)
    {
        while (_canvasGroup.alpha < 1.0f)
        {
            _canvasGroup.alpha += Time.deltaTime / t;
            yield return null;
        }
        IsVisible = true;
    }

    public IEnumerator FadeToZeroAlpha(float t)
    {
        while (_canvasGroup.alpha > 0f)
        {
            _canvasGroup.alpha -= Time.deltaTime / t;
            yield return null;
        }
        IsVisible = false;
    }
}
