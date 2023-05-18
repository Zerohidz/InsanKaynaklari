using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : SingletonMB<GameController>
{
    public static event Action OnDayChanged;
    public GameState MyProperty { get; set; }

    private int _day = 1;
    public int Day
    {
        get { return _day; }
        private set { _day = value; OnDayChanged?.Invoke(); }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            StartNewDay();
    }

    public void StartNewDay()
    {
        Day = Day + 1;
        // TODO: start new day
        SceneManager.LoadScene("Day");
    }
}

