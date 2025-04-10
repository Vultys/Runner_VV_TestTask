using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateMachine : IGameState
{
    public GameState CurrentState { get; private set; }

    public event Action<GameState> OnStateChanged;

    public void ChangeState(GameState newState)
    {
        if(CurrentState == newState) return;

        CurrentState = newState;
        OnStateChanged?.Invoke(newState);

        HandleStateTransition(newState);
    }

    private void HandleStateTransition(GameState newState)
    {
        switch(newState)
        {
            case GameState.Lobby:
                SceneManager.LoadScene("Lobby");
                break;
            case GameState.Gameplay:
                Time.timeScale = 1f;
                SceneManager.LoadScene("Gameplay");
                break;
            case GameState.Lose:
                SceneManager.LoadScene("Lobby");
                break;
        }
    }
}
