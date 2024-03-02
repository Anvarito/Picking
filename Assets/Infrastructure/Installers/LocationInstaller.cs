using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        public Transform SpawnPoint;
        public GameObject HeroPrefab;
        public PlayerMoveConfig PlayerMoveConfig;

        public override void InstallBindings()
        {
            BindPlayer();
        }

        private void BindPlayer()
        {
            IPlayerView playerView = Container.InstantiatePrefabForComponent<PlayerView>(HeroPrefab, SpawnPoint.position, SpawnPoint.rotation, null);
            Container.Bind<IPlayerView>().FromInstance(playerView);
            
            PlayerDataModel playerDataModel =
                new PlayerDataModel(PlayerMoveConfig.Speed, PlayerMoveConfig.AngularSpeed);
            
            IInputService inputController = Container.Resolve<IInputService>();
            PlayerContoller playerContoller = new PlayerContoller(playerView, playerDataModel, inputController);
            
            Container.Bind<PlayerContoller>().FromInstance(playerContoller);
        }
    }
}