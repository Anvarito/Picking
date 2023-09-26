using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Assets;
using Infrastructure.Components;
using Infrastructure.Factory.Base;
using Infrastructure.Services.Audio;
using Infrastructure.Services.Input;
using Infrastructure.Services.Progress;
using Infrastructure.Services.Score;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.StaticData.SpawnPoints;
using Infrastructure.Services.Timer;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class PlayerFactory : GameFactory, IPlayerFactory
    {
        private readonly IInputService _inputService;
        private readonly IProgressService _progressService;
        private readonly IStaticDataService _dataService;
        private readonly ITimerService _timer;
        private readonly IScoreCounter _scoreCounter;


        public PlayerFactory(IAudioService audioService, IAssetLoader assetLoader, IInputService inputService,
            IProgressService progressService, IStaticDataService dataService, ITimerService timer,
            IScoreCounter scoreCounter) : base(audioService, assetLoader)
        {
            _inputService = inputService;
            _progressService = progressService;
            _dataService = dataService;
            _timer = timer;
            _scoreCounter = scoreCounter;
        }

        public override void CleanUp()
        {
            base.CleanUp();
        }

        public void CreatePlayers(List<SpawnPointConfig> points)
        {
            
        }
    }
}