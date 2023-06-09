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

    public void Start()
    {
        Debug.Log(SaveSystem.GameData);
    }

    public void StartNewDay()
    {
        Day++;
        SceneManager.LoadScene("Day");
    }
}

