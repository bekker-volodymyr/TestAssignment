
namespace TestAssignment.Enemies
{
    public class EnemyStateMachine
    {
        public EnemyStateBase CurrentState { get; private set; }

        public void Init(EnemyStateBase startState)
        {
            CurrentState = startState;
            CurrentState.EnterState();
        }

        public void ChangeState(EnemyStateBase newState)
        {
            CurrentState.ExitState();
            CurrentState = newState;
            CurrentState.EnterState();
        }
    }
}