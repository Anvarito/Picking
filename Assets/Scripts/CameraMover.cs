using UnityEngine;
using Zenject;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    private Transform target;

    [Inject]
    private void Construct(PlayerView playerView)
    {
        target = playerView.transform;
    }
    void Update()
    {
        transform.position = target.position + _offset;
    }
}