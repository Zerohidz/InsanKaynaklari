#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class PlayTestMenu
{
    [MenuItem("PlayTest/Jump To Critic Finale")]
    public static void JumptoCriticFinale()
    {
        SetMoneyTo300();
        JumpToDay5();

        var familyStatus = SaveSystem.GameData.CareerData.FamilyStatus;
        familyStatus.Father.ColdState = StatusData.State.NearDead;
        familyStatus.Mother.ColdState = StatusData.State.NearDead;
        familyStatus.Sister.ColdState = StatusData.State.NearDead;

        EndTheDay();
    }

    [MenuItem("PlayTest/End The Day")]
    public static void EndTheDay()
    {
        DayController.Instance.ForceEndTheDay();
    }

    [MenuItem("PlayTest/Set Money To 300")]
    public static void SetMoneyTo300()
    {
        MoneySystem.Instance.Money = 300;
        SaveSystem.SaveCareerData(money: 300);
    }

    [MenuItem("PlayTest/Set Money To 0")]
    public static void SetMoneyTo0()
    {
        MoneySystem.Instance.Money = 0;
        SaveSystem.SaveCareerData(money: 0);
    }

    [MenuItem("PlayTest/Jump To Day 2")]
    public static void JumpToDay2()
    {
        JumpToDay(2);
    }

    [MenuItem("PlayTest/Jump To Day 3")]
    public static void JumpToDay3()
    {
        JumpToDay(3);
    }

    [MenuItem("PlayTest/Jump To Day 4")]
    public static void JumpToDay4()
    {
        JumpToDay(4);
    }

    [MenuItem("PlayTest/Jump To Day 5")]
    public static void JumpToDay5()
    {
        JumpToDay(5);
    }

    public static void JumpToDay(int day)
    {
        SaveSystem.SaveCareerData(day: day);
        Systems.Instance.Reset();
    }

}
#endif