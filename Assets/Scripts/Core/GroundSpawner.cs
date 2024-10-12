using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private int _levelLength = 3;
    private float _groundOffset = -105f;

    private int _segmentsPassed = 0;

    [SerializeField] GameObject[] _groundSegments;

    [SerializeField] EnemySpawner _enemySpawner;

    private void Start()
    {
        foreach (var segment in _groundSegments)
        {
            segment.GetComponent<GroundSegment>().FinishedSegmentEvent += OnSegmentPassed;
        }
    }

    private void OnDestroy()
    {
        foreach (var segment in _groundSegments)
        {
            segment.GetComponent<GroundSegment>().FinishedSegmentEvent -= OnSegmentPassed;
        }
    }

    private void OnSegmentPassed()
    {
        _segmentsPassed++;
        MoveSegment();
    }

    private void MoveSegment()
    {
        GameObject firstSegment = _groundSegments[0];
        firstSegment.transform.position += Vector3.forward * _groundOffset * _groundSegments.Length;

        // Reorganize the array, central becomes first, first becomes last
        for (int i = 0; i < _groundSegments.Length - 1; i++)
        {
            _groundSegments[i] = _groundSegments[i + 1];
        }

        _groundSegments[_groundSegments.Length - 1] = firstSegment;
    }
}
