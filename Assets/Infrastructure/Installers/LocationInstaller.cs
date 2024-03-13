using Infrastructure.Assets;
using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        public Transform SpawnPoint;
        public PlayerMoveConfig PlayerMoveConfig;
        public override void InstallBindings()
        {
            BindPlayer();
            BindPointCanvas();
        }

        private void BindPlayer()
        {
            IPlayerView playerView = Container.InstantiatePrefabResourceForComponent<IPlayerView>(AssetPaths.Player, SpawnPoint);
            Container.Bind<IPlayerView>().FromInstance(playerView);
            PlayerDataModel playerDataModel =
                new PlayerDataModel(PlayerMoveConfig.Speed, PlayerMoveConfig.AngularSpeed);
            Container.Bind<IPlayerDataModel>().To<PlayerDataModel>().FromInstance(playerDataModel);
            Container.Bind<PlayerContoller>().AsSingle().NonLazy();
        }

        private void BindPointCanvas()
        {
            Container.InstantiatePrefabResourceForComponent<CounterUI>(AssetPaths.PointsCanvas);
        }
    }
}