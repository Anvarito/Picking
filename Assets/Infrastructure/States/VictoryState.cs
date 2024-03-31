using Infrastructure.Constants;
using Infrastructure.Factories.Interfaces;
using Infrastructure.Services.Assets;
using UnityEngine;

namespace Infrastructure.States
{
    public class VictoryState : IState
    {
        private ICargoFactory _cargoFactory;
        private VictoryScreen _menuButton;
        private GameStateMachine _gameStateMachine;
        private IAssetLoader _assetLoader;

        public VictoryState(ICargoFactory cargoFactory, GameStateMachine gameStateMachine, IAssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
            _gameStateMachine = gameStateMachine;
            _cargoFactory = cargoFactory;
        }
        public void Exit()
        {
            _menuButton.OnCLick -= ToMenu;
        }

        public async void Enter()
        {
            Debug.Log("VICTORY");
            _cargoFactory.StopSpawnCargo();
            _menuButton = await _assetLoader.LoadAndInstantiateAsync<VictoryScreen>(AssetPaths.VictoryCanvas);
            _menuButton.OnCLick += ToMenu;
        }

        private void ToMenu()
        {
            _gameStateMachine.Enter<MenuState>();
        }
    }
}