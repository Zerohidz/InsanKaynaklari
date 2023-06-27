using System;
using UnityEngine;

public class DayController : SingletonMB<DayController>
{
    private static int FreeIncorrectDecisions = 2;

    public bool DayEndingButNotYetEnded { get; private set; }

    [SerializeField] private Transform _cvParent;
    [SerializeField] private ShowCRButton _showCRButton;
    [SerializeField] private InfoPanel _infoPanel;
    [SerializeField] private ESCPanel _escPanel;
    [SerializeField] private DayEndScreen _dayEndScreen;
    [SerializeField] private CV[] _cvPrefabs;
    [SerializeField] private CR[] _crPrefabs;
    private CV _cv;
    private int _day;
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

    public override void Reset()
    {
        Start();
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
                Debug.Log("Do�ru karar!");
            }
            else
            {
                _incorrectDecisionCount++;
                Debug.Log("Yanl�� karar!");
            }
        }
        else
        {
            _cv.Reject();
            _cv = null;

            if (PersonManger.Instance.CurrentPersonInfo.IsCorrect)
            {
                _incorrectDecisionCount++;
                Debug.Log("Yanl�� karar!");
            }
            else
            {
                _correctDecisionCount++;
                Debug.Log("Do�ru karar!");
            }
        }

        if (DayEndingButNotYetEnded)
            EndDay();
    }

    public void EndDay()
    {
        if (_cv != null)
        {
            DayEndingButNotYetEnded = true;
            return;
        }

        // TODO: if (Son g�n)

        int netDecisionCount = _correctDecisionCount - Math.Clamp(_incorrectDecisionCount - FreeIncorrectDecisions, 0, _incorrectDecisionCount);
        _dayEndScreen.SetInfo(MoneySystem.Instance.Money, netDecisionCount);
        _dayEndScreen.SetVisible(true);

        Debug.Log("G�n bitti aga!");
        SaveSystem.SaveCareerData(GameController.Instance.Day, MoneySystem.Instance.Money);
    }
}