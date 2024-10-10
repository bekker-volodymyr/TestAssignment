using UnityEngine;

public class TurretRotate : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 0.1f; // Speed of rotation based on swipe

    void Update()
    {
        // Check if there's at least one touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch is moving
            if (touch.phase == TouchPhase.Moved)
            {
                // Get the horizontal movement of the touch (delta position)
                float horizontalMovement = touch.deltaPosition.x;

                // Rotate the object around the Y-axis based on the swipe
                transform.Rotate(0f, horizontalMovement * _rotationSpeed, 0f);
            }
        }
    }
}
