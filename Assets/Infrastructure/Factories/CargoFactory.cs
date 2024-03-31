using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Infrastructure.Constants;
using Infrastructure.Factories.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Assets;
using Infrastructure.Services.StaticData.Level;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class CargoFactory : ICargoFactory
    {
        private IAssetLoader _assetLoader;
        private Cargo _cargoPrefab;
        private float _spawnDelay;
        private List<SpawnCargoArea> _spawnCargoAreas = new List<SpawnCargoArea>();
        private CancellationTokenSource _cancellationTokenSource;
        private ICurrentLevelConfig _currentLevelConfig;

        public CargoFactory(IAssetLoader assetLoader, ICurrentLevelConfig currentLevelConfig)
        {
            _currentLevelConfig = currentLevelConfig;
            _assetLoader = assetLoader;
        }

        public async UniTask WarmUp()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _spawnCargoAreas = Object.FindObjectsOfType<SpawnCargoArea>().ToList();
            _cargoPrefab = await _assetLoader.LoadAsset<Cargo>(AssetPaths.Cargo);
        }

        public async UniTask SpawnCargo()
        {
            foreach (var area in _spawnCargoAreas)
            {
                await UniTask.WaitForSeconds(_currentLevelConfig.CurrentLevelConfig.SpawnDelay,false,PlayerLoopTiming.Update, _cancellationTokenSource.Token);
                var cargo = Object.Instantiate(_cargoPrefab, area.transform);
                cargo.transform.position = area.GetSpawnPoint();
                cargo.transform.rotation = Quaternion.Euler(0, Random.rotation.eulerAngles.y, 0);
            }

            await SpawnCargo();
        }

        public void StopSpawnCargo()
        {
            _cancellationTokenSource.Cancel();
        }

        public void CleanUp()
        {
            _spawnCargoAreas = null;
            _cargoPrefab = null;
        }
    }
}