using System.Threading.Tasks;
using UnityEngine;
using Data;
using Infrastructure.Factories;
using Infrastructure.SceneManagement;
using Infrastructure.Services.StaticData.Level;
using Zenject;

namespace Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<LevelConfig>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly IHeroFactory _heroFactory;

        private LevelConfig _pendingStageStaticData;

        //private StageProgressData _stageProgressData;

        public LoadLevelState(GameStateMachine gameStateMachine,
            SceneLoader sceneLoader,
            IUIFactory uiFactory,
            IHeroFactory heroFactory)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _heroFactory = heroFactory;
        }

        public async void Enter(LevelConfig stageStaticData)
        {
            _pendingStageStaticData = stageStaticData;
            //_stageProgressData = new StageProgressData();
            await _sceneLoader.Load(SceneNameConstants.GameSceneName, OnLoaded);
        }

        public void Exit()
        {
            _pendingStageStaticData = null;
        }

        private async void OnLoaded()
        {
            await InitUI();
            await InitHero();
            
            _stateMachine.Enter<GameLoopState>();
        }

        private async Task InitHero()
        {
            await _heroFactory.WarmUp();
        }
        private async Task InitUI()
        {
            await _uiFactory.WarmUp();
            // await _uiFactory
            //     .CreateHud()
            //     .ContinueWith(
            //         m => m.Result.Initialize(_pendingStageStaticData, _stageProgressData),
            //         TaskScheduler.FromCurrentSynchronizationContext());
        }

        // private async Task SetupBoard() => 
        //     await _stageFactory.CreateBoard(_pendingStageStaticData.BoardTiles);

        // private async Task<GameObject> SetupHero() => 
        //     await _heroFactory.Create(_pendingStageStaticData.PlayerSpawnPoint);
        //
        // private void SetupCamera(GameObject hero)
        // {
        //     //set up camera follow
        // }
        //
        // private async Task SetupEnemySpawners()
        // {
        //     foreach (var spawnerData in _pendingStageStaticData.EnemySpawners)
        //     {
        //         var spawner = await _stageFactory.CreateEnemySpawner(spawnerData.EnemyType, spawnerData.Position);
        //         _stageProgressData.EnemySpawners.Add(spawner);
        //     }
        // }
    }
}