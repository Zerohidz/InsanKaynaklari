using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : SingletonMB<DayController>
{
    [SerializeField] private Transform _cvParent;
    [SerializeField] private ShowCRButton _showCRButton;
    [SerializeField] private InfoPanel _infoPanel;
    [SerializeField] private ESCPanel _escPanel;
    [SerializeField] private CV[] _cvPrefabs;
    [SerializeField] private CR[] _crPrefabs;
    private CV _cv;
    private int _day;
    private int _earnedMoney;
    private int _correctDecisionCount;
    private int _incorrectDecisionCount;

    private void Start()
    {
        _day = GameController.Instance.Day;
        _showCRButton.SetCR(_crPrefabs[_day < 3 ? 0 : 1]);

        GetNewCV();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            EndDay();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _escPanel.ToggleShow();
        }
    }

    public void GetNewCV()
    {
        if (_cv != null)
            return;

        PersonManger.Instance.NextPerson();
        _cv = Instantiate(_cvPrefabs[0], _cvParent);
        _cv.SetInfo(PersonManger.Instance.CurrentPersonInfo);
    }

    public void DecideCorrectness(bool accepted)
    {
        if (_cv == null)
            return;

        if (accepted)
        {
            _cv.Accept();
            _cv = null;

            if (PersonManger.Instance.CurrentPersonInfo.IsCorrect)
            {
                _correctDecisionCount++;
                _earnedMoney += 5;
                Debug.Log("Doðru karar!");
            }
            else
            {
                _incorrectDecisionCount++;
                if (_incorrectDecisionCount > 2)
                    _earnedMoney -= 5;
                Debug.Log("Yanlýþ karar!");
            }
        }
        else
        {
            _cv.Reject();
            _cv = null;

            if (PersonManger.Instance.CurrentPersonInfo.IsCorrect)
            {
                _incorrectDecisionCount++;
                if (_incorrectDecisionCount > 2)
                    _earnedMoney -= 5;
                Debug.Log("Yanlýþ karar!");
            }
            else
            {
                _correctDecisionCount++;
                _earnedMoney += 5;
                Debug.Log("Doðru karar!");
            }
        }
    }

    public void EndDay()
    {
        // TODO: implement
        MoneySystem.Instance.EarnMoney(_earnedMoney);
        _earnedMoney = 0;
        Debug.Log("Gün bitti aga!");
        GameController.Instance.StartNewDay();
        GameController.Instance.SaveCareerData();
    }
}
