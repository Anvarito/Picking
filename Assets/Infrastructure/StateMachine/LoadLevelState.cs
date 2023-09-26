using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Assets;
using Infrastructure.Components;
using Infrastructure.Factory.Base;
using Infrastructure.Factory.Compose;
using Infrastructure.Services;
using Infrastructure.Services.Audio;
using Infrastructure.Services.Progress;
using Infrastructure.Services.Score;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.StaticData.SpawnPoints;
using UnityEngine;

namespace Infrastructure.StateMachine
{
    public class LoadLevelState
        : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IAudioService _audioService;
        private readonly IProgressService _progress;
        private readonly IStaticDataService _dataService;
        private readonly IFactories _factories;
        private readonly IScoreCounter _scoreCounter;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IPlayerFactory _playerFactory;
        //private List<SpawnPointConfig> _configs;
       // private GamemodeConfig _modeConfig;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IAudioService audioService,
            IProgressService progress,
            IStaticDataService dataService, IFactories factories,
            IScoreCounter scoreCounter)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _audioService = audioService;
            _progress = progress;
            _dataService = dataService;
            _factories = factories;
            _scoreCounter = scoreCounter;
            _playerFactory = factories.Single<IPlayerFactory>();
            _enemyFactory = factories.Single<IEnemyFactory>();
        }

        public void Enter(string levelName)
        {
            _scoreCounter.CleanUp();
            _playerFactory.CleanUp();
            _enemyFactory.CleanUp();
            _progress.Progress.WorldData.Level = levelName;
            _sceneLoader.Load(name: levelName, OnLoaded, OnProgress);
        }

        private void OnProgress(float progress)
        {
            //_loadingVisualizer.ShowLoadbar(progress);
        }

        public void Exit()
        {
            //_configs.Clear();
        }
    
        private void OnLoaded()
        {
            //_loadingVisualizer.HideLoadbar();
            //FetchModeData();
            InitGameLevel();

           // _audioService.PlayMusic(MusicId.Battle1);

            _gameStateMachine.Enter<GameLoopState>();
        }


       // private void FetchModeData() =>
            //_modeConfig = _dataService.ForMode(_progress.Progress.WorldData.ModeId);

        private void InitGameLevel()
        {
        }
    }
}