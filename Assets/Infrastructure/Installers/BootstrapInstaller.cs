using Infrastructure.Assets;
using Infrastructure.Services.Input;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        private AssetLoader _assetLoader;
        public override void InstallBindings()
        {
            BindAssetLoader();
            BindInputService();
        }

        private void BindAssetLoader()
        {
            _assetLoader = new AssetLoader();
            Container
                .Bind<AssetLoader>()
                .FromInstance(_assetLoader)
                .AsSingle();
        }

        private void BindInputService()
        {
           Container.Bind<IInputService>().To<InputController>().FromComponentInNewPrefabResource(AssetPaths.Input).AsSingle();
        }
    }
}