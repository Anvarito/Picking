using System;
using Infrastructure.Services.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickHandler : MonoBehaviour
{
    [SerializeField] private Image _joystickOutter;
    [SerializeField] private Image _joystickInner;
    
    private IInputService _mouseInputController;
    private GameObject _joystick;
    private Vector2 _inputVector;

    public bool IsVisible => _joystick is null ? false : _joystick.activeInHierarchy;

    public void SetUp(IInputService inputService)
    {
        _mouseInputController = inputService;
        _mouseInputController.OnDragHandle += OnDrag;
        _mouseInputController.OnEndDragHandle += OnEndDrag;
        _mouseInputController.OnPointerDownHandle += OnPointerDown;
        _mouseInputController.OnPointerUpHandle += OnPointerUp;
        
        _joystick = _joystickOutter.gameObject;
        Hide();
    }

    private void OnDestroy()
    {
        _mouseInputController.OnDragHandle -= OnDrag;
        _mouseInputController.OnEndDragHandle -= OnEndDrag;
        _mouseInputController.OnPointerDownHandle -= OnPointerDown;
        _mouseInputController.OnPointerUpHandle -= OnPointerUp;
    }


    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickOutter.rectTransform, eventData.position, eventData.enterEventCamera, out pos))
        {
            pos.x = (pos.x / _joystickOutter.rectTransform.sizeDelta.x);
            pos.y = (pos.y / _joystickOutter.rectTransform.sizeDelta.x);

            _inputVector = new Vector2(pos.x * 2, pos.y * 2);
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;
            _joystickInner.rectTransform.anchoredPosition = new Vector2(_inputVector.x * (_joystickOutter.rectTransform.sizeDelta.x / 2.75f), _inputVector.y * (_joystickOutter.rectTransform.sizeDelta.y / 2.75f));
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _inputVector = Vector2.zero;
        _joystickInner.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Show();
        _joystickOutter.rectTransform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Hide();
    }

    private void Show()
    {
        _joystick.SetActive(true);
    }
    
    private void Hide()
    {
        _joystick.SetActive(false);
    }
    
}
