using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Infrastructure.Constants;
using Infrastructure.Services;
using Infrastructure.Services.Assets;
using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Infrastructure.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly DiContainer _container;
        private readonly IAssetLoader _assetLoader;
        private readonly ICurrentLevelConfig _currentLevelConfig;
        private MouseInputController.Factory _mouseInputControllerFactory;
        private MouseInputController _mouseInputController;
        
        private JoystickHandler.Factory _joystickHandlerFactory;
        private JoystickHandler _joystickHandler;
        private CounterUI _counter;

        public UIFactory(
            DiContainer container,
            IAssetLoader assetLoader,
            ICurrentLevelConfig currentLevelConfig
        )
        {
            _currentLevelConfig = currentLevelConfig;
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
            _container.BindFactory<MouseInputController, MouseInputController.Factory>().FromComponentInNewPrefab(_assetLoader.Load(AssetPaths.InputCanvas));
            _mouseInputControllerFactory = _container.Resolve<MouseInputController.Factory>();
            _mouseInputController = _mouseInputControllerFactory.Create();
            
            _container.BindFactory<JoystickHandler, JoystickHandler.Factory>().FromComponentInNewPrefab(_assetLoader.Load(AssetPaths.JoystickCanvas));
            _joystickHandlerFactory = _container.Resolve<JoystickHandler.Factory>();
            _joystickHandler = _joystickHandlerFactory.Create();
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
            Object.Destroy(_mouseInputController.gameObject);
            _counter.CleanUp();
        }
    }
}