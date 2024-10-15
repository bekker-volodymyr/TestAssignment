using TestAssignment.Utils;
using UnityEngine;

namespace TestAssignment.Enemies
{
    public class EnemyRunState : EnemyStateBase
    {
        private GameObject _player;

        public EnemyRunState(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
        {
        }

        public override void EnterState()
        {
            base.EnterState();

            _enemy.ChangeAnimationState(1);
            _player = GameManager.Instance.Player;
            _enemy.ChangeDestination(_player.transform.position);
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

            _enemy.ChangeDestination(_player.transform.position);
        }
    }
}
