using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadTrigger : MonoBehaviour
{
    [SerializeField] private UnloadingArea _unloadingArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out PlayerCargoHolder unloader))
        {
            unloader.UnloadCargoTo(_unloadingArea);
        }
    }
}
