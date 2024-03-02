using Infrastructure.Assets;
using Infrastructure.Services.Input;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public GameObject CanvasPrefab;
        private AssetLoader AssetLoader;
        public override void InstallBindings()
        {
            BindAssetLoader();
            BindInputService();
        }

        private void BindAssetLoader()
        {
            AssetLoader = new AssetLoader();
            Container
                .Bind<AssetLoader>()
                .FromInstance(AssetLoader)
                .AsSingle();
        }

        private void BindInputService()
        {
           Container.Bind<IInputService>().To<InputController>().FromComponentInNewPrefab(CanvasPrefab).AsSingle();
        }
    }
}