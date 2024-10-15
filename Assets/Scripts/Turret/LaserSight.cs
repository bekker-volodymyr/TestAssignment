using UnityEngine;

public class LaserSight : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private float _laserDistance = 50f;
    private float _laserWidth = 0.1f;
    [SerializeField] private LayerMask _hitLayers;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        _lineRenderer.startWidth = _laserWidth;
        _lineRenderer.endWidth = _laserWidth;
    }

    private void Update()
    {
        ShootLaser();
    }

    private void ShootLaser()
    {
        _lineRenderer.SetPosition(0, transform.position);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _laserDistance, _hitLayers))
        {
            _lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            _lineRenderer.SetPosition(1, transform.position + transform.forward * _laserDistance);
        }
    }
}
