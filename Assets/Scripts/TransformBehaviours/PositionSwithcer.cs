using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSwithcer : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private Transform _destination;
    [SerializeField] private float _displaySpeed = 5;

    [Header("Child Movement")]
    public Transform Child;

    private Vector3 _initialPoisition;
    private bool _inDestination;

    private void Awake()
    {
        _initialPoisition = transform.position;
    }

    public void Switch()
    {
        _inDestination = !_inDestination;
        StopAllCoroutines();
        StartCoroutine(LerpPositionCoroutine(_inDestination));
    }

    IEnumerator LerpPositionCoroutine(bool displaying)
    {
        Vector3 targetPosition = GetTargetPosition(displaying);
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, _displaySpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) <= 0.01f)
                break;
            yield return null;
        }
    }

    private Vector3 GetTargetPosition(bool displaying)
    {
        Vector3 destinationPosition = _destination.transform.position;
        if (Child != null)
            destinationPosition += (transform.position - Child.position);

        Vector3 targetPosition = displaying ? destinationPosition : _initialPoisition;
        return targetPosition;
    }
}
