using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [Inject] private IPlayerInput _input;

    private PlayerMovement _movement;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _laneDistance = 2f;
    [SerializeField] private float _moveSmoothness = 10f;

    private void Start()
    {
        _movement = new PlayerMovement(transform, _laneDistance, _moveSpeed, _moveSmoothness);
    }

    private void Update()
    {
        int horizontal = _input.GetHorizontalInput();
        _movement.Tick(Time.deltaTime, horizontal);
    }

    public void ResetPosition() => _movement.ResetPosition();
}
