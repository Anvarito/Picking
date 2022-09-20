using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float AngularSpeed;
    [SerializeField] private PlayerAnimator _animator;

    private Vector3 _startMousePosition;
    private Vector3 _newMousePosition;
    private Vector3 _movementDirection;

    private float _normalizedMagnitude;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }

        if (Input.GetMouseButton(0))
        {
            _newMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            _movementDirection = new Vector3(_newMousePosition.x - _startMousePosition.x, 0.0f,
                _newMousePosition.y - _startMousePosition.y);

            _normalizedMagnitude = _movementDirection.magnitude / 100f;
            _normalizedMagnitude = Mathf.Clamp01(_normalizedMagnitude);

            _movementDirection = _movementDirection.normalized * _normalizedMagnitude;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _movementDirection = Vector3.zero;
            _normalizedMagnitude = 0;
        }

        _animator.SetSpeed(_normalizedMagnitude);
        Move();
    }



    private void Move()
    {
        if (_movementDirection != Vector3.zero && _normalizedMagnitude > 0.25)
        {
            _controller.Move(_movementDirection * MoveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_movementDirection),
                AngularSpeed * Time.fixedDeltaTime);
        }

        if (!_controller.isGrounded)
        {
            _controller.Move(Vector3.down * 5 * Time.deltaTime);
        }
    }
}