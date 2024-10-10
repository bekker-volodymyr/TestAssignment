using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _groundBaseObject;
    private int _spawnCount = 3;
    private float _groundOffset = -105f;

    List<GameObject> _groundSegments = new List<GameObject>(3);

    private void Start()
    {
        _groundSegments.Append(_groundBaseObject);

        for (int i = 0; i < _spawnCount - 1; i++)
        {
            GameObject groundSegment = Instantiate(_groundBaseObject);
            groundSegment.transform.SetParent(transform, false);
            groundSegment.transform.position = new Vector3(0, 0, _groundOffset);
            _groundSegments.Append(groundSegment);
        }
    }

}
