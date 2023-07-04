using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spending : MonoBehaviour
{
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private TMP_Text ValueText;
    [SerializeField] private Button CancelButton;

    public event Action OnSpend;
    public event ToggleEvent OnToggle;
    public delegate void ToggleEvent(bool activeness);

    public Color ActiveColor;
    public Color InactiveColor;

    public bool Active = true;
    public int InitialValue = 0;

    private string _name;
    private string _description;
    public string Description
    {
        get => _description;
        private set
        {
            if (value == null)
                return;
            _description = value;
            NameText.text = $"{_name} ({_description})";
        }
    }

    public int Cost => Active ? InitialValue : 0;

    public void Initialize(string name, int value, string description = null)
    {
        _name = name;
        NameText.text = _name;
        InitialValue = value;
        Description = description;
        Activate();
    }

    public void Activate()
    {
        ValueText.text = "-" + InitialValue.ToString();
        NameText.color = ActiveColor;
        ValueText.color = ActiveColor;
        Active = true;
        OnToggle?.Invoke(true);
    }

    public void Deactivate()
    {
        ValueText.text = "0";
        NameText.color = InactiveColor;
        ValueText.color = InactiveColor;
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

    public void Spend()
    {
        OnSpend?.Invoke();
    }
}
