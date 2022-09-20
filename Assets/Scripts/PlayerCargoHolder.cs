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
    private void Awake()
    {
        UnloadTrigger.OnUnload += UnloadCargo;
    }
    private void Start()
    {
        ResetLoadPoint();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!_isUnloading && hit.transform.TryGetComponent(out Cargo cargo))
        {
            if (cargo.IsPicked)
                return;

            cargo.Pick();
            cargo.transform.parent = cargoPoint;

            cargo.RotateTo(Vector3.zero);
            cargo.MoveTo(positionNextCargo);

            _cargos.Push(cargo);

            positionNextCargo.y += cargo.Size.y * 1.5f;
        }
    }

    private void UnloadCargo(UnloadingArea unloadingArea)
    {
        if (_isUnloading)
            return;

        StartCoroutine(UnloadCoroutine(unloadingArea));
    }

    private IEnumerator UnloadCoroutine(UnloadingArea unloadingArea)
    {
        if (_cargos.TryPop(out Cargo result))
        {
            _isUnloading = true;
            unloadingArea.Unloading(result);
            yield return new WaitForSeconds(_unloadDelay);
            StartCoroutine(UnloadCoroutine(unloadingArea));
        }
        else
        {
            _isUnloading = false;
            ResetLoadPoint();
        }
    }

    private void ResetLoadPoint()
    {
        positionNextCargo = Vector3.zero;
    }
}
