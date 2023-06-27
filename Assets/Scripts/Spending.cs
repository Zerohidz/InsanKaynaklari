using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spending : MonoBehaviour
{
    public event ToggleEvent OnToggle;
    public delegate void ToggleEvent(bool activeness);

    public TMP_Text _nameText;
    public TMP_Text _valueText;
    public Button _cancelButton;
    public bool Active = true;
    public int InitialValue;

    public Color ActiveColor;
    public Color InactiveColor;

    /// <summary>
    /// Returns InitialValue if enabled, 0 otherwise.
    /// </summary>
    public int Cost => Active ? InitialValue : 0;

    public void Initialize(string name, int value)
    {
        _nameText.text = name;
        InitialValue = value;
        Activate();
    }

    public void Activate()
    {
        _valueText.text = "-" + InitialValue.ToString();
        _nameText.color = ActiveColor;
        _valueText.color = ActiveColor;
        Active = true;
        OnToggle?.Invoke(true);
    }

    public void Deactivate()
    {
        _valueText.text = "0";
        _nameText.color = InactiveColor;
        _valueText.color = InactiveColor;
        Active = false;
        OnToggle?.Invoke(false);
    }

    public void Toggle()
    {
        if (Active)
            Deactivate();
        else
            Activate();
    }
}
