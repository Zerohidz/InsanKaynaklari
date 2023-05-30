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
    private int _correctDecisionCount;
    private int _incorrectDecisionCount;

    private void Start()
    {
        _day = GameController.Instance.Day;

        _showCRButton.SetCR(_crPrefabs[_day < 3 ? 0 : 1]);

        GetNewCV();
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

    public void GetNewCV()
    {
        if (_cv != null)
            return;

        PersonManger.Instance.NextPerson();
        _cv = Instantiate(_cvPrefabs[0], _cvParent);
        _cv.SetInfo(PersonManger.Instance.CurrentPersonInfo);
    }

    public void DecideCorrectness(bool accepted)
    {
        if (_cv == null)
            return;

        if (accepted)
        {
            _cv.Accept();
            _cv = null;

            if (PersonManger.Instance.CurrentPersonInfo.IsCorrect)
            {
                _correctDecisionCount++;
                Debug.Log("Doðru adamla devam!");
            }
            else
            {
                _incorrectDecisionCount++;
                Debug.Log("Yanlýþ adam buu!");
            }
        }
        else
        {
            _cv.Reject();
            _cv = null;

            if (PersonManger.Instance.CurrentPersonInfo.IsCorrect)
            {
                _incorrectDecisionCount++;
                Debug.Log("Yanlýþ yaptýn abi adam doðruydu!");
            }
            else
            {
                _correctDecisionCount++;
                Debug.Log("Doðru karar! Bu adam yanlýþ!");
            }
        }
    }
}
