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

                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);

                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Vector3 targetPosition = hit.point;
                        Vector3 direction = new Vector3(targetPosition.x, transform.position.y, targetPosition.z) - transform.position;
                        Quaternion targetRotation = Quaternion.LookRotation(direction);
                        transform.rotation = targetRotation;
                    }
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    float horizontalMovement = touch.deltaPosition.x;

                    transform.Rotate(0f, horizontalMovement * _rotationSpeed, 0f);
                }
            }
        }
    }
}