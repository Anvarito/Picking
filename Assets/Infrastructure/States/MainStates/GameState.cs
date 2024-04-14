using Infrastructure.SceneManagement;
using Infrastructure.Services.StaticData.Level;

namespace Infrastructure.States.MainStates
{
    public class GameState : IPayloadedState<LevelConfig>
    {
        private readonly SceneLoader _sceneLoader;

        public GameState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async void Enter(LevelConfig stageStaticData)
        {
            await _sceneLoader.Load(stageStaticData.SceneName);
        }

        public void Exit()
        {
        }

        private async void OnLoaded()
        {
            // _pointGoalService.Setup(_pendingStageStaticData);
            // await _cargoFactory.WarmUp();
            // await _uiFactory.WarmUp();
            // await _heroFactory.WarmUp();
            // _stateMachine.Enter<GameLoopState>();
        }
    }
}