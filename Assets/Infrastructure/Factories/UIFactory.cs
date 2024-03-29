using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Infrastructure.Assets;
using Infrastructure.Services;
using Infrastructure.Services.Input;
using Infrastructure.Services.StaticData.Level;
using UnityEngine;
using Zenject;

namespace Infrastructure.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly DiContainer _container;
        private IAssetLoader _assetLoader;
        private readonly IStaticDataService _staticDataService;

        private Canvas _uiRoot;

        public UIFactory(
            DiContainer container, 
            IAssetLoader assetLoader,
            IStaticDataService staticDataService 
        )
        {
            _assetLoader = assetLoader;
            _container = container;
            _staticDataService = staticDataService;
        }

        public async UniTask WarmUp(LevelConfig pendingStageStaticData)
        {
            await _assetLoader.LoadAsset(AssetPaths.InputCanvas, null, OnLoadInputCanvas);
            CreatePointsCanvas();
        }
        private void OnLoadInputCanvas(GameObject inputCanvas)
        {
            GameObject canvasGameObject = Object.Instantiate(inputCanvas);
            MouseInputController mouseInputController = canvasGameObject.GetComponentInChildren<MouseInputController>();
            _container.Bind<IInputService>().FromInstance(mouseInputController).AsSingle().NonLazy();

            GameObject joysticCanvas = Object.Instantiate(_assetLoader.Load(AssetPaths.JoystickCanvas));
            JoystickHandler Joystick = joysticCanvas.GetComponentInChildren<JoystickHandler>();
            Joystick.WarmUp(mouseInputController);
        }

        private void CreatePointsCanvas()
        {
            GameObject pointsCanvas = Object.Instantiate(_assetLoader.Load(AssetPaths.PointsCanvas));
            CounterUI counter = pointsCanvas.GetComponentInChildren<CounterUI>();
            List<UnloadingArea> unloadingAreas = Object.FindObjectsOfType<UnloadingArea>().ToList();
            counter.WarmUp(unloadingAreas);
        }

        public void CleanUp()
        {
            
        }
    }
}