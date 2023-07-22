using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PositionSwithcer), typeof(Button))]
public class ShowCRButton : MonoBehaviour
{
    [SerializeField] private Transform _crPosition;
    public bool IsShowing { get; private set; } 

    private PositionSwithcer _positionSwitcher;
    private Button _button;
    private CR _cr;

    private void Awake()
    {
        _positionSwitcher = GetComponent<PositionSwithcer>();
        _button = GetComponent<Button>();
        IsShowing = _positionSwitcher.InDestination;
    }

    public void SetCR(CR cr)
    {
        _cr = Instantiate(cr, _crPosition.transform);
        _cr.SetInfo(CompanyRequestManager.Instance.CurrentCompanyRequest);
        _positionSwitcher.Child = _cr.transform;
    }

    public void Click()
    {
        _button.onClick?.Invoke();
    }

    public void Toggle()
    {
        _positionSwitcher.Switch();
        IsShowing = !IsShowing;
    }

    public void Hide()
    {
        if (IsShowing)
            Click();
    }
}
