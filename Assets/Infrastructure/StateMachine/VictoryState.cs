using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Factory.Base;
using Infrastructure.Factory.Compose;
using Infrastructure.Services.Input;
using Infrastructure.Services.Audio;
using Infrastructure.Services.Progress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.Timer;
using UnityEditor;
using UnityEngine;

namespace Infrastructure.StateMachine
{
    public class VictoryState : IState
    {
        private const string ReloadScene = "ReloadScene";

        private readonly GameStateMachine _gameStateMachine;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IAudioService _audioService;
        private readonly ITimerService _timerService;
        private readonly IProgressService _progress;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IPlayerFactory _playerFactory;
        private readonly IInputService _inputService;
        private readonly IEnemyFactory _enemyFactory;


        public VictoryState(GameStateMachine gameStateMachine, ICoroutineRunner coroutineRunner,
            IAudioService audioService, ITimerService timerService, IInputService inputService, IFactories factories,
            IProgressService progress, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _coroutineRunner = coroutineRunner;
            _audioService = audioService;
            _timerService = timerService;
            _inputService = inputService;
            _progress = progress;
            _saveLoadService = saveLoadService;
            _playerFactory = factories.Single<IPlayerFactory>();
            _enemyFactory = factories.Single<IEnemyFactory>();

        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void Enter()
        {
            throw new NotImplementedException();
        }
    }
}