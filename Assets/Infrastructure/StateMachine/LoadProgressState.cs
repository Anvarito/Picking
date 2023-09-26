using Infrastructure.Data;
using Infrastructure.Services.Progress;
using Infrastructure.Services.SaveLoad;

namespace Infrastructure.StateMachine
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, IProgressService progressService, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrCreateNew();
            
            _gameStateMachine.Enter<LoadLevelState, string>(SceneNameCOnstants.GameSceneName);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrCreateNew()
        {
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress() =>
            new(SceneNameCOnstants.GameSceneName);
    }
}