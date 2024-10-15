using UnityEngine;

namespace TestAssignment.Enemies
{
    public class NoticeTriggerCheck : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _enemy.OnNoticeEnter();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _enemy.OnNoticeExit();
            }
        }
    }
}