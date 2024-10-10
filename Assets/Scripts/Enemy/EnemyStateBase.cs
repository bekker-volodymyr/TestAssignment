public class EnemyStateBase
{
    protected Enemy _enemy;
    protected EnemyStateMachine _stateMachine;

    public EnemyStateBase(Enemy enemy, EnemyStateMachine stateMachine)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { ResetState(); }
    public virtual void Update() { }
    public virtual void ResetState() { }
}
