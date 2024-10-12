using System;
using UnityEngine;

public class GroundSegment : MonoBehaviour
{
    public event Action FinishedSegmentEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FinishedSegmentEvent?.Invoke();
        }
    }
}
