using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: her g�n sabit harcamas� olcak 35 dolar gibi bi�ey
public class MoneySystem : SingletonMB<MoneySystem>
{
    public static event MoneyChanged OnMoneyChanged;
    public delegate void MoneyChanged(int oldMoney, int currentMoney);

    private int _money;
    public int Money
    {
        get => _money;
        set
        {
            int oldMoney = _money;
            _money = value;
            OnMoneyChanged?.Invoke(oldMoney, value);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        if (IsBeingDestroyed)
            return;

        Money = SaveSystem.GameData.CareerData.Money;
        // TODO: Bunlar� ayr� ayr� yerlerde b�yle mi �ekelim yoksa tek bi yerden yerlerine mi g�nderelim
    }

    public override void Reset()
    {
        Money = SaveSystem.GameData.CareerData.Money;
    }

    public void EarnMoney(int amount)
    {
        Money += amount;
    }

    public void LoseMoney(int amount)
    {
        Money -= amount;
    }
}
