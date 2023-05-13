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
            Gender.Female => "Kad�n",
            _ => "Belirsiz hocam",
        };
        return displayText;
    }
}
