using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DatabaseManager : SingletonMB<DatabaseManager>
{
    private static string Seperator = "<BasriPower>";

    [SerializeField] private TextAsset _dayEndMessagesFile;
    [SerializeField] private TextAsset _tutorialMessageFile;
    [SerializeField] private TextAsset _winMessageFile;
    [SerializeField] private TextAsset _loseMessagesFile;
    public string[] DayEndMessages { get; private set; }
    public string TutorialMessage { get; private set; }
    public string WinMessage { get; private set; }
    public string[] LoseMessages { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if (IsBeingDestroyed) return;

        InitMessages();
    }

    private void InitMessages()
    {
        TutorialMessage = _tutorialMessageFile.text.Trim('\n', '\r');
        WinMessage = _winMessageFile.text.Trim('\n', '\r');
        LoseMessages = _loseMessagesFile.text.Split(Seperator).Select(s => s.Trim('\n', '\r')).ToArray();
        InitDayEndMessages();
    }

    private void InitDayEndMessages()
    {
        var dayEndMessages = _dayEndMessagesFile.text.Split(Seperator).Select(s => s.Trim('\n', '\r')).ToList();
        dayEndMessages.Insert(0, null);
        DayEndMessages = dayEndMessages.ToArray();
    }

    public override void Reset()
    {

    }
}
