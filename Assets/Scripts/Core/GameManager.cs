using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _player;
    public GameObject Player => _player;

    private void Awake()
    {
        Instance = this;
    }
}
