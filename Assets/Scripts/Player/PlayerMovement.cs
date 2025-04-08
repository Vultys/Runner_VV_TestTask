using UnityEngine;
using Zenject;

public class PlayerMovement
{
    private readonly Transform _player;
    private readonly float _moveSpeed;
    private readonly float _laneDistance;
    private readonly float _smoothness;

    private int _currentLane = 1;

    public PlayerMovement(Transform player, float laneDistance, float moveSpeed, float smoothness)
    {
        _player = player;
        _laneDistance = laneDistance;
        _moveSpeed = moveSpeed;
        _smoothness = smoothness;
    }
    
    public void Tick(float deltaTime, int input)
    {
        if(input != 0)
        {
            _currentLane = Mathf.Clamp(_currentLane + input, 0, 2);
        }

        float targetX = (_currentLane - 1) * _laneDistance;
        Vector3 targetPos = new Vector3(targetX, _player.position.y, _player.position.z + _moveSpeed * deltaTime);

        _player.position = Vector3.Lerp(_player.position, targetPos, deltaTime * _smoothness);
    }

    public void ResetPosition()
    {
        _currentLane = 1;
        _player.position = new Vector3(0, _player.position.y, 0);
    }
}
