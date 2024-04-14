using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Infrastructure.Constants;
using Infrastructure.Factories.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Assets;
using Infrastructure.Services.Logging;
using Infrastructure.Services.StaticData.Level;
using ModestTree;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class CargoFactory : ICargoFactory
    {
        private float _spawnDelay;
        private List<SpawnCargoArea> _spawnCargoAreas = new List<SpawnCargoArea>();
        private CancellationTokenSource _cancellationTokenSource;
        private ICurrentLevelConfig _currentLevelConfig;
        private Cargo.Factory _cargoFactory;
        private ILoggingService _loggingService;

        public CargoFactory(ICurrentLevelConfig currentLevelConfig, Cargo.Factory cargoFactory, ILoggingService loggingService)
        {
            _loggingService = loggingService;
            _cargoFactory = cargoFactory;
            _currentLevelConfig = currentLevelConfig;
        }

        public async UniTask WarmUp()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _spawnCargoAreas = Object.FindObjectsOfType<SpawnCargoArea>().ToList();
        }

        public async UniTask SpawnCargo()
        {
            foreach (var area in _spawnCargoAreas)
            {
                await UniTask.WaitForSeconds(_currentLevelConfig.CurrentLevelConfig.SpawnDelay,false,PlayerLoopTiming.Update, _cancellationTokenSource.Token);
                var cargo = _cargoFactory.Create();
                cargo.transform.parent = area.transform;
                cargo.transform.position = area.GetSpawnPoint();
                cargo.transform.rotation = Quaternion.Euler(0, Random.rotation.eulerAngles.y, 0);
            }

            if (_spawnCargoAreas.IsEmpty())
            {
                _loggingService.LogMessage("Not have spawn cargo areas!");
                _cancellationTokenSource.Cancel();
            }
            
            await SpawnCargo();
        }

        public void CleanUp()
        {
            _cancellationTokenSource.Cancel();
            _spawnCargoAreas = null;
        }
    }
}