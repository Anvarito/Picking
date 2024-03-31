using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Serialization;
using Zenject;

public class CounterUI : MonoBehaviour
{
    [SerializeField] private Text _currentCount;
    [SerializeField] private Text _goalCount;
    private Tween tween;
    private int _count = 0;
    private List<UnloadingArea> _unloadingAreas;


    public void WarmUp(List<UnloadingArea> unloadingAreas, int goalCount)
    {
        _unloadingAreas = unloadingAreas;
        foreach (var area in _unloadingAreas)
        {
            area.OnEncrease += Encrease;
        }

        _goalCount.text = goalCount.ToString();
    }

    private void Encrease()
    {
        _count += 1;
        _currentCount.text = _count.ToString();

        tween.Kill();
        _currentCount.transform.localScale = Vector3.one;
        tween = _currentCount.transform.DOScale(Vector3.one * 1.2f, 0.05f);
        tween.onComplete = () =>
        {
            tween = _currentCount.transform.DOScale(Vector3.one, 0.05f);
        };
    }

    public void CleanUp()
    {
        foreach (var area in _unloadingAreas)
        {
            area.OnEncrease -= Encrease;
        }
    }
}
