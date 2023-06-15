using Krivodeling.UI.Effects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO
public class ESCPanel : MonoBehaviour
{
    public UIBlur Blur;
    public Button ResumeButton;
    public Button QuitButton;
    [HideInInspector] public bool IsShowing;

    public void OnResumeButtonPressed()
    {
    }

    public void OnQuitButtonPressed()
    {

    }

    public void ToggleShow()
    {
        SetIsShowing(!IsShowing);
    }

    public void SetIsShowing(bool willShow)
    {
        // TODO show hide
        if (IsShowing)
        {
            if (willShow == false)
                Blur.EndBlur(1);
        }
        else if (willShow == true)
        {
            Blur.BeginBlur(1);
        }
        IsShowing = willShow;
    }
}
