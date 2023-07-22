using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    public float RealTimeSpanSeconds = 60;
    public DigitalClock DigitalClock;
    public TMP_Text DaySign;

    private void Start()
    {
        InitializeDigitalClock();

        DaySign.SetText(GameController.Instance.Day.ToString());
    }

    public void StartDigitalClock()
    {
        DigitalClock.Run();
    }

    private void InitializeDigitalClock()
    {
        DigitalClock.Configure(
            DateTime.Parse("08:00"),
            DateTime.Parse("17:00"),
            TimeSpan.FromSeconds(RealTimeSpanSeconds),
            TimeSpan.FromMinutes(15)
        );
        DigitalClock.OnTimeUp.AddListener(DayController.Instance.EndTheDay);
    }
}
