using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public UnityAction<PointerEventData> OnDragHandle;
    public UnityAction<PointerEventData> OnEndDragHandle;
    public UnityAction<PointerEventData> OnPointerDownHandle;
    public UnityAction<PointerEventData> OnPointerUpHandle;

    private bool _isStartDrag = false;
    private PointerEventData _dragEventData;
    
    public void OnDrag(PointerEventData eventData)
    {
        //print("OnDrug" + eventData.pointerId);
        if(eventData.pointerId == -2)
            return;
        _isStartDrag = true;
        _dragEventData = eventData;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //print("OnEndDrug");
        if(eventData.pointerId == -2)
            return;
        _isStartDrag = false;
        _dragEventData = null;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //print("OnPointerDOwen");
        if(eventData.pointerId == -2)
            return;
        OnPointerDownHandle?.Invoke(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
      //  print("OnPointerUp");
        if(eventData.pointerId == -2)
            return;
        OnPointerUpHandle?.Invoke(eventData);
    }

    private void Update()
    {
        if(_isStartDrag)
            OnDragHandle?.Invoke(_dragEventData);
    }
}