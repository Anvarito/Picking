using Infrastructure.Services;
using Infrastructure.Services.StaticData.Level;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(GameStateMachine gameStateMachine, IStaticDataService staticDataService)
        {
            _stateMachine = gameStateMachine;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            _stateMachine.Enter<LoadLevelState, LevelConfig>(
                _staticDataService.ForLevel(SceneNameConstants.SceneName));
        }

        public void Exit()
        {
        }
    }
}