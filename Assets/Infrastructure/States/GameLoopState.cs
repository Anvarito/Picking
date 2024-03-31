using Infrastructure.Factories;
using Infrastructure.Factories.Interfaces;
using Infrastructure.Services.PointGoal;
using UnityEngine;

namespace Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IHeroFactory _heroFactory;

        private ICargoFactory _cargoFactory;

        private IPointGoalService _pointGoalService;

        private IUIFactory _uiFactory;
        //private readonly ILevelProgressService _levelProgressService;

        public GameLoopState(
            GameStateMachine gameStateMachine,
            IHeroFactory heroFactory, 
            IEnemyFactory enemyFactory,
            ICargoFactory cargoFactory,
            IPointGoalService pointGoalService,
            IUIFactory uiFactory
            //ILevelProgressService levelProgressService)
            )
        {
            _uiFactory = uiFactory;
            _pointGoalService = pointGoalService;
            _cargoFactory = cargoFactory;
            _stateMachine = gameStateMachine;
            _heroFactory = heroFactory;
            _enemyFactory = enemyFactory;
           // _levelProgressService = levelProgressService;
        }

        public void Enter()
        {
            //_levelProgressService.LevelProgressWatcher.RunLevel();
            _pointGoalService.OnPointsGoal += PointGoal;
            _cargoFactory.SpawnCargo();
        }

        private void PointGoal()
        {
            Debug.Log("POINT GOAL");
            _stateMachine.Enter<VictoryState>();
        }

        public void Exit()
        {
            // release enemies' assets there instead on exit from LLS coz they can respawn by timer
            _pointGoalService.OnPointsGoal -= PointGoal;
            _pointGoalService.CleanUp();
            _cargoFactory.CleanUp();
            _enemyFactory.CleanUp();
            _heroFactory.CleanUp();
            _uiFactory.CleanUp();
        }
    }
}