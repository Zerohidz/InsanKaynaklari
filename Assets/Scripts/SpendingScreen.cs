using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class SpendingScreen : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private int _rentPrice;
    [SerializeField] private int _foodPrice;
    [SerializeField] private int _heatPrice;
    [SerializeField] private int _medicinePrice;

    [Header("References")]
    [SerializeField] private Transform _spendingsParent;
    [SerializeField] private Transform _statusesParent;
    [SerializeField] private TMP_Text _day;
    [SerializeField] private TMP_Text _savingsText;
    [SerializeField] private TMP_Text _cvCount;
    [SerializeField] private TMP_Text _salaryText;
    [SerializeField] private TMP_Text _totalText;

    [Header("Seperators")]
    [SerializeField] private Image _line;

    [Header("Prefabs")]
    [SerializeField] private Spending _spendingPrefab;
    [SerializeField] private Status _statusPrefab;

    private List<Spending> _spendings = new();

    public bool IsVisible { get; private set; }
    private Animator _animator;
    private int _totalMoney = 0;
    private int _savings;
    private int _salary;
    private int _netDecisionCount;
    private bool _saved;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        CreateStatuses();
        CreateSpendings();
    }

    private void CreateStatuses()
    {
        var familyStatus = SaveSystem.GameData.CareerData.FamilyStatus;
        foreach (var statusData in familyStatus.AllStatuses)
        {
            var status = Instantiate(_statusPrefab, _statusesParent);
            status.Initialize(statusData);
        }
    }

    private void CreateSpendings()
    {
        var familyStatus = SaveSystem.GameData.CareerData.FamilyStatus;

        CreateNewSpending("Kira", _rentPrice, togglable: false);
        var foodSpending = CreateNewSpending("Yemek", _foodPrice);
        var heatSpending = CreateNewSpending("Isýnma", _heatPrice);
        foodSpending.OnSpend += () =>
        {
            foreach (var status in familyStatus.AllStatuses)
            {
                if (!status.IsChangable)
                    continue;
                status.HungerState += foodSpending.Active ? 1 : -1;
            }
        };
        heatSpending.OnSpend += () =>
        {
            foreach (var status in familyStatus.AllStatuses)
            {
                if (!status.IsChangable)
                    continue;
                status.ColdState += heatSpending.Active ? 1 : -1;
            }
        };
        _spendings.Add(foodSpending);
        _spendings.Add(heatSpending);

        foreach (var status in familyStatus.AllStatuses)
        {
            if (!status.NeedsMedicine)
                continue;

            var medicineSpending = CreateNewSpending("Ýlaç", _medicinePrice, status.Name);
            medicineSpending.OnSpend += () =>
            {
                status.ColdState += medicineSpending.Active ? 1 : -1;
            };
            _spendings.Add(medicineSpending);
        }
    }

    private Spending CreateNewSpending(string name, int price, string description = null, bool togglable = true)
    {
        var spending = Instantiate(_spendingPrefab, _spendingsParent);
        spending.transform.SetSiblingIndex(_line.transform.GetSiblingIndex());
        if (togglable)
            spending.OnToggle += _ =>
            {
                // GetTotalCost() hesabýnda þu an spending aktif
                if (GetTotalCost() > _salary + _savings)
                    spending.Deactivate(true);
                UpdateTotalMoney();
            };
        spending.Initialize(name, price, description, togglable);

        _spendingsParent.Translate(0, spending.GetComponent<RectTransform>().rect.height / 2, 0);

        return spending;
    }

    private int GetTotalCost()
    {
        return _spendings.Sum(s => s.Cost) + _rentPrice;
    }

    private void SetSpendingTexts()
    {
        _savingsText.text = _savings.ToString();
        _salaryText.text = _salary.ToString();
        _cvCount.text = $"({_netDecisionCount})";
    }

    public void SetInfo(int? savings = null, int? netDecisionCount = null)
    {
        if (savings != null)
            _savings = savings.Value;
        if (netDecisionCount != null)
        {
            _netDecisionCount = netDecisionCount.Value;
            _salary = _netDecisionCount * 5;
        }

        _day.text = "Gün " + GameController.Instance.Day.ToString();
        SetSpendingTexts();
        UpdateTotalMoney();
    }

    private void UpdateTotalMoney()
    {
        _totalMoney = _savings + _salary - GetTotalCost();
        _totalText.text = _totalMoney.ToString();

        if (_totalMoney < 0 && GameController.Instance.GameState != GameState.LoseScreen)
            GameController.Instance.LoseTheGame();
    }

    public void OnContinueButtonPressed()
    {
        MoneySystem.Instance.Money = _totalMoney;
        SaveTheDay(saveNextDay: false);

        GameController.Instance.StartNewDay();
    }

    private void OnDestroy()
    {
        if (!IsVisible || _saved)
            return;

        SaveTheDay();
    }

    private void OnApplicationQuit()
    {
        if (!IsVisible || _saved)
            return;

        SaveTheDay();
    }

    private void SaveTheDay(bool saveNextDay = true)
    {
        if (_totalMoney < 0)
        {
            SaveSystem.SaveLostGame();
            return;
        }
        int day = SaveSystem.GameData.CareerData.Day;
        if (saveNextDay)
            day++;

        SpendNewSpendings();
        SaveSystem.SaveCareerData(day, _totalMoney);
        _saved = true;
    }

    public void SetVisible(bool willBeVisible)
    {
        if (willBeVisible)
            GameController.Instance.GameState = GameState.SpendingScreen;
        else
            GameController.Instance.RevertToPreviousGameState();
        IsVisible = willBeVisible;
        _animator.SetBool("Showing", true);
    }

    public void ToggleVisibility()
    {
        SetVisible(!IsVisible);
    }

    private void SpendNewSpendings()
    {
        _spendings.ForEach(s => s.Spend());
    }
}
