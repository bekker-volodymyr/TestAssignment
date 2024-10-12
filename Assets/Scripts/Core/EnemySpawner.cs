using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _maxCount = 15;
    [SerializeField] private float _spawnRate = 1.4f;
    [SerializeField] private float _spawnDistance = -75f;
    [SerializeField] private ObjectPool _enemies;
    private int _spawnCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);

            if (_spawnCount < _maxCount)
            {
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        //Enemy enemy = Instantiate(_enemyPrefab);
        Enemy enemy = _enemies.GetObject().GetComponent<Enemy>();
        enemy.SetPool(_enemies);
        enemy.transform.position = GameManager.Instance.Player.transform.position;
        enemy.transform.position -= Vector3.forward * _spawnDistance;
        enemy.transform.position += Vector3.left * Random.Range(-35f, 35f);
        _spawnCount++;
    }
}
