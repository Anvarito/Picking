using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class UnloadingArea : MonoBehaviour
{
    [SerializeField] private int _xMaxCount;
    [SerializeField] private int _zMaxCount;
    [SerializeField] private float _sizeOffset = 1.5f;

    [SerializeField] private Transform _unloadParent;

    private Vector3 positionNextUnload;

    private int _currentXindex = 0;
    private int _currentYindex = 0;
    private int _currentZindex = 0;

    public UnityEvent OnEncrease;

    private void Awake()
    {
        positionNextUnload = Vector3.zero;
    }

    public void Unloading(Cargo cargo)
    {

        if (_currentZindex >= _zMaxCount)
        {
            _currentXindex += 1;
            if (_currentXindex >= _xMaxCount)
            {
                _currentYindex += 1;
                _currentXindex = 0;
            }

            _currentZindex = 0;
        }

        positionNextUnload.x = cargo.Size.x * _currentXindex;
        positionNextUnload.y = cargo.Size.y * _currentYindex;
        positionNextUnload.z = cargo.Size.z * _currentZindex;

        _currentZindex += 1;

        cargo.Place(_unloadParent ,positionNextUnload, Vector3.zero);

        OnEncrease?.Invoke();
    }
}
