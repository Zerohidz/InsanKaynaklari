using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : MonoBehaviour
{
    [SerializeField] private Transform _cvParent;
    [SerializeField] private ShowCRButton _showCRButton;
    [SerializeField] private CV[] _cvPrefabs;
    [SerializeField] private CR[] _crPrefabs;
    private CV _cv;
    private int _day;

    private void Start()
    {
        _day = GameController.Instance.Day;

        _showCRButton.SetCR(_crPrefabs[0]);

        PersonManger.Instance.NextPerson();
        _cv = Instantiate(_cvPrefabs[0], _cvParent);
        _cv.SetInfo(PersonManger.Instance.CurrentPersonInfo);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            PersonManger.Instance.NextPerson();
            _cv.SetInfo(PersonManger.Instance.CurrentPersonInfo);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            GameController.Instance.StartNewDay();
        }
    }

    public void DecideCorrectness(bool correctness)
    {
        if (correctness)
        {
            _cv.Accept();

            if (PersonManger.Instance.CurrentPersonInfo.IsCorrect)
                Debug.Log("Doðru adamla devam!");
            else
                Debug.Log("Yanlýþ adam buu!");
        }
        else
        {
            _cv.Reject();

            if (PersonManger.Instance.CurrentPersonInfo.IsCorrect)
                Debug.Log("Yanlýþ yaptýn abi adam doðruydu!");
            else
                Debug.Log("Doðru karar! Bu adam yanlýþ!");
        }

    }
}
