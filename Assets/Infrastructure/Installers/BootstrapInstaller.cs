using Infrastructure.Assets;
using Infrastructure.Factories;
using Infrastructure.SceneManagement;
using Infrastructure.Services.Input;
using Infrastructure.Services.Logging;
using Infrastructure.Services.PersistentData;
using Infrastructure.Services.StaticData;
using Infrastructure.States;
using Zenject;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().AsSingle();
            
            BindServices();
            BindFactories();
        }

        private void BindServices()
        {
            Container.Bind<ILoggingService>().To<LoggingService>().AsSingle().NonLazy();
            Container.Bind<IAssetLoader>().To<AssetLoader>().AsSingle().NonLazy();
            //Container.Bind<IInputService>().To<InputService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle().NonLazy(); // remote, initializable
            Container.BindInterfacesAndSelfTo<PersistentDataService>().AsSingle().NonLazy(); // possible remote, initializable
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }
    }
}