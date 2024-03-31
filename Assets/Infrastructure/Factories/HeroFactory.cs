using Cysharp.Threading.Tasks;
using Infrastructure.Constants;
using Infrastructure.Services;
using Infrastructure.Services.Assets;
using Infrastructure.Services.Input;
using UnityEngine;


namespace Infrastructure.Factories
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IAssetLoader _assetProvider;
        private readonly IStaticDataService _staticDataService;
        
        private IPlayerView _playerView;
        private PlayerDataModel _playerDataModel;
        private PlayerContoller _playerContoller;

        private PlayerView _playerViewPrefab;
        private CameraMover _cameraMover;
        private IInputService _inputService;
        public GameObject Hero { get; }

        public HeroFactory(IAssetLoader assetLoader, IStaticDataService staticDataService, IInputService inputService)
        {
            _inputService = inputService;
            _assetProvider = assetLoader;
            _staticDataService = staticDataService;
        }

        public async UniTask WarmUp()
        {
            if (_playerViewPrefab == null)
                _playerViewPrefab = await _assetProvider.LoadAsset<PlayerView>(AssetPaths.Player);
            
            InstantiatePlayer();
            InstantiateCamera();
        }

        private void InstantiatePlayer()
        {
            _playerView = Object.Instantiate(_playerViewPrefab);
            Transform spawnPoint = Object.FindObjectOfType<PlayerSpawnPoint>().transform;
            _playerView.Transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);

            _playerDataModel = new PlayerDataModel(_staticDataService.ForPlayer.Speed,
                _staticDataService.ForPlayer.AngularSpeed);

            _playerContoller = new PlayerContoller(_playerView, _playerDataModel, _inputService);
        }

        private void InstantiateCamera()
        {
            _cameraMover = _assetProvider.Instantiate<CameraMover>(AssetPaths.PlayerCamera);
            _cameraMover.WarmUp(_playerView);
        }

        public void CleanUp()
        {
            _playerDataModel = null;
            _playerContoller.Dispose();
            _playerContoller = null;
        }

    }
}