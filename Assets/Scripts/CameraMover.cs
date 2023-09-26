using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    private Transform target;

    void Update()
    {
        transform.position = target.position + _offset;
    }

    public void SetTarget(PlayerView playerView)
    {
        target = playerView.transform;
    }
}