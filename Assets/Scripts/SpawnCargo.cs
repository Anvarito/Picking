using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCargo : MonoBehaviour
{
    [SerializeField] private Cargo _cargoPredab;
    [SerializeField] private Collider _collider;
    [SerializeField] private float _spawnDelay = 0.1f;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        yield return new WaitForSeconds(_spawnDelay);
       var cargo =  Instantiate(_cargoPredab, transform);
        cargo.transform.position = GetSpawnPoint();
        cargo.transform.rotation = Quaternion.Euler(0,Random.rotation.eulerAngles.y,0);
        StartCoroutine(Spawning());
    }

    private Vector3 GetSpawnPoint()
    {
        Bounds bounds = _collider.bounds;

        float spawnX = Random.Range(bounds.min.x, bounds.max.x);
        float spawnZ = Random.Range(bounds.min.z, bounds.max.z);

        Vector3 spawnPoint = new Vector3(spawnX, 0, spawnZ);
        return spawnPoint;
    }
}
