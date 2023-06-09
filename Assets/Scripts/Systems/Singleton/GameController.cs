using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : SingletonMB<GameController>
{
    public static event Action<int> OnDayChanged;
    public GameState CurrentGameState { get; set; }

    private int _day;
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
        SceneManager.LoadScene("Day");
    }

    public void StartNewDay()
    {
        Day++;
        SaveCareerData();
        SceneManager.LoadScene("Day");
    }

    private void SaveCareerData()
    {
        SaveSystem.GameData.CareerData.Day = Day;
        SaveSystem.GameData.CareerData.Money = MoneySystem.Instance.Money;

        SaveSystem.SaveGameData();
    }
}

