using System.Collections.Generic;
using TestAssignment.Utils;
using UnityEngine;

namespace TestAssignment.Turret
{
    public class TurretShooter : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnPoint;

        private ObjectPool<Bullet> _pool;

        [SerializeField] private float _fireRate = 0.8f;
        private float _timeSinceFire;

        private List<Bullet> _spawnedBullets = new List<Bullet>();

        private void Start()
        {
            _pool = new ObjectPool<Bullet>(_bulletPrefab);
        }

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
            Bullet bullet = _pool.GetObject();

            if (bullet != null)
            {
                bullet.transform.position = _spawnPoint.position;
                bullet.transform.rotation = _spawnPoint.rotation;

                _spawnedBullets.Add(bullet);

                bullet.SetTurret(this);
            }
            else
            {
                Debug.Log("Failed to recive object from pool");
            }
        }

        public void Reset()
        {
            foreach (var bullet in _spawnedBullets)
            {
                _pool.ReturnObject(bullet);
            }
            _spawnedBullets.Clear();
        }

        internal void ReturnBullet(Bullet bullet)
        {
            _pool.ReturnObject(bullet);
            _spawnedBullets.Remove(bullet);
        }
    }
}
