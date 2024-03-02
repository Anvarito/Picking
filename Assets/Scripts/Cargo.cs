using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class Cargo : MonoBehaviour
{
    public bool IsPicked { get; private set; }
    public Vector3 Size { get; private set; }

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        Size = _collider.bounds.size;
    }

    public void Pick(Transform newParent, Vector3 moveEndPos, Vector3 RotateEndPos)
    {
        if (IsPicked)
            return;
        IsPicked = true;

        MoveToNewPlace(newParent, moveEndPos, RotateEndPos);
    }
    public void Place(Transform newParent, Vector3 moveEndPos, Vector3 RotateEndPos)
    {
        MoveToNewPlace(newParent, moveEndPos, RotateEndPos);
    }
    private void MoveToNewPlace(Transform newParent, Vector3 moveEndPos, Vector3 RotateEndPos)
    {
        transform.parent = newParent;
        MoveTo(moveEndPos);
        RotateTo(RotateEndPos);
    }
    private void MoveTo(Vector3 end)
    {
        _collider.enabled = false;
        transform.DOLocalMove(end, 0.2f).SetEase(Ease.Linear).onComplete = () => { _collider.enabled = true; };
    }

    private void RotateTo(Vector3 end)
    {
        transform.DOLocalRotate(Vector3.zero, 0.2f).SetEase(Ease.Linear);
    }

    
}