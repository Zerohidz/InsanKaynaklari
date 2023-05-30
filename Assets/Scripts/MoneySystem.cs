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
        private set
        {
            int oldMoney = _money;
            _money = value;
            OnMoneyChanged?.Invoke(oldMoney, value);
        }
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
