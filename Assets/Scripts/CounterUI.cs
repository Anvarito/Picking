using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;

public class CounterUI : MonoBehaviour
{
    [SerializeField] private Text text;
    private UnloadingArea _unloadingArea;
    private Tween tween;
    private int _count = 0;

    [Inject]
    private void Construct(UnloadingArea unloadingArea)
    {
        _unloadingArea = unloadingArea;
        _unloadingArea.OnEncrease += Encrease;
    }
    
    private void Encrease()
    {
        _count += 1;
        text.text = _count.ToString();

        tween.Kill();
        text.transform.localScale = Vector3.one;
        tween = text.transform.DOScale(Vector3.one * 1.2f, 0.05f);
        tween.onComplete = () =>
        {
            tween = text.transform.DOScale(Vector3.one, 0.05f);
        };
    }
}
