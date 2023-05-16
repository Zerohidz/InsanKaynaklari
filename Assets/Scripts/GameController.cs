using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonMB<GameController>
{
    public static event Action OnDayChanged;
    public GameState MyProperty { get; set; }

    private int _day;
    public int Day
    {
        get { return _day; }
        private set { _day = value; OnDayChanged?.Invoke(); }
    }

    public void StartNewDay()
    {
        Day += 1;
        // TODO: start new day
    }
}

