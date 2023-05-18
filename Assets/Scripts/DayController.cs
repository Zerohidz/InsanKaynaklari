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
        // TODO: decide which cv is gonna be shown

        PersonManger.Instance.NextPerson();
        _cv.SetInfo(PersonManger.Instance.CurrentPersonInfo);
    }


}
