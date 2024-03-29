using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.Assets;
using Infrastructure.Services;
using Infrastructure.Services.StaticData.Level;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;


namespace Infrastructure.Factories
{
    public class HeroFactory : IHeroFactory
    {
        private readonly DiContainer _container;
        private readonly IAssetLoader _assetProvider;
        private readonly IStaticDataService _staticDataService;
        
        [CanBeNull] public GameObject Hero { get; private set; }
        
        public HeroFactory(DiContainer container, IAssetLoader assetLoader, IStaticDataService staticDataService)
        {
            _container = container;
            _assetProvider = assetLoader;
            _staticDataService = staticDataService;
        }

        public async UniTask WarmUp(LevelConfig pendingStageStaticData)
        {
            var playerView = InstantiatePlayer();
            InstantiateCamera(playerView);
        }

        private PlayerView InstantiatePlayer()
        {
            PlayerView playerView = _assetProvider.LoadAndInstantiate<PlayerView>(AssetPaths.Player);
            Transform spawnPoint = Object.FindObjectOfType<PlayerSpawnPoint>().transform;
            playerView.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
            _container.Bind<IPlayerView>().FromInstance(playerView);

            PlayerDataModel playerDataModel =
                new PlayerDataModel(_staticDataService.ForPlayer.Speed, _staticDataService.ForPlayer.AngularSpeed);
            _container.Bind<IPlayerDataModel>().To<PlayerDataModel>().FromInstance(playerDataModel);
            
            PlayerContoller playerContoller = new PlayerContoller();
            _container.Inject(playerContoller);
            
            return playerView;
        }

        private void InstantiateCamera(PlayerView playerView)
        {
            CameraMover cameraMover = _assetProvider.Instantiate<CameraMover>(AssetPaths.PlayerCamera);
            cameraMover.WarmUp(playerView);
        }

        public void CleanUp()
        {
            Hero = null;
        }

        
    }
}