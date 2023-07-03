using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageScreen : MonoBehaviour
{
    public TMP_Text _text;

    public float _fadeDuration = 1;

    [SerializeField] private UIFader _backgroundFader;
    [SerializeField] private UIFader _parentFader;

    private void Start()
    {
        _text.text = DatabaseManager.Instance.DayEndMessages[GameController.Instance.Day];
        _backgroundFader.Duration = _fadeDuration;
        _parentFader.Duration = _fadeDuration;
        _backgroundFader.Fade(true);
        _parentFader.FadeAfter(_fadeDuration, true);
    }

    public void OnContinueButtonPressed()
    {
        _parentFader.Fade(false, endAction: () =>
        {
            DayController.Instance.ShowSpendingScreen();
        });
    }
}
