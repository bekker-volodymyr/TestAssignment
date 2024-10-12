using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 1.4f;
    [SerializeField] private float _spawnDistance = 75f;   // Distance from player when spawn
    [SerializeField] private float _spawnRangeX = 25f;      // Range for random X position when spawn
    [SerializeField] private ObjectPool _enemies;

    private int _spawnCount = 0;
    private int _maxSpawnCount = 25;

    private void Start()
    {
        _enemies.ObjectReturnedEvent += OnReturnedToPool;

        StartCoroutine(SpawnCoroutine());
    }

    private void OnDestroy()
    {
        _enemies.ObjectReturnedEvent -= OnReturnedToPool;
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(_spawnRate);
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemy = _enemies.GetObject().GetComponent<Enemy>();
        enemy.SetPool(_enemies);
        Vector3 spawnPoint = GameManager.Instance.Player.transform.position;
        spawnPoint += Vector3.forward * _spawnDistance;
        spawnPoint += Vector3.left * Random.Range(-_spawnRangeX, _spawnRangeX);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(spawnPoint, out hit, _spawnDistance, NavMesh.AllAreas))
        {
            Debug.Log($"Spawn Point Hit: {hit.position}");
            enemy.Agent.Warp(hit.position);
            _spawnCount++;
        }
    }

    private void OnReturnedToPool()
    {
        _spawnCount--;
    }
}
