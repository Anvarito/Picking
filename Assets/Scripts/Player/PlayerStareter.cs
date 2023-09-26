using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerStareter : MonoBehaviour
{
    [SerializeField] private PlayerView _playerViewPrefab;
    [SerializeField] private InputController _inputController;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private PlayerMoveConfig _playerMoveConfig;
    
    private void Start()
    {
        PlayerView playerView = Instantiate(_playerViewPrefab);
        var playerDataModel = new PlayerDataModel(_playerMoveConfig.Speed,_playerMoveConfig.AngularSpeed);
        PlayerContoller playerContoller = new PlayerContoller(playerView, playerDataModel, _inputController);

        _cameraMover.SetTarget(playerView);
    }

}