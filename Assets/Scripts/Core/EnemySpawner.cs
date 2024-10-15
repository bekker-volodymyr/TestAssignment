using System.Collections;
using System.Collections.Generic;
using TestAssignment.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace TestAssignment.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnRate = 1.4f;
        [SerializeField] private float _spawnDistance = 75f;    // Distance from player when spawn
        [SerializeField] private float _spawnRandRangeX = 25f;
        [SerializeField] private EnemyPool _enemyPool;

        private List<Enemy> _spawnedEnemies = new List<Enemy>();

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
            Enemy enemy = _enemyPool.GetObject();
            enemy.SetSpawner(this);
            Vector3 spawnPoint = GameManager.Instance.Player.transform.position;
            spawnPoint += Vector3.forward * _spawnDistance;
            spawnPoint += Vector3.left * Random.Range(-_spawnRandRangeX, _spawnRandRangeX);

            NavMeshHit hit;
            if (NavMesh.SamplePosition(spawnPoint, out hit, _spawnDistance, NavMesh.AllAreas))
            {
                enemy.Agent.Warp(hit.position);
                _spawnCount++;
            }

            enemy.InitEnemy();

            _spawnedEnemies.Add(enemy);
        }

        public void Reset()
        {
            foreach (var enemy in _spawnedEnemies)
            {
                _enemyPool.ReturnObject(enemy);
            }
            _spawnedEnemies.Clear();
        }

        public void ReturnEnemy(Enemy enemy)
        {
            _spawnedEnemies.Remove(enemy);
            _enemyPool.ReturnObject(enemy);
            _spawnCount--;
        }
    }
}
