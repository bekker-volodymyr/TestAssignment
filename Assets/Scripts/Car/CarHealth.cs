using UnityEngine;

public class CarHealth : MonoBehaviour
{
    private float _maxHealth = 100f;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void GetDamage(float damageValue)
    {
        float newHealth = _currentHealth - damageValue;
        if (newHealth <= 0)
        {
            Death();
        }
        else
        {
            _currentHealth = newHealth;
            Debug.Log($"Current car health: {_currentHealth}");
        }
    }

    private void Death()
    {
        Debug.Log("LOOSE");
        Destroy(gameObject);
    }
}
