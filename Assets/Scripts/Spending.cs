using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spending : MonoBehaviour
{
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private TMP_Text ValueText;
    [SerializeField] private Button CancelButton;
    [SerializeField] private TMP_Text CancelButtonText;

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

    public void Initialize(string name, int value, string description = null, bool togglable = true)
    {
        _name = name;
        NameText.text = _name;
        InitialValue = value;
        ValueText.text = "-" + InitialValue.ToString();
        Description = description;
        if (!togglable)
            CancelButton.gameObject.SetActive(false);
        Activate();
    }

    public void Activate(bool skipOnToggle = false)
    {
        SetActive(true, skipOnToggle);
    }

    public void Deactivate(bool skipOnToggle = false)
    {
        SetActive(false, skipOnToggle);
    }

    public void Toggle()
    {
        if (Active)
            Deactivate();
        else
            Activate();
    }

    public void Toggle(bool skipOnToggle)
    {
        if (Active)
            Deactivate(skipOnToggle);
        else
            Activate(skipOnToggle);
    }

    public void Spend()
    {
        OnSpend?.Invoke();
    }

    private void SetActive(bool activeness, bool skipOnToggle = false)
    {
        CancelButtonText.text = activeness ? "-" : "+";
        NameText.color = activeness ? ActiveColor : InactiveColor;
        ValueText.color = NameText.color;
        Active = activeness;
        if (!skipOnToggle)
            OnToggle?.Invoke(activeness);
    }
}
