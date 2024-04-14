using Infrastructure.Services.StaticData;
using Infrastructure.Services.StaticData.Level;
using Infrastructure.States;
using Infrastructure.States.MainStates;
using Infrastructure.States.StateMachines;
using Zenject;

namespace Menu
{
    public class LevelSelector : IInitializable
    {
        private MainStateMachine _mainStateMachine;
        private MenuButtonListener _menuButtonListener;
        private StaticDataService _staticDataService;

        public LevelSelector(MainStateMachine mainStateMachine, MenuButtonListener menuButtonListener, StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _menuButtonListener = menuButtonListener;
            _mainStateMachine = mainStateMachine;
        }

        public void Initialize()
        {
            _menuButtonListener.OnButtonClick += LevelSelect;
        }

        private void LevelSelect(int level)
        {
            LevelConfig levelConfig = _staticDataService.ForLevel("Level" + level);
            _mainStateMachine.Enter<GameState, LevelConfig>(levelConfig);
        }
    }
}