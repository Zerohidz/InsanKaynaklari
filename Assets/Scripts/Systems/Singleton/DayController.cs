using System;
using UnityEngine;

public class DayController : SingletonMB<DayController>
{
    private static int FreeIncorrectDecisions = 2;

    public bool DayEndingButNotYetEnded { get; private set; }

    [Header("References")]
    [SerializeField] private Transform _cvParent;
    [SerializeField] private ShowCRButton _showCRButton;
    [SerializeField] private InfoPanel _infoPanel;
    [SerializeField] private ESCPanel _escPanel;
    [SerializeField] private WarningPanel _warningPanel;

    [Header("Prefabs")]
    [SerializeField] private MessageScreen _messageScreenPrefab;
    [SerializeField] private SpendingScreen _spendingScreenPrefab;
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
        _showCRButton.Press();
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
            _showCRButton.Hide();
        }
        else
        {
            _cv.Reject();
            _showCRButton.Hide();
        }
        _cv = null;

        if (accepted == PersonManger.Instance.CurrentPersonInfo.IsCorrect)
        {
            _correctDecisionCount++;
            _warningPanel.ShowWarning("Doðru Karar", true);
        }
        else
        {
            _incorrectDecisionCount++;
            _warningPanel.ShowWarning("Yanlýþ Karar\n" + (_incorrectDecisionCount <= 2 ? "(Ceza yok)" : "(Ceza -5 dolar)"), false);
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

        // TODO: if (Son gün)

        Debug.Log("Gün bitti aga!");

        ShowMessageScreen();
    }

    private void ShowMessageScreen()
    {
        Instantiate(_messageScreenPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);
    }

    public void ShowSpendingScreen()
    {
        SpendingScreen spendingScreen = Instantiate(_spendingScreenPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);
        int netDecisionCount = _correctDecisionCount - Math.Clamp(_incorrectDecisionCount - FreeIncorrectDecisions, 0, _incorrectDecisionCount);
        spendingScreen.SetInfo(MoneySystem.Instance.Money, netDecisionCount);
        spendingScreen.SetVisible(true);
    }
}
