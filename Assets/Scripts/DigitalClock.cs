using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TMP_Text))]
public class DigitalClock : MonoBehaviour
{
    public UnityEvent OnTimeUp;
    public DateTime DisplayTime { get; private set; }
    public DateTime CurrentTime { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public TimeSpan RealTimeSpan { get; private set; }
    public TimeSpan DisplayIncrement { get; private set; }
    public bool IsRunning { get; private set; }

    private TMP_Text _text;
    private double _timeMultiplier;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.SetText(DisplayTime.ToString("HH:mm"));
    }

    public void Configure(DateTime startTime, DateTime endTime, TimeSpan realTimeSpan = default, TimeSpan displayIncrement = default)
    {
        StartTime = startTime;
        EndTime = endTime;
        RealTimeSpan = realTimeSpan;
        DisplayIncrement = displayIncrement;
        CurrentTime = StartTime;
        DisplayTime = CurrentTime;

        _timeMultiplier = 1;
        if (RealTimeSpan == default)
            RealTimeSpan = EndTime - StartTime;
        _timeMultiplier = (EndTime - StartTime) / RealTimeSpan;

        if (displayIncrement == default)
            DisplayIncrement = TimeSpan.FromSeconds(1);
    }

    public void Run()
    {
        IsRunning = true;
    }

    public void Stop()
    {
        IsRunning = false;
    }

    public void ForceTimeUp()
    {
        CurrentTime = EndTime;
        DisplayTime = EndTime;
        _text.SetText(DisplayTime.ToString("HH:mm"));
        TimeUp();
    }

    private void Update()
    {
        if (!IsRunning)
            return;

        if (GameController.Instance.IsPaused)
            return;

        if (CurrentTime >= EndTime)
        {
            TimeUp();
            return;
        }

        CurrentTime = CurrentTime.AddSeconds(Time.deltaTime * _timeMultiplier);
        if (CurrentTime - DisplayTime >= DisplayIncrement)
            DisplayTime = CurrentTime.AddTicks(-(CurrentTime.Ticks % DisplayIncrement.Ticks));
        _text.SetText(DisplayTime.ToString("HH:mm"));
    }

    private void TimeUp()
    {
        OnTimeUp?.Invoke();
        IsRunning = false;
    }
}
