using UnityEngine;

public class EnemyAttack : EnemyStateBase
{
    private float _attackDistance = 2.5f;

    public EnemyAttack(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        _enemy.ChangeAnimationState(2);
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

        if (Vector3.Distance(_enemy.transform.position, GameManager.Instance.Player.transform.position) > _attackDistance)
        {

        }
    }
}
