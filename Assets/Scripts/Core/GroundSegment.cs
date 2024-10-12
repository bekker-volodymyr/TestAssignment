using System;
using Unity.AI.Navigation;
using UnityEngine;

public class GroundSegment : MonoBehaviour
{
    public event Action FinishedSegmentEvent;

    [SerializeField] private NavMeshSurface _meshSurface;
    public NavMeshSurface MeshSurface => _meshSurface;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FinishedSegmentEvent?.Invoke();
        }
    }
}
