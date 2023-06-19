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

    public void StartGame()
    {
        Day = SaveSystem.GameData.CareerData.Day;
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
        SceneManager.LoadScene("Day");
        IsPaused = false;
    }

    public void SaveCareerData()
    {
        Debug.Log("Career Data Saved!");
        SaveSystem.SaveCareerData(Day, MoneySystem.Instance.Money);
    }
}

