using System;
using System.Collections.Generic;
using Infrastructure.Factories.StateFactories;
using Infrastructure.Services.Logging;
using Infrastructure.States.InGameStates;
using Zenject;

namespace Infrastructure.States.StateMachines
{
    public class GameStateMachine : StateMachineBase, IInitializable
    {
        private GameStateFactory _gameStateFactory;

        public GameStateMachine(GameStateFactory gameStateFactory, ILoggingService loggingService) : base(loggingService)
        {
            _gameStateFactory = gameStateFactory;
        }

        public void Initialize()
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(GameWarmUp)]    = _gameStateFactory.CreateState<GameWarmUp>(),
                [typeof(GameLoop)]    = _gameStateFactory.CreateState<GameLoop>(),
                [typeof(GameVictory)]    = _gameStateFactory.CreateState<GameVictory>(),
            };
            
            Enter<GameWarmUp>();
        }
    }
}