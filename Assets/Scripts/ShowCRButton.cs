using System;
using System.Collections;
using UnityEngine;

public class ShowCRButton : MonoBehaviour
{
    [SerializeField] private Transform _crDestination;
    [SerializeField] private Transform _crPosition;
    private Vector3 _startPoisition;
    private bool _displaying;
    private float _displaySpeed = 5;
    private CR _cr;

    private void Awake()
    {
        _startPoisition = transform.position;
    }

    public void SwitchDisplay()
    {
        _displaying = !_displaying;
        StopAllCoroutines();
        StartCoroutine(SetDisplayCoroutine(_displaying));
    }

    IEnumerator SetDisplayCoroutine(bool displaying)
    {
        Vector3 destination = displaying ? (_crDestination.transform.position + (transform.position - _crPosition.position)) : _startPoisition;
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, destination, _displaySpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, destination) <= 0.01f)
                break;
            yield return null;
        }
    }

    internal void SetCR(CR cr)
    {
        _cr = Instantiate(cr, _crPosition.transform);
        _cr.SetInfo(CompanyRequestManager.Instance.CurrentCompanyRequest);
    }
}
