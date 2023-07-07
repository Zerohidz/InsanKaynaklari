using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : SingletonMB<GameController>
{
    public static event Action<int> OnDayChanged;
    public GameState CurrentGameState { get; set; }
    public bool IsPaused { get; set; }

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

    public void StartGame()
    {
        Day = SaveSystem.GameData.CareerData.Day;
        LoadDay();
    }

    public void StartNewDay()
    {
        Day++;
        // TODO: if the day is greater than 5, show EndScene
        SaveSystem.GameData.CareerData.Day = Day;
        SaveSystem.SaveGameData();
        LoadDay();
    }

    private void LoadDay()
    {
        SceneController.Instance.LoadSceneWithTransition("Day");
        IsPaused = false;
    }

    public void WinTheGame()
    {
        Debug.Log("Oyunu kazandýn hýyar");
        // TODO: kazanma ekraný
    }

    public void LoseTheGame()
    {
        Debug.Log("Oyunu kaybettin hýyar");
        // TODO: kaybetme ekraný ver
    }
}

