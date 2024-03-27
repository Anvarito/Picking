using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


namespace Infrastructure.Services.Input
{
    public class InputService : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler, IInputService
    {

        public UnityAction<PointerEventData> OnDragHandle { get; set; }
        public UnityAction<PointerEventData> OnEndDragHandle { get; set; }
        public UnityAction<PointerEventData> OnPointerDownHandle { get; set; }
        public UnityAction<PointerEventData> OnPointerUpHandle { get; set; }
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

        public void CleanUp()
        {
        
        }

    }
}