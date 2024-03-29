using System;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.Services;
using Infrastructure.Services.Assets;
using Infrastructure.Services.StaticData.Level;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

using Object = UnityEngine.Object;

namespace Infrastructure.Factories
{
    public class EnemyFactory : IEnemyFactory
    {
        private const string EnemyPrefab = "Enemy";
        
        private readonly DiContainer _container;
        private readonly IStaticDataService _staticDataService;
        private readonly IHeroFactory _heroFactory;
        private readonly IAssetLoader _assetLoader;

        public EnemyFactory(
            DiContainer container, 
            IAssetLoader assetLoader, 
            IStaticDataService staticDataService,
            IHeroFactory heroFactory)
        {
            _assetLoader = assetLoader;
            _container = container;
            _staticDataService = staticDataService;
            _heroFactory = heroFactory;
        }


        public async UniTask WarmUp(LevelConfig pendingStageStaticData)
        {
            //_assetLoader.LoadAndInstantiateAsync(EnemyPrefab, null, Create);
        }

        private void Create(GameObject enemy)
        {
        }

        public void CleanUp()
        {
        }
    }
}