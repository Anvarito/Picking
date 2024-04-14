using Infrastructure.Factories.Interfaces;
using Infrastructure.Services.PointGoal;
using Infrastructure.States.StateMachines;

namespace Infrastructure.States.InGameStates
{
    public class GameLoop: IState
    {
        private ICargoFactory _cargoFactory;
        private IPointGoalService _pointGoalService;
        private GameStateMachine _gameStateMachine;


        public GameLoop(GameStateMachine gameStateMachine,ICargoFactory cargoFactory, IPointGoalService pointGoalService)
        {
            _gameStateMachine = gameStateMachine;
            _pointGoalService = pointGoalService;
            _cargoFactory = cargoFactory;
        }
       

        public void Exit()
        {
            _pointGoalService.OnPointsGoal -= OnPointsGoal;
            _pointGoalService.CleanUp();
            _cargoFactory.CleanUp();
        }

        public void Enter()
        {
            _pointGoalService.OnPointsGoal += OnPointsGoal;
            _cargoFactory.SpawnCargo();
        }

        private void OnPointsGoal()
        {
            _gameStateMachine.Enter<GameVictory>();
        }
    }
}