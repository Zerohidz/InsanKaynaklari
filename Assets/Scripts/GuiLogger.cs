using System.Collections;
using UnityEngine;

public class GuiLogger : SingletonMB<GuiLogger>
{
    private string _content = "";
    private Queue _queue = new();
    private bool _active = false;

    protected override void Awake()
    {
        base.Awake();
        if (IsBeingDestroyed) return;

        Application.logMessageReceived += HandleLog;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            Toggle();
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.L))
            ClearContent();
    }

    private void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
    }

    public void Toggle()
    {
        _active = !_active;
    }

    public void ClearContent()
    {
        _content = string.Empty;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        _content = logString;
        string newString = "\n [" + type + "] : " + _content;
        _queue.Enqueue(newString);
        if (type == LogType.Exception)
        {
            newString = "\n" + stackTrace;
            _queue.Enqueue(newString);
        }
        _content = string.Empty;
        foreach (string mylog in _queue)
            _content += mylog;
    }

    void OnGUI()
    {
        if (_active)
            GUILayout.Label(_content);
    }

    public override void Reset()
    {

    }
}
