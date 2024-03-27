using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;

public class CounterUI : MonoBehaviour
{
    [SerializeField] private Text text;
    private Tween tween;
    private int _count = 0;
    private List<UnloadingArea> _unloadingAreas;


    public void WarmUp(List<UnloadingArea> unloadingAreas)
    {
        _unloadingAreas = unloadingAreas;
        foreach (var area in _unloadingAreas)
        {
            area.OnEncrease += Encrease;
        }
    }

    private void OnDestroy()
    {
        foreach (var area in _unloadingAreas)
        {
            area.OnEncrease -= Encrease;
        }
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
