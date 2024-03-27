using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    private Transform _point;
    private TigerMover[] _tigerMovers;

    public virtual Building Init(Transform point)
    {
        _point = point;

        return this;
    }

    public void UpdateSubscribe(TigerMover[] tigerMovers)
    {
        foreach (TigerMover mover in tigerMovers)
        {
            mover.PointTouched -= OnPointTouched;
        }

        foreach (TigerMover mover in tigerMovers)
        {
            mover.PointTouched += OnPointTouched;
        }

        _tigerMovers = tigerMovers;
    }

    private void OnDisable()
    {
        foreach (TigerMover mover in _tigerMovers)
        {
            mover.PointTouched -= OnPointTouched;
        }
    }

    private void OnPointTouched(Transform transform)
    {
        if (_point.Equals(transform))
        {
            Debug.Log("Point Touched");
            OnPointTouched();
        }
    }

    protected abstract void OnPointTouched();
}
