using System;

public enum GameState
{
    Loading,
    Lobby,
    Gameplay,
    Lose
}


public interface IGameState
{
    GameState CurrentState { get; }

    void ChangeState(GameState newState);

    event Action<GameState> OnStateChanged;
}
