using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    public DigitalClock DigitalClock;
    public TMP_Text DaySign;

    private void Start()
    {
        DigitalClock.Configure(DateTime.Parse("08:00"), DateTime.Parse("17:00"), TimeSpan.FromSeconds(60), TimeSpan.FromMinutes(15));
        DigitalClock.OnTimeUp += () => DayController.Instance.EndDay();
        DigitalClock.Run();

        DaySign.SetText(GameController.Instance.Day.ToString());
    }
}
