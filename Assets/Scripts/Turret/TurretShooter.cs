using UnityEngine;

public class TurretShooter : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private ObjectPool _bullets;

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
        GameObject bullet = _bullets.GetObject();
        bullet.transform.position = _spawnPoint.position;
        bullet.transform.rotation = _spawnPoint.rotation;

        bullet.GetComponent<Bullet>().SetPool(_bullets);
    }
}
