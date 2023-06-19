using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DayEndScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _day;
    [SerializeField] private TMP_Text _savingsText;
    [SerializeField] private TMP_Text _cvCount;
    [SerializeField] private TMP_Text _salaryText;
    [SerializeField] private TMP_Text _rentText;
    [SerializeField] private TMP_Text _foodText;
    [SerializeField] private TMP_Text _heatText;
    [SerializeField] private TMP_Text _totalText;

    [SerializeField] private int _rent;
    [SerializeField] private int _food;
    [SerializeField] private int _heat;

    public bool IsVisible { get; private set; }
    private Animator _animator;
    private int _totalMoney = 0;
    private bool _saved;

    private void Awake()
    {
        _rentText.text = (-_rent).ToString();
        _foodText.text = (-_food).ToString();
        _heatText.text = (-_heat).ToString();

        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _day.text = "Gün " + GameController.Instance.Day.ToString();
    }

    public void SetInfo(int savings, int salary, int correctDecisionCount)
    {
        _savingsText.text = savings.ToString();
        _salaryText.text = salary.ToString();
        _cvCount.text = $"({correctDecisionCount})";

        _totalMoney = savings + salary - _rent - _food - _heat;
        _totalText.text = _totalMoney.ToString();
    }

    public void OnContinueButtonPressed()
    {
        MoneySystem.Instance.Money = _totalMoney;
        GameController.Instance.SaveCareerData();
        GameController.Instance.StartNewDay();
        _saved = true;
    }

    private void OnDestroy()
    {
        if (!IsVisible || _saved)
            return;

        SaveSystem.SaveCareerData(SaveSystem.GameData.CareerData.Day + 1, _totalMoney);
        _saved = true;
    }

    private void OnApplicationQuit()
    {
        if (!IsVisible || _saved)
            return;

        SaveSystem.SaveCareerData(SaveSystem.GameData.CareerData.Day + 1, _totalMoney);
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
