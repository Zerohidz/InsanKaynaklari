using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: her gün sabit harcamasý olcak 35 dolar gibi biþey
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
        // TODO: Bunlarý ayrý ayrý yerlerde böyle mi çekelim yoksa tek bi yerden yerlerine mi gönderelim
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
