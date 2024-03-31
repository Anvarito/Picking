using UnityEngine;
using UnityEngine.Events;

public class MenuButtonListener : MonoBehaviour
{
    [SerializeField] private MenuLevelButton _level1;
    [SerializeField] private MenuLevelButton _level2;
    [SerializeField] private MenuLevelButton _level3;

    public UnityAction<int> OnButtonClick;
    
    private void Awake()
    {
        _level1.OnButtonClicked += LevelOneRun;
        _level2.OnButtonClicked += LevelOneRun;
        _level3.OnButtonClicked += LevelOneRun;
    }

    private void LevelOneRun(int level)
    {
        OnButtonClick?.Invoke(level);
    }
}
