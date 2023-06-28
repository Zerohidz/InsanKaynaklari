using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageScreen : MonoBehaviour
{
    public TMP_Text _text;

    private void Start()
    {
        _text.text = DatabaseManager.Instance.DayEndMessages[GameController.Instance.Day];
    }

    public void OnContinueButtonPressed()
    {
        GameController.Instance.StartNewDay();
    }
}
