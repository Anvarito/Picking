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
            PlayerView playerView = Container.InstantiatePrefabForComponent<PlayerView>(HeroPrefab, SpawnPoint.position,SpawnPoint.rotation,null);
            Container.Bind<PlayerView>().FromInstance(playerView);
            PlayerDataModel playerDataModel = new PlayerDataModel(PlayerMoveConfig.Speed, PlayerMoveConfig.AngularSpeed);
            InputController inputController = Container.Resolve<InputController>();
            PlayerContoller playerContoller = new PlayerContoller(playerView, playerDataModel,inputController );
            Container.Bind<PlayerContoller>().FromInstance(playerContoller);
        }
    }
}