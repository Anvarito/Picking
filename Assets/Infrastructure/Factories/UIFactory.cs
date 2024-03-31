using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Infrastructure.Constants;
using Infrastructure.Services;
using Infrastructure.Services.Assets;
using Infrastructure.Services.Input;
using Infrastructure.Services.StaticData.Level;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Infrastructure.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly DiContainer _container;
        private IAssetLoader _assetLoader;

        private Canvas _uiRoot;
        private IInputService _inputService;
        
        private MouseInputController _mouseInputController;
        private JoystickHandler _joystickHandler;
        private ICurrentLevelConfig _currentLevelConfig;
        private CounterUI _counter;

        public UIFactory(
            DiContainer container,
            IAssetLoader assetLoader,
            ICurrentLevelConfig currentLevelConfig,
            IInputService inputService
        )
        {
            _currentLevelConfig = currentLevelConfig;
            _inputService = inputService;
            _assetLoader = assetLoader;
            _container = container;
        }

        public async UniTask WarmUp()
        {
            CreateInputCanvas();
            CreatePointsCanvas();
        }

        private void CreateInputCanvas()
        {
            _mouseInputController = Object.Instantiate(_assetLoader.Load(AssetPaths.InputCanvas))
                .GetComponentInChildren<MouseInputController>();
            _joystickHandler = Object.Instantiate(_assetLoader.Load(AssetPaths.JoystickCanvas))
                .GetComponentInChildren<JoystickHandler>();

            _mouseInputController.SetUp(_inputService);
            _joystickHandler.SetUp(_inputService);
        }

        private void CreatePointsCanvas()
        {
            GameObject pointsCanvas = Object.Instantiate(_assetLoader.Load(AssetPaths.PointsCanvas));
            _counter = pointsCanvas.GetComponentInChildren<CounterUI>();
            List<UnloadingArea> unloadingAreas = Object.FindObjectsOfType<UnloadingArea>().ToList();
            _counter.WarmUp(unloadingAreas, _currentLevelConfig.CurrentLevelConfig.CargoGoal);
        }

        public void CleanUp()
        {
            Object.Destroy(_joystickHandler.gameObject);
            _counter.CleanUp();
        }
    }
}