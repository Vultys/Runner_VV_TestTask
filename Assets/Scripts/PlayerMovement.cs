using UnityEngine;
using Zenject;

public class PlayerMovement : ITickable
{
    private readonly Transform _player;
    private readonly IPlayerInput _input;
    private float _speed = 10f;

    public PlayerMovement(Transform player, IPlayerInput input)
    {
        _player = player;
        _input = input;
    }
    
    public void Tick()
    {
        Vector3 move = new Vector3(_input.Direction.x, 0 , 1) * _speed * Time.deltaTime;
        _player.Translate(move);
    }
}
