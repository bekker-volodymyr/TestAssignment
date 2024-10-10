using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _damageValue = 50f;

    private float _posY;

    private void Start()
    {
        _posY = transform.position.y;
    }

    void Update()
    {
        // Move the bullet forward horizontally
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);

        // Lock Y position to prevent vertical movement
        Vector3 position = transform.position;
        position.y = _posY; // Set the Y position you want
        transform.position = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.GetDamage(_damageValue);
                Destroy(gameObject);
            }
        }
    }
}
