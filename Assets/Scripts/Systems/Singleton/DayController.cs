using System;
using UnityEngine;
using UnityEngine.UI;

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
        GameController.Instance.GameState = GameState.Day;
        _day = GameController.Instance.Day;
        _showCRButton.SetCR(_crPrefabs[_day < 3 ? 0 : 1]);

        _showCRButton.Press();
        _showCRButton.GetComponent<Button>().onClick.AddListener(StartGameLoopListener);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            EndTheDay();
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
            EndTheDay();
    }

    public void EndTheDay()
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

    public void ForceEndTheDay()
    {
        _infoPanel.DigitalClock.ForceTimeUp();
    }
    public void ShowSpendingScreen()
    {
        SpendingScreen spendingScreen = Instantiate(_spendingScreenPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);
        int netDecisionCount = _correctDecisionCount - Math.Clamp(_incorrectDecisionCount - FreeIncorrectDecisions, 0, _incorrectDecisionCount);
        spendingScreen.SetInfo(MoneySystem.Instance.Money, netDecisionCount);
        spendingScreen.SetVisible(true);
    }

    private void ShowMessageScreen()
    {
        var messageScreen = Instantiate(_messageScreenPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);
        messageScreen.Initialize(DatabaseManager.Instance.DayEndMessages[GameController.Instance.Day]);
        messageScreen.OnContinueButtonPressed += () =>
        {
            messageScreen.FadeContent(false, endAction: () =>
            {
                ShowSpendingScreen();
            });
        };
    }

    private void StartGameLoopListener()
    {
        GetNewCV();
        _infoPanel.StartDigitalClock();
        _showCRButton.GetComponent<Button>().onClick.RemoveListener(StartGameLoopListener);
    }
}
