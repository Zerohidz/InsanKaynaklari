using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : MonoBehaviour
{
    [SerializeField] private CV _cv;
    private int _day;

    private void Start()
    {
        _day = GameController.Instance.Day;
        // TODO: decide which properties are gonna shown according to day

        PersonManger.Instance.GenerateNewPerson();
        _cv.SetInfo(PersonManger.Instance.CurrentPersonInfo);
    }


}
