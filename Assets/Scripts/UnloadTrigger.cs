using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadTrigger : MonoBehaviour
{
    [SerializeField] private UnloadingArea _unloadingArea;
    public static Action<UnloadingArea> OnUnload;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out PlayerCargoHolder unloader))
        {
            OnUnload?.Invoke(_unloadingArea);
        }
    }
}
