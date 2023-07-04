using TMPro;
using UnityEngine;

public class Status : MonoBehaviour
{
    public TMP_Text Name;

    public GameObject NormalSign;
    public GameObject HungrySign;
    public GameObject StarvingSign;
    public GameObject ColdSign;
    public GameObject FreezingSign;
    public GameObject DeadSign;

    private StatusData _statusData;

    public void Initialize(StatusData statusData)
    {
        _statusData = statusData;
        _statusData.HasJustDied = false;

        Name.text = _statusData.Name;

        if (_statusData.IsWell)
        {
            NormalSign.gameObject.SetActive(true);
        }
        else if (_statusData.IsDead)
        {
            DeadSign.gameObject.SetActive(true);
        }
        else
        {
            if (_statusData.HungerState == StatusData.State.NotWell)
                HungrySign.gameObject.SetActive(true);
            else if (_statusData.HungerState == StatusData.State.NearDead)
                StarvingSign.gameObject.SetActive(true);

            if (_statusData.ColdState == StatusData.State.NotWell)
                ColdSign.gameObject.SetActive(true);
            else if (_statusData.ColdState == StatusData.State.NearDead)
                FreezingSign.gameObject.SetActive(true);
        }
    }
}
