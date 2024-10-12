using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _damageValue = 50f;

    private ObjectPool _pool;

    private float _posY;

    private void Start()
    {
        _posY = transform.position.y;
    }

    public void SetPool(ObjectPool pool)
    {
        _pool = pool;
    }

    void Update()
    {
        // Move the bullet forward horizontally
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);

        // Lock Y position to prevent vertical movement
        Vector3 position = transform.position;
        position.y = _posY; // Set the Y position you want
        transform.position = position;

        // Check if the bullet is off-screen
        if (IsOffScreen())
        {
            _pool.ReturnObject(gameObject); // Return to pool if off-screen
        }
    }

    private bool IsOffScreen()
    {
        // Convert bullet's world position to viewport position
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        // Check if bullet is outside the screen (viewport coordinates are outside [0, 1])
        if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1)
        {
            return true; // Bullet is off-screen
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
                // Destroy(gameObject);
                _pool.ReturnObject(gameObject);
            }
        }
    }
}
