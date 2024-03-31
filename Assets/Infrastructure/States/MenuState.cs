using Infrastructure.Constants;
using Infrastructure.SceneManagement;
using Infrastructure.Services;
using Infrastructure.Services.StaticData.Level;
using UnityEngine;

namespace Infrastructure.States
{
    public class MenuState : IState
    {
        private MenuButtonListener _menuButtonListener;
        private GameStateMachine _gameStateMachine;
        private IStaticDataService _staticDataService;
        private SceneLoader _sceneLoader;

        public MenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader,
            IStaticDataService staticDataService)
        {
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
            _gameStateMachine = gameStateMachine;
        }

        public async void Enter()
        {
            await _sceneLoader.Load(SceneNameConstants.Menu, onLoaded: OnLoaded);
        }

        private void OnLoaded()
        {
            _menuButtonListener = Object.FindObjectOfType<MenuButtonListener>();
            _menuButtonListener.OnButtonClick += LaunchLevel;
        }

        private void LaunchLevel(int levelNumber)
        {
            LevelConfig levelConfig = _staticDataService.ForLevel("Level" + levelNumber);
            _gameStateMachine.Enter<LoadLevelState, LevelConfig>(levelConfig);
        }

        public void Exit()
        {
            _menuButtonListener.OnButtonClick -= LaunchLevel;
            _menuButtonListener = null;
        }
    }
}