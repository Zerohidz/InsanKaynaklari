using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : SingletonMB<GameController>
{
    public static event Action<int> OnDayChanged;
    public GameState MyProperty { get; set; }

    private int _day;
    public int Day
    {
        get { return _day; }
        private set { _day = value; OnDayChanged?.Invoke(value); }
    }

    public void StartNewDay()
    {   
        Day = Day + 1;
        SceneManager.LoadScene("Day");
    }
}

