using UnityEngine;
using Zenject;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    private IPlayerView _playerView;

    [Inject]
    public void WarmUp(IPlayerView playerView)
    {
        _playerView = playerView;
    }
    void Update()
    {
        transform.position = _playerView.Transform.position + _offset;
    }
}