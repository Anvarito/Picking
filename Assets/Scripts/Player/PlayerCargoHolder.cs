using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCargoHolder : MonoBehaviour
{
    [SerializeField] private Transform cargoPoint;
    [SerializeField] private float _unloadDelay = 0.07f;
    private Vector3 positionNextCargo;
    private Stack<Cargo> _cargos = new Stack<Cargo>();
    private bool _isUnloading = false;

    private void Start()
    {
        ResetLoadPoint();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (_isUnloading)
            return;

        if (hit.transform.TryGetComponent(out Cargo cargo))
        {
            if (cargo.IsPicked)
                return;

            cargo.Pick(cargoPoint, positionNextCargo, Vector3.zero);
            positionNextCargo.y += cargo.Size.y * 1.5f;
            _cargos.Push(cargo);
        }
    }

    public void UnloadCargoTo(UnloadingArea unloadingArea)
    {
        if (_isUnloading)
            return;
        _isUnloading = true;

        StartCoroutine(UnloadCoroutine(unloadingArea));
    }

    private IEnumerator UnloadCoroutine(UnloadingArea unloadingArea)
    {
        if (_cargos.TryPop(out Cargo cargo))
        {
            unloadingArea.Unloading(cargo);
            yield return new WaitForSeconds(_unloadDelay);
            StartCoroutine(UnloadCoroutine(unloadingArea));
        }
        else
        {
            ResetLoadPoint();
        }
    }

    private void ResetLoadPoint()
    {
        positionNextCargo = Vector3.zero;
        _isUnloading = false;
    }
}