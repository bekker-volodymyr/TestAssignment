using TestAssignment.Enemies;
using UnityEngine;

namespace TestAssignment.Turret
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 7f;
        [SerializeField] private float _damageValue = 50f;

        private TurretShooter _turret;

        private float _posY;

        private void Start()
        {
            _posY = transform.position.y;
        }

        public void SetTurret(TurretShooter turret)
        {
            _turret = turret;
        }

        void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);

            Vector3 position = transform.position;
            position.y = _posY;
            transform.position = position;

            if (IsOffScreen())
            {
                _turret.ReturnBullet(this);
            }
        }

        private bool IsOffScreen()
        {
            Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

            if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1)
            {
                return true;
            }

            return false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.GetDamage(_damageValue);
                    _turret.ReturnBullet(this);
                }
            }
        }
    }
}
