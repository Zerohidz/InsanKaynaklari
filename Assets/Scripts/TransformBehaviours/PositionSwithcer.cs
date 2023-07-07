using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PositionSwithcer : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private Transform _destination;
    [SerializeField] private float _displayTime = 1.75f;
    [SerializeField] private float _springTime = 0.25f;
    [SerializeField] private float _springLength = 15;

    [Header("Child Movement")]
    public Transform Child;
    public bool InDestination;

    private Vector3 _initialPoisition;

    private void Awake()
    {
        _initialPoisition = transform.position;
    }

    public void Switch()
    {
        var targetPosition = InDestination ? _initialPoisition : GetDestinationPosition();
        StopAllCoroutines();
        StartCoroutine(LerpPositionCoroutine(GetSpringPosition(), _springTime, endAction: () =>
        {
            StartCoroutine(LerpPositionCoroutine(targetPosition, _displayTime));
            InDestination = !InDestination;
        }));
    }

    IEnumerator LerpPositionCoroutine(Vector3 targetPosition, float time, Action endAction = null)
    {
        float startTime = Time.time;
        while (true)
        {
            float t = (Time.time - startTime) / time;
            transform.position = Vector3.Lerp(transform.position, targetPosition, t);
            if (Vector3.Distance(transform.position, targetPosition) <= 0.01f)
                break;
            yield return null;
        }

        endAction?.Invoke();
    }

    private Vector3 GetSpringPosition()
    {
        return transform.position + Vector3.Normalize(transform.position - GetDestinationPosition()) * _springLength;
    }

    private Vector3 GetDestinationPosition()
    {
        Vector3 destinationPosition = _destination.transform.position;
        if (Child != null)
            destinationPosition += (transform.position - Child.position);

        return destinationPosition;
    }
}
