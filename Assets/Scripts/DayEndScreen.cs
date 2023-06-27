using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class DayEndScreen : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private int _rentPrice;
    [SerializeField] private int _foodPrice;
    [SerializeField] private int _heatPrice;

    [Header("FamilyStatus")]
    [SerializeField] private TMP_Text _fatherStatus;
    [SerializeField] private TMP_Text _motherStatus;
    [SerializeField] private TMP_Text _sisterStatus;

    [Header("References")]
    [SerializeField] private Transform _spendingsParent;
    [SerializeField] private TMP_Text _day;
    [SerializeField] private TMP_Text _savingsText;
    [SerializeField] private TMP_Text _cvCount;
    [SerializeField] private TMP_Text _salaryText;
    [SerializeField] private TMP_Text _rentText;
    [SerializeField] private TMP_Text _totalText;

    [Header("Seperators")]
    [SerializeField] private Image _line;

    [Header("Prefabs")]
    [SerializeField] private Spending _spending;

    private List<Spending> _newSpendings = new();

    public bool IsVisible { get; private set; }
    private Animator _animator;
    private int _totalMoney = 0;
    private int _savings;
    private int _salary;
    private int _netDecisionCount;
    private bool _saved;

    private void Awake()
    {
        _newSpendings.Add(CreateNewSpending("Yemek", _foodPrice));
        _newSpendings.Add(CreateNewSpending("Isýnma", _heatPrice));
        _newSpendings.Add(CreateNewSpending("Ýlaç", 10));

        _animator = GetComponent<Animator>();
    }

    private Spending CreateNewSpending(string name, int price)
    {
        var spending = Instantiate(_spending, _spendingsParent);
        spending.transform.SetSiblingIndex(_line.transform.GetSiblingIndex());
        spending.Initialize(name, price);
        spending.OnToggle += _ => UpdateTotalMoney();

        return spending;
    }

    private void Start()
    {
        _day.text = "Gün " + GameController.Instance.Day.ToString();
    }

    private void SetSpendingTexts()
    {
        _rentText.text = "-" + _rentPrice.ToString();

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
        _totalMoney = _savings + _salary - _rentPrice - _newSpendings.Sum(s => s.Cost);
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
}
