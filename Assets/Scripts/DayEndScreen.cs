using TMPro;
using UnityEngine;

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

    private void Awake()
    {
        _rentText.text = (-_rent).ToString();
        _foodText.text = (-_food).ToString();
        _heatText.text = (-_heat).ToString();
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

        int total = savings + salary - _rent - _food - _heat;
        _totalText.text = total.ToString();
        MoneySystem.Instance.EarnMoney(total);
    }
}
