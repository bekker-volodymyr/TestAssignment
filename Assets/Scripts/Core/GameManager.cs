using TestAssignment.Car;
using TestAssignment.Enemies;
using TestAssignment.Ground;
using TestAssignment.Turret;
using TestAssignment.UI;
using UnityEngine;

namespace TestAssignment.Utils
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private GameObject _player;
        public GameObject Player => _player;

        [SerializeField] private CarHealth _carHelath;

        [SerializeField] private MainUI _mainUI;

        [SerializeField] private GroundManager _groundSpawner;

        [SerializeField] private EnemySpawner _enemySpawner;

        [SerializeField] private TurretShooter _turretShooter;

        private GameState _state;
        public GameState State => _state;

        private void Awake()
        {
            Instance = this;

            _mainUI.TapEvent += OnTap;
            _mainUI.gameObject.SetActive(false);

            _carHelath.CarDeathEvent += OnLoose;

            _groundSpawner.LastSegmentPassed += OnWin;
        }

        private void Start()
        {
            SetStartingState();
        }

        private void PauseGame()
        {
            Time.timeScale = 0f;
        }

        private void UnpauseGame()
        {
            Time.timeScale = 1f;
        }

        private void OnTap()
        {
            switch (_state)
            {
                case GameState.Starting:
                    SetRunningState(); break;
                case GameState.Finished:
                    SetStartingState(); break;
                default: Debug.Log($"Unkonw state or not implemented: {_state}"); break;
            }
        }

        private void OnLoose()
        {
            SetFinishedState(false);
            _groundSpawner.Reset();
        }

        private void OnWin()
        {
            SetFinishedState(true);
        }

        private void SetStartingState()
        {
            PauseGame();

            _state = GameState.Starting;

            _enemySpawner.Reset();
            _turretShooter.Reset();
            _carHelath.Reset();

            _mainUI.gameObject.SetActive(true);
            _mainUI.SetStartingState();
        }

        private void SetRunningState()
        {
            UnpauseGame();
            _mainUI.gameObject.SetActive(false);
        }

        private void SetFinishedState(bool isWin)
        {
            PauseGame();
            _state = GameState.Finished;
            _mainUI.gameObject.SetActive(true);
            _mainUI.SetFinishedState(isWin);
        }
    }

    public enum GameState
    {
        Starting,  // Game at the start
        Running,   // Game is currently running
        Finished   // Player won/lost the game
    }
}