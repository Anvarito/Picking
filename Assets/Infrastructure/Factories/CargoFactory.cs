using Cysharp.Threading.Tasks;
using Infrastructure.Assets;
using Infrastructure.Factories.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Infrastructure.Factories
{
    public class CargoFactory : ICargoFactory
    {
        private AssetLoader _assetLoader;
        private Cargo _cargoPrefab;
        private float _spawnDelay;
        public CargoFactory(AssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
        }
        public async UniTask WarmUp()
        {
           await UniTask.Yield();
           _cargoPrefab = await _assetLoader.LoadAsset<Cargo>(AssetPaths.Cargo);
        }
        public async UniTask SpawnCargo()
        {
            // UniTask.WaitForSeconds(_spawnDelay);
            // var cargo = Object.Instantiate(_cargoPrefab, transform);
            // cargo.transform.position = GetRandomSpawnPoint();
            // cargo.transform.rotation = Quaternion.Euler(0,Random.rotation.eulerAngles.y,0);
            await SpawnCargo();
        }
        // private Vector3 GetRandomSpawnPoint()
        // {
        //     Bounds bounds = _collider.bounds;
        //
        //     float spawnX = Random.Range(bounds.min.x, bounds.max.x);
        //     float spawnZ = Random.Range(bounds.min.z, bounds.max.z);
        //
        //     Vector3 spawnPoint = new Vector3(spawnX, 0, spawnZ);
        //     return spawnPoint;
        // }
        public void CleanUp()
        {
        }
    }
}