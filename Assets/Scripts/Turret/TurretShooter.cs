using UnityEngine;

public class TurretShooter : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private float _fireRate = 0.8f;
    private float _timeSinceFire;

    private void Update()
    {
        _timeSinceFire -= Time.deltaTime;

        if (_timeSinceFire <= 0)
        {
            SpawnBullet();
            _timeSinceFire = _fireRate;
        }
    }

    private void SpawnBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = _spawnPoint.position;
        bullet.transform.rotation = _spawnPoint.rotation;
    }
}
