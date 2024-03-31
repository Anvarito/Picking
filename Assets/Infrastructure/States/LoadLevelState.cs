using Infrastructure.Factories;
using Infrastructure.Factories.Interfaces;
using Infrastructure.SceneManagement;
using Infrastructure.Services.PointGoal;
using Infrastructure.Services.StaticData.Level;

namespace Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<LevelConfig>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly IHeroFactory _heroFactory;

        private LevelConfig _pendingStageStaticData;
        private ICargoFactory _cargoFactory;
        private IPointGoalService _pointGoalService;

        //private StageProgressData _stageProgressData;

        public LoadLevelState(GameStateMachine gameStateMachine,
            SceneLoader sceneLoader,
            IUIFactory uiFactory,
            IHeroFactory heroFactory,
            ICargoFactory cargoFactory,
            IPointGoalService pointGoalService)
        {
            _pointGoalService = pointGoalService;
            _cargoFactory = cargoFactory;
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _heroFactory = heroFactory;
        }

        public async void Enter(LevelConfig stageStaticData)
        {
            _pendingStageStaticData = stageStaticData;
            //_stageProgressData = new StageProgressData();
            await _sceneLoader.Load(stageStaticData.SceneName, OnLoaded);
        }

        public void Exit()
        {
            _pendingStageStaticData = null;
        }

        private async void OnLoaded()
        {
            _pointGoalService.Setup(_pendingStageStaticData);
            await _cargoFactory.WarmUp();
            await _uiFactory.WarmUp();
            await _heroFactory.WarmUp();
            _stateMachine.Enter<GameLoopState>();
        }
    }
}