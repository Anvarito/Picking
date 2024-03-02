using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerContoller
{
    private IPlayerDataModel _playerDataModel;
    private IPlayerView _playerView;

    private InputController _inputController;

    private Vector3 _startMousePosition;
    private Vector3 _newMousePosition;
    private Vector3 _movementDirection;
    private float _normalizedMagnitude;

    public PlayerContoller(IPlayerView playerView, IPlayerDataModel playerDataModel, InputController inputController)
    {
        _playerView = playerView;
        _playerDataModel = playerDataModel;

        _inputController = inputController;

        _inputController.OnDragHandle += OnDrag;
        _inputController.OnEndDragHandle += OnEndDrag;
        _inputController.OnPointerDownHandle += OnPointerDown;
        _inputController.OnPointerUpHandle += OnPointerUp;
        
        _playerView.SetAnimationSpeed(0);
    }

    private void OnPointerUp(PointerEventData direction)
    {
        _movementDirection = Vector3.zero;
        _normalizedMagnitude = 0;
        _playerView.SetAnimationSpeed(0);
    }

    private void OnPointerDown(PointerEventData direction)
    {
        _startMousePosition = new Vector3(direction.position.x, direction.position.y, 0);
    }

    private void OnEndDrag(PointerEventData direction)
    {
    }

    private void OnDrag(PointerEventData direction)
    {
        _newMousePosition = new Vector3(direction.position.x, direction.position.y, 0);
        _movementDirection = new Vector3(_newMousePosition.x - _startMousePosition.x, 0.0f,
            _newMousePosition.y - _startMousePosition.y);

        _normalizedMagnitude = _movementDirection.magnitude / 100f;
        _normalizedMagnitude = Mathf.Clamp01(_normalizedMagnitude);

        _movementDirection = _movementDirection.normalized * _normalizedMagnitude;

        Move();
    }

    private void Move()
    {
        if (_movementDirection == Vector3.zero && _normalizedMagnitude > 0.25)
        {
            _movementDirection = Vector3.zero;
        }

        _playerView.Move(_movementDirection * (_playerDataModel.MoveSpeed * Time.deltaTime));
        _playerView.Rotating(Quaternion.Slerp(_playerView.Transform.rotation,
            Quaternion.LookRotation(_movementDirection), _playerDataModel.AngularSpeed * Time.fixedDeltaTime));

        _playerView.SetAnimationSpeed(_normalizedMagnitude);
    }
}