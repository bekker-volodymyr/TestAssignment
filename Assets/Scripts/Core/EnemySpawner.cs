using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 1.4f;
    [SerializeField] private float _spawnDistance = 75f;   // Distance from player when spawn
    [SerializeField] private float _spawnRangeX = 25f;      // Range for random X position when spawn
    [SerializeField] private ObjectPool _enemies;

    private List<GameObject> _spawnedEnemies = new List<GameObject>();

    private int _spawnCount = 0;
    private int _maxSpawnCount = 25;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
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
        enemy.SetSpawner(this);
        Vector3 spawnPoint = GameManager.Instance.Player.transform.position;
        spawnPoint += Vector3.forward * _spawnDistance;
        spawnPoint += Vector3.left * Random.Range(-_spawnRangeX, _spawnRangeX);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(spawnPoint, out hit, _spawnDistance, NavMesh.AllAreas))
        {
            enemy.Agent.Warp(hit.position);
            _spawnCount++;
        }

        enemy.InitEnemy();

        _spawnedEnemies.Add(enemy.gameObject);
    }

    public void Reset()
    {
        foreach (var enemy in _spawnedEnemies)
        {
            _enemies.ReturnObject(enemy.gameObject);
        }
        _spawnedEnemies.Clear();
    }

    internal void ReturnEnemy(Enemy enemy)
    {
        _spawnedEnemies.Remove(enemy.gameObject);
        _enemies.ReturnObject(enemy.gameObject);
    }
}
