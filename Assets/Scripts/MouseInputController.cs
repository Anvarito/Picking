using Infrastructure.Services.Input;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInputController : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private bool _isStartDrag = false;
    private PointerEventData _dragEventData;
    private IInputService _inputService;

    public void SetUp(IInputService inputService)
    {
        _inputService = inputService;
    }
    
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
        _inputService.OnPointerDownHandle?.Invoke(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
      //  print("OnPointerUp");
        if(eventData.pointerId == -2)
            return;
        _inputService.OnPointerUpHandle?.Invoke(eventData);
    }

    private void Update()
    {
        if(_isStartDrag)
            _inputService.OnDragHandle?.Invoke(_dragEventData);
    }

    public void CleanUp()
    {
        
    }

}