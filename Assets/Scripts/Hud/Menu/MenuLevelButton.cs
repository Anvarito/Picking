using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuLevelButton : Selectable, IPointerClickHandler
{
    [SerializeField] private int _levelNumber;
    public UnityAction<int> OnButtonClicked;
   
    private void Click()
    {
        OnButtonClicked?.Invoke(_levelNumber);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Click();
    }
}