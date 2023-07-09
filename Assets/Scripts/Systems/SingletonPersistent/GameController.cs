using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : SingletonMB<GameController>
{
    public static event Action<int> OnDayChanged;
    public GameState GameState { get; set; }
    public bool IsPaused => GameState == GameState.Paused;

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

    private void LoadDay()
    {
        SceneController.Instance.LoadSceneWithTransition("Day");
    }

    public void ShowTutorial()
    {
        Debug.Log("Tutorial baþlatýlýyor.");
        // TODO: tutorial
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

