using System;
using Infrastructure.Factory.Base;
using Infrastructure.Factory.Compose;
using Infrastructure.Services.StaticData;

namespace Infrastructure.Services.KillCounter
{
    public class KillCounter : IKillCounter
    {
        private readonly IStaticDataService _dataService;
        public Action OnEnemiesDestroyed { get; set; }
        public Action OnPlayersDestroyed { get; set; }

        public int PlayersDestroyed { get; private set; }
        public int EnemiesDestroyed { get; private set; }

        private readonly IEnemyFactory _enemyFactory;
        private readonly IPlayerFactory _playerFactory;

        public KillCounter(IFactories factories )
        {
            
            _enemyFactory = factories.Single<IEnemyFactory>();
            _playerFactory = factories.Single<IPlayerFactory>();
            
            Subscribe();
        }

        private void Subscribe()
        {
            
        }

        private void Unsubscribe()
        {
            
        }
        

        public void CleanUp()
        {
            PlayersDestroyed = 0;
            EnemiesDestroyed = 0;
        }
    }
}