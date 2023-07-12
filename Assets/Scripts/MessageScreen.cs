using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageScreen : MonoBehaviour
{
    [Header("Parameters")]
    public TMP_Text Text;
    public bool FadeInOnStart = true;
    public float FadeDuration = 1;

    [Header("Faders")]
    public UIFader ContentFader;
    public UIFader BackgroundFader;

    [Header("Buttons")]
    [SerializeField] private Button _button;

    public string Message { get; private set; }
    public event Action OnContinueButtonPressed;

    private void Awake()
    {
        _button.onClick.AddListener(() => OnContinueButtonPressed?.Invoke());
    }

    private void Start()
    {
        ContentFader.ToggleOnStart = FadeInOnStart;
        BackgroundFader.ToggleOnStart = FadeInOnStart;

        ContentFader.Duration = FadeDuration;
        BackgroundFader.Duration = FadeDuration;

        ContentFader.OnStartDelaySeconds = FadeDuration;
    }

    public void Initialize(string message, float fadeDuration = 1, bool fadeInOnStart = true)
    {
        Message = message;
        Text.text = Message;
        FadeDuration = fadeDuration;
        FadeInOnStart = fadeInOnStart;
    }

    public void FadeOut(Action endAction = null)
    {
        FadeContent(false, () =>
        {
            FadeBackground(false, endAction);
        });
    }

    public void FadeContent(bool willBeVisible, Action endAction = null)
    {
        ContentFader.Fade(willBeVisible, endAction);
    }

    public void FadeBackground(bool willBeVisible, Action endAction = null)
    {
        BackgroundFader.Fade(willBeVisible, endAction);
    }
}
