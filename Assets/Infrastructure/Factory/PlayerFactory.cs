using Infrastructure.Assets;
using Infrastructure.Factory.Base;
using Infrastructure.Services.Input;
using Infrastructure.Services.Score;
using Infrastructure.Services.StaticData;

namespace Infrastructure.Factory
{
    public class PlayerFactory : GameFactory, IPlayerFactory
    {
        private readonly IAssetLoader _assetLoader;
        private readonly IInputService _inputService;
        private readonly IStaticDataService _dataService;
        private readonly IScoreCounter _scoreCounter;


        public PlayerFactory(IAssetLoader assetLoader, IInputService inputService,
            IStaticDataService dataService,
            IScoreCounter scoreCounter) : base(assetLoader)
        {
            _assetLoader = assetLoader;
            _inputService = inputService;
            _dataService = dataService;
            _scoreCounter = scoreCounter;
        }

        public void CreatePlayer()
        {
            // var playerView = _assetLoader.Instantiate<PlayerView>(AssetPaths.Player);
            // var playerDataModel = new PlayerDataModel(_playerMoveConfig.Speed, _playerMoveConfig.AngularSpeed);
            // PlayerContoller playerContoller = new PlayerContoller(playerView, playerDataModel, _inputController);
        }
    }
}