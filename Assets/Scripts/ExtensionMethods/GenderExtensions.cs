using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenderExtensions
{
    public static string GetDisplay(this Gender gender)
    {
        string displayText = gender switch
        {
            Gender.Male => "Erkek",
            Gender.Female => "Kadýn",
            _ => "Belirsiz hocam",
        };
        return displayText;
    }
}
