using UnityEngine;

public class PlayerInput : IPlayerInput
{
    public Vector2 Direction => new Vector2(Input.GetAxis("Horizontal"), 0);
}
