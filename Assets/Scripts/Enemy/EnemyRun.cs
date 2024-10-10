using UnityEngine;

public class EnemyRun : EnemyStateBase
{
    private GameObject _player;

    public EnemyRun(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        _enemy.ChangeAnimationState(1);
        _player = GameManager.Instance.Player;
        _enemy.ChangeDestination(_player.transform.position);

        Debug.Log("Enter Run State");
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
