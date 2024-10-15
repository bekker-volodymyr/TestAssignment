using System.Collections.Generic;
using UnityEngine;

public class TurretShooter : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private ObjectPool _bullets;

    [SerializeField] private float _fireRate = 0.8f;
    private float _timeSinceFire;

    private List<GameObject> _spawnedBullets = new List<GameObject>();

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

        _spawnedBullets.Add(bullet);

        bullet.GetComponent<Bullet>().SetTurret(this);
    }

    public void Reset()
    {
        foreach (var bullet in _spawnedBullets)
        {
            _bullets.ReturnObject(bullet);
        }
        _spawnedBullets.Clear();
    }

    internal void ReturnBullet(Bullet bullet)
    {
        _spawnedBullets.Remove(bullet.gameObject);
        _bullets.ReturnObject(bullet.gameObject);
    }
}
