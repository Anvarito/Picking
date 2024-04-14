using Infrastructure.Factories;
using Infrastructure.Factories.Interfaces;
using Infrastructure.Services.PointGoal;
using Infrastructure.States.StateMachines;

namespace Infrastructure.States.InGameStates
{
    public class GameWarmUp : IState
    {
        private readonly ICargoFactory _cargoFactory;
        private readonly IUIFactory _uiFactory;
        private GameStateMachine _gameStateMachine;
        private IPointGoalService _pointGoalService;

        public GameWarmUp(
            GameStateMachine gameStateMachine,
            ICargoFactory cargoFactory
            , IUIFactory uiFactory,
            IPointGoalService pointGoalService
            )
        {
            _pointGoalService = pointGoalService;
            _gameStateMachine = gameStateMachine;
            _cargoFactory = cargoFactory;
            _uiFactory = uiFactory;
        }

        public void Exit()
        {
            
        }

        public void Enter()
        {
            _pointGoalService.WarmUp();
            _cargoFactory.WarmUp();
            _uiFactory.WarmUp();
            
            _gameStateMachine.Enter<GameLoop>();
        }
    }
}