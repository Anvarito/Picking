using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using Zenject;

public class Cargo : MonoBehaviour
{
    public bool IsPicked { get; private set; }
    public Vector3 Size { get; private set; }

    private Collider _collider;
    private Tween _moveTween;
    private Tween _rotateTween;
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        Size = _collider.bounds.size;
    }

    public void Pick(Transform newParent, Vector3 moveEndPos, Vector3 RotateEndPos, UnityAction onComplete)
    {
        if (IsPicked)
            return;
        IsPicked = true;

        MoveToNewPlace(newParent, moveEndPos, RotateEndPos, onComplete);
    }
    public void Place(Transform newParent, Vector3 moveEndPos, Vector3 RotateEndPos, UnityAction onComplete)
    {
        MoveToNewPlace(newParent, moveEndPos, RotateEndPos, onComplete);
    }
    private void MoveToNewPlace(Transform newParent, Vector3 moveEndPos, Vector3 RotateEndPos, UnityAction onComplete)
    {
        transform.parent = newParent;
        MoveTo(moveEndPos, onComplete);
        RotateTo(RotateEndPos);
    }
    private void MoveTo(Vector3 end, UnityAction onComplete)
    {
        _collider.enabled = false;
        _moveTween = transform.DOLocalMove(end, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            _collider.enabled = true;
            onComplete?.Invoke();
        });
    }

    private void RotateTo(Vector3 end)
    {
        _rotateTween = transform.DOLocalRotate(Vector3.zero, 0.2f).SetEase(Ease.Linear);
    }

    private void OnDestroy()
    {
        _moveTween.Kill();
        _rotateTween.Kill();
    }
    
    public class Factory : PlaceholderFactory<Cargo>
    {
        
    }
}