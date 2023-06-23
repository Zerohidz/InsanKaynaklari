using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DayEndScreen : MonoBehaviour
{
    // TODO: SaveSytem.Save()'lere Spending'leri de ekle
    // TODO: New Game dedim ama para sýfýrlanmad?

    [Header("Parameters")]
    [SerializeField] private int _rent;
    [SerializeField] private int _food;
    private int _foodInitial;
    [SerializeField] private int _heat;
    private int _heatInitial;

    [Header("FamilyStatus")]
    [SerializeField] private TMP_Text _fatherStatus;
    [SerializeField] private TMP_Text _motherStatus;
    [SerializeField] private TMP_Text _sisterStatus;

    [Header("References")]
    [SerializeField] private TMP_Text _day;
    [SerializeField] private TMP_Text _savingsText;
    [SerializeField] private TMP_Text _cvCount;
    [SerializeField] private TMP_Text _salaryText;
    [SerializeField] private TMP_Text _rentText;
    [SerializeField] private TMP_Text _foodText;
    [SerializeField] private TMP_Text _heatText;
    [SerializeField] private TMP_Text _totalText;

    public bool IsVisible { get; private set; }
    private Animator _animator;
    private int _totalMoney = 0;
    private int _savings;
    private int _salary;
    private int _netCorrectDecisions;
    private bool _saved;

    private void Awake()
    {
        _foodInitial = _food;
        _heatInitial = _heat;

        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _day.text = "Gün " + GameController.Instance.Day.ToString();
    }

    private void SetSpendingTexts()
    {
        _rentText.text = (-_rent).ToString();
        _foodText.text = (-_food).ToString();
        _heatText.text = (-_heat).ToString();

        _savingsText.text = _savings.ToString();
        _salaryText.text = _salary.ToString();
        _cvCount.text = $"({_netCorrectDecisions})";
    }

    public void SetInfo(int? savings = null, int? salary = null, int? netCorrectDecisions = null)
    {
        _savings = savings == null ? _savings : savings.Value;
        _salary = salary == null ? _salary : salary.Value;
        _netCorrectDecisions = netCorrectDecisions == null ? _netCorrectDecisions : netCorrectDecisions.Value;

        SetFamilyStatus();
        SetSpendingTexts();
        UpdateTotalMoney();
    }

    private void SetFamilyStatus()
    {
        var spendings = SaveSystem.GameData.CareerData.Spendings;
        // TODO: set family status
    }

    private void UpdateTotalMoney()
    {
        _totalMoney = _savings + _salary - _rent - _food - _heat;
        _totalText.text = _totalMoney.ToString();
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
        int day = SaveSystem.GameData.CareerData.Day;
        if (saveNextDay)
            day++;

        // TODO: Save family status
        SaveSystem.SaveCareerData(day, _totalMoney);
        _saved = true;
    }

    public void SetVisible(bool willBeVisible)
    {
        IsVisible = willBeVisible;
        _animator.SetBool("Showing", true);
    }

    public void ToggleVisibility()
    {
        SetVisible(!IsVisible);
    }

    public void ToggleFoodSpend()
    {
        _food = _food == 0 ? _foodInitial : 0;
        SetInfo();
    }

    public void ToggleHeatSpend()
    {
        _heat = _heat == 0 ? _heatInitial : 0;
        SetInfo();
    }
}
