using System;
using TestAssignment.Effects;
using TestAssignment.UI;
using UnityEngine;

namespace TestAssignment.Car
{
    public class CarHealth : MonoBehaviour
    {
        private float _maxHealth = 100f;
        private float _currentHealth;

        [SerializeField] private HealthBar _healthBar;

        public event Action CarDeathEvent;

        private void Start()
        {
            Reset();
        }

        public void Reset()
        {
            gameObject.SetActive(true);

            _currentHealth = _maxHealth;
            _healthBar.SetValue(_currentHealth, _maxHealth);
        }

        public void GetDamage(float damageValue)
        {
            float newHealth = _currentHealth - damageValue;
            if (newHealth <= 0)
            {
                _healthBar.SetValue(0, _maxHealth);

                Death();
            }
            else
            {
                _currentHealth = newHealth;
                _healthBar.SetValue(_currentHealth, _maxHealth);
            }
        }

        private void Death()
        {
            ParticleManager.Instance.PlayParticle(ParticleType.CarExplosion, transform.position);

            gameObject.SetActive(false);

            CarDeathEvent?.Invoke();
        }
    }
}