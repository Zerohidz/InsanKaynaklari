using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PositionSwithcer))]
public class ShowCRButton : MonoBehaviour
{
    [SerializeField] private Transform _crPosition;
    public bool IsShowing { get; private set; } 

    private PositionSwithcer _positionSwitcher;
    private CR _cr;

    private void Awake()
    {
        _positionSwitcher = GetComponent<PositionSwithcer>();
        IsShowing = _positionSwitcher.InDestination;
    }

    public void SetCR(CR cr)
    {
        _cr = Instantiate(cr, _crPosition.transform);
        _cr.SetInfo(CompanyRequestManager.Instance.CurrentCompanyRequest);
        _positionSwitcher.Child = _cr.transform;
    }

    public void Press()
    {
        _positionSwitcher.Switch();
        IsShowing = !IsShowing;
    }

    public void Hide()
    {
        if (IsShowing)
            Press();
    }
}
