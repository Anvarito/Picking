using Infrastructure.Constants;
using Infrastructure.Factories;
using Infrastructure.Factories.Interfaces;
using Infrastructure.Services.Assets;
using Infrastructure.Services.PointGoal;
using Infrastructure.States.MainStates;
using Infrastructure.States.StateMachines;
using UnityEngine;

namespace Infrastructure.States.InGameStates
{
    public class GameVictory : IState
    {
        private IUIFactory _uiFactory;
        private PlayerContoller _playerContoller;
        private IAssetLoader _assetLoader;
        private MainStateMachine _mainStateMachine;

        public GameVictory(
            MainStateMachine mainStateMachine
            , IUIFactory uiFactory
            , PlayerContoller playerContoller
            , IAssetLoader assetLoader
        )
        {
            _mainStateMachine = mainStateMachine;
            _assetLoader = assetLoader;
            _playerContoller = playerContoller;
            _uiFactory = uiFactory;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            VictoryScreen canvas = _assetLoader.Instantiate<VictoryScreen>(AssetPaths.VictoryCanvas);
            canvas.OnCLick += PressAccepted;
           
           
            _playerContoller.Dispose();
            _uiFactory.CleanUp();
        }

        private void PressAccepted()
        {
            _mainStateMachine.Enter<MenuState>();
        }
    }
}