using System;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private int _levelLength = 3;
    private float _groundOffset;

    private int _segmentsPassed = 0;

    [SerializeField] GameObject[] _groundSegments;

    public event Action LastSegmentPassed;

    private void Start()
    {
        _groundOffset = _groundSegments[0].GetComponentInChildren<MeshRenderer>().bounds.size.z;

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

        if (_segmentsPassed == _levelLength)
        {
            _segmentsPassed = 0;
            LastSegmentPassed?.Invoke();
        }
    }

    private void MoveSegment()
    {
        GameObject firstSegment = _groundSegments[0];
        firstSegment.transform.position += Vector3.forward * _groundOffset * _groundSegments.Length;

        for (int i = 0; i < _groundSegments.Length - 1; i++)
        {
            _groundSegments[i] = _groundSegments[i + 1];
        }

        _groundSegments[_groundSegments.Length - 1] = firstSegment;
    }
}
