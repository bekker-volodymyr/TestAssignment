using System;
using UnityEngine;

namespace TestAssignment.Ground
{
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
}