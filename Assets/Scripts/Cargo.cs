using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    public void Pick()
    {
        IsPicked = true;
    }

    public void MoveTo(Vector3 end)
    {
        _collider.enabled = false;
        transform.DOLocalMove(end, 0.2f).SetEase(Ease.Linear).onComplete = () =>
        {
            _collider.enabled = true;
        };
    }

    public void RotateTo(Vector3 end)
    {
        transform.DOLocalRotate(Vector3.zero, 0.2f).SetEase(Ease.Linear);
    }

}
