using System.Collections.Generic;
using UnityEngine;

namespace TestAssignment.Turret
{
    public class TurretShooter : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private BulletsPool _bulletsPool;

        [SerializeField] private float _fireRate = 0.8f;
        private float _timeSinceFire;

        private List<Bullet> _spawnedBullets = new List<Bullet>();

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
            Bullet bullet = _bulletsPool.GetObject();
            bullet.transform.position = _spawnPoint.position;
            bullet.transform.rotation = _spawnPoint.rotation;

            _spawnedBullets.Add(bullet);

            bullet.SetTurret(this);
        }

        public void Reset()
        {
            foreach (var bullet in _spawnedBullets)
            {
                _bulletsPool.ReturnObject(bullet);
            }
            _spawnedBullets.Clear();
        }

        internal void ReturnBullet(Bullet bullet)
        {
            _spawnedBullets.Remove(bullet);
            _bulletsPool.ReturnObject(bullet);
        }
    }
}
