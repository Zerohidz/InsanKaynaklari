using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DatabaseManager : SingletonMB<DatabaseManager>
{
    private static string Seperator = "<BasriPower>";

    [SerializeField] private TextAsset _dayEndMessagesFile;
    public List<string> DayEndMessages { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if (IsBeingDestroyed) return;

        InitDayEndMessages();
    }

    private void InitDayEndMessages()
    {
        DayEndMessages = _dayEndMessagesFile.text.Split(Seperator).Select(s => s.Trim('\n', '\r')).ToList();
        DayEndMessages.Insert(0, null);
    }

    public override void Reset()
    {

    }
}
