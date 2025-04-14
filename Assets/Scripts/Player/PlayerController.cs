using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [Inject] private IPlayerInput _input;
    [Inject] private IPlatformSpawner _platformSpawner;

    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 50f;
    [SerializeField] private float _laneDistance = 2f;
    [SerializeField] private float _moveSmoothness = 20f;
    
    [Header("Spawning Settings")]
    [SerializeField] private float _platformSpawnTriggerDistance = 40f;

    private PlayerMovement _movement;
    private int _currentInput = 0;

    private float _lastSpawnZ = 0;

    private void Start()
    {
        _movement = new PlayerMovement(transform, _laneDistance, _moveSpeed, _moveSmoothness);
    }

    private void Update()
    {
        _currentInput = _input.GetHorizontalInput();
        _movement.Tick(Time.deltaTime, _currentInput);
    }
    
    private void LateUpdate()
    {
        if(transform.position.z + _platformSpawnTriggerDistance > _lastSpawnZ)
        {
            _platformSpawner.SpawnNext();
            _lastSpawnZ += _platformSpawner.PlatformLength;
        }
    }
}
