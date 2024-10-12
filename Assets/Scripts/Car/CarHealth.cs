using UnityEngine;

public class CarHealth : MonoBehaviour
{
    private float _maxHealth = 100f;
    private float _currentHealth;

    [SerializeField] private HealthBar _healthBar;

    private void Start()
    {
        _currentHealth = _maxHealth;
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
        Destroy(gameObject);
    }
}
