using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : MonoBehaviour
{
    [SerializeField] private Transform _cvParent;
    [SerializeField] private Transform _crParent;
    [SerializeField] private CV[] _cvPrefabs;
    [SerializeField] private CR[] _crPrefabs;
    private CV _cv;
    private CR _cr;
    private int _day;

    private void Start()
    {
        _day = GameController.Instance.Day;

        _cr = Instantiate(_crPrefabs[0], _crParent);
        _cr.SetInfo(CompanyRequestManager.Instance.CurrentCompanyRequest);

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
            _cr.SetInfo(CompanyRequestManager.Instance.CurrentCompanyRequest);
        }
    }
}
