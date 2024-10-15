using UnityEngine;
using UnityEngine.AI;

namespace TestAssignment.Enemies
{
    public class EnemyIdle : EnemyStateBase
    {
        // Range for random wander destination
        private float _rangeMax = 10f;
        private float _rangeMin = 3f;

        private float _timeSinceLastMove;
        private float _moveInterval = 2f;

        public EnemyIdle(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine) { }

        public override void EnterState()
        {
            base.EnterState();

            _enemy.ChangeDestination(GetRandomPoint(_enemy.transform.position, _rangeMax));
            _enemy.ChangeAnimationState(0);
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void ResetState()
        {
            base.ResetState();
        }

        public override void Update()
        {
            base.Update();

            _timeSinceLastMove += Time.deltaTime;

            if (_timeSinceLastMove >= _moveInterval)
            {
                Vector3 randomPosition = GetRandomPoint(_enemy.transform.position, _rangeMax);
                _enemy.ChangeDestination(randomPosition);
                _timeSinceLastMove = 0f;
            }
        }

        Vector3 GetRandomPoint(Vector3 center, float radius)
        {
            Vector3 randomDirection;
            do
            {
                randomDirection = Random.insideUnitSphere * radius;
                randomDirection += center;

                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
                {
                    if (Vector3.Distance(_enemy.transform.position, hit.position) > _rangeMin)
                    {
                        return hit.position;
                    }
                }
            } while (true);
        }
    }
}
