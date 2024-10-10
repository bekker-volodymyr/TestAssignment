using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private float _maxHealth = 100f;
    private float _currentHelath;

    private EnemyStateMachine _stateMachine;

    private EnemyIdle _idleState;
    private EnemyRun _runState;

    [SerializeField] private float _damageValue = 20f;

    [SerializeField] private NavMeshAgent _agent;
    public NavMeshAgent Agent => _agent;
    [SerializeField] private Animator _animator;

    [SerializeField] private HealthBar _healthBar;

    private void Awake()
    {
        _stateMachine = new EnemyStateMachine();

        _idleState = new EnemyIdle(this, _stateMachine);
        _runState = new EnemyRun(this, _stateMachine);
    }

    void Start()
    {
        _stateMachine.Init(_idleState);

        _currentHelath = _maxHealth;
    }

    void Update()
    {
        _stateMachine.CurrentState.Update();
    }

    public void ChangeDestination(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }

    public void ChangeAnimationState(int state)
    {
        _animator.SetInteger("State", state);
    }

    public void OnNoticeEnter()
    {
        _stateMachine.ChangeState(_runState);
    }

    public void OnNoticeExit()
    {
        _stateMachine.ChangeState(_idleState);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);

        if (other.CompareTag("Player"))
        {
            CarHealth car = other.GetComponentInParent<CarHealth>();
            car.GetDamage(_damageValue);
            Death();
        }
    }

    public void GetDamage(float damageValue)
    {
        float newHealth = _currentHelath - damageValue;

        if (newHealth <= 0)
        {
            _healthBar.SetValue(0f, _maxHealth);
            Death();
        }
        else
        {
            Debug.Log($"New health {newHealth}");

            _currentHelath = newHealth;
            _healthBar.SetValue(_currentHelath, _maxHealth);
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
