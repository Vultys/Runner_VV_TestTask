using UnityEngine;

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
    
    /// <summary>
    /// Updates the player position based on the input
    /// </summary>
    /// <param name="deltaTime"> The time since the last update </param>
    /// <param name="input"> The input to use </param>
    public void Tick(float deltaTime, int input)
    {
        _currentLane = CalculateCurrentLane(input);

        float targetX = (_currentLane - 1) * _laneDistance;
        Vector3 targetPos = new Vector3(targetX, _player.position.y, _player.position.z + _moveSpeed * deltaTime);


        _player.position = Vector3.Lerp(_player.position, targetPos, deltaTime * _smoothness);
    }

    /// <summary>
    /// Calculates the current lane based on the input
    /// </summary>
    /// <param name="input"> The input to use </param>
    /// <returns> The current lane </returns>
    private int CalculateCurrentLane(int input) => input == 0 ? _currentLane : Mathf.Clamp(_currentLane + input, 0, 2);
}
