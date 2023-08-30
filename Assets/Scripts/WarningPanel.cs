using System;
using TMPro;
using UnityEngine;

public class WarningPanel : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float _fadeDuration = 5.0f;
    [SerializeField] private float _moveAmount = 20.0f;
    [SerializeField] private Color _goodWarningColor;
    [SerializeField] private Color _badWarningColor;

    [Header("References")]
    [SerializeField] private UIFader _textFader;

    private TMP_Text _text;
    private string _currentMessage;

    private void Awake()
    {
        _text = _textFader.GetComponent<TMP_Text>();
        _text.transform.Translate(0, -_moveAmount, 0);
    }

    public void ShowWarning(string message, bool isGoodWarning)
    {
        void Show()
        {
            SetMessage(message);
            _text.color = isGoodWarning ? _goodWarningColor : _badWarningColor;
            StartCoroutine(_textFader.FadeToFullAlphaC(
                _fadeDuration,
                tickAction: () => _text.transform.Translate(0, Time.deltaTime * _moveAmount / _fadeDuration, 0)
            ));
        };

        StopAllCoroutines();
        if (_currentMessage != null)
        {
            StartCoroutine(_textFader.FadeToZeroAlphaC(
                _fadeDuration,
                tickAction: () => _text.transform.Translate(0, Time.deltaTime * -_moveAmount / _fadeDuration, 0),
                endAction: Show)
            );
        }
        else
        {
            Show();
        }
    }

    private void SetMessage(string message)
    {
        _currentMessage = message;
        _text.text = message;
    }
}
