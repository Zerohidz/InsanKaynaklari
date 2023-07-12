using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : SingletonMB<GameController>
{
    [Header("Prefabs")]
    [SerializeField] private MessageScreen _messageScreenPrefab;

    public static event Action<int> OnDayChanged;
    public bool IsPaused => GameState == GameState.Paused;

    private GameState _previousGameState;

    private GameState _gameState;
    public GameState GameState
    {
        get => _gameState;
        set
        {
            _previousGameState = _gameState;
            _gameState = value;
        }
    }
    private int _day;
    /// <summary>
    /// Starts from 1
    /// </summary>
    public int Day
    {
        get => _day;
        private set
        {
            _day = value;
            OnDayChanged?.Invoke(value);
        }
    }

    public override void Reset()
    {
        Day = SaveSystem.GameData.CareerData.Day;
    }

    protected override void Awake()
    {
        base.Awake();
        if (IsBeingDestroyed) return;

        Reset();
        HandleSavedGameState();
    }

    public void StartGame()
    {
        LoadDay();
    }

    public void StartNewDay()
    {
        Day++;
        SaveSystem.GameData.CareerData.Day = Day;
        SaveSystem.SaveGameData();
        LoadDay();
    }

    public void RevertToPreviousGameState()
    {
        // Rethink: Bu problemli olabilir
        (GameState, _previousGameState) = (_previousGameState, GameState);
    }

    public void ShowTutorial()
    {
        GameState = GameState.Tutorial;
        Debug.Log("Tutorial baþlatýlýyor.");

        var messageScreen = Instantiate(_messageScreenPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);
        messageScreen.Initialize(DatabaseManager.Instance.TutorialMessage);
        messageScreen.OnContinueButtonPressed += () =>
        {
            GameState = GameState.MainMenu;
            SaveSystem.SaveGameState(GameState);
            messageScreen.FadeOut(() => Destroy(messageScreen.gameObject));
        };
    }

    public void WinTheGame()
    {
        GameState = GameState.WinScreen;
        SaveSystem.SaveMaxScore(Day);
        Debug.Log("Oyunu kazandýn hýyar");
        // TODO: kazanma ekraný
    }

    public void LoseTheGame()
    {
        GameState = GameState.LoseScreen;
        SaveSystem.SaveMaxScore(Day);

        Debug.Log("Oyunu kaybettin hýyar");
        // TODO: kaybetme ekraný ver
    }

    private void LoadDay()
    {
        SceneController.Instance.LoadSceneWithTransition("Day");
    }

    private void HandleSavedGameState()
    {
        var gameState = SaveSystem.GameData.Config.GameState;

        switch (gameState)
        {
            case GameState.Tutorial:
                ShowTutorial();
                break;
            default:
                break;
        }
    }
}

