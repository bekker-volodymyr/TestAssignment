using UnityEngine;

namespace TestAssignment.Turret
{
    public class TurretRotate : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 0.1f;

        void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    float horizontalMovement = touch.deltaPosition.x;

                    transform.Rotate(0f, horizontalMovement * _rotationSpeed, 0f);
                }
            }
        }
    }
}