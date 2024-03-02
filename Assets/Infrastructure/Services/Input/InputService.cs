using Infrastructure.Factory.Base;
using UnityEngine.Events;
using UnityEngine.EventSystems;


namespace Infrastructure.Services.Input
{
    public class InputService : IInputService
    {

        public UnityAction<PointerEventData> OnDragHandle { get; set; }
        public UnityAction<PointerEventData> OnEndDragHandle { get; set; }
        public UnityAction<PointerEventData> OnPointerDownHandle { get; set; }
        public UnityAction<PointerEventData> OnPointerUpHandle { get; set; }
        public InputService()
        {
            
        }
        public void CleanUp()
        {
            
        }

        public void CreateInput()
        {
            
        }

    }
}