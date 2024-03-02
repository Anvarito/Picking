using System;
using System.Collections.Generic;
using Infrastructure.Factory.Base;
using Infrastructure.Factory.Compose;
using Infrastructure.Services.StaticData;

namespace Infrastructure.Services.Score
{
    public class ScoreCounter : IScoreCounter
    {
        public float ScorePlayerOne { get; private set; }
        public float ScorePlayerTwo { get; private set; }
        public List<float> Scores => new List<float> { ScorePlayerOne,ScorePlayerTwo};
        public Action<int> OnEnemiesDestroyed { get; set; }

       
        private readonly IStaticDataService _dataService;
        private readonly IEnemyFactory _enemyFactory;
        //private GamemodeConfig _modeConfig;
        public ScoreCounter(IFactories factories, IStaticDataService dataService)
        {
           
            _dataService = dataService;
            _enemyFactory = factories.Single<IEnemyFactory>();
        }

        //public void LoadData() =>
          //  _modeConfig = _dataService.ForMode(_progress.Progress.WorldData.ModeId);

        public void CleanUp()
        {
            ScorePlayerOne = 0;
            ScorePlayerTwo = 0;
        }
    }
}