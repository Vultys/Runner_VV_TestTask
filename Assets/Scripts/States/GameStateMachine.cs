
using System;

public class GameStateMachine : IGameState
{
    public GameState CurrentState { get; private set; }

    public event Action<GameState> OnStateChanged;

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        OnStateChanged?.Invoke(newState);
    }
}
