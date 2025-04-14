using System;
using UnityEngine.SceneManagement;

public class GameStateMachine : IGameStateMachine
{
    public GameState CurrentState { get; private set; }

    public event Action<GameState> OnStateChanged;

    /// <summary>
    /// Changes the state
    /// </summary>
    /// <param name="newState"> The new state </param>
    public void ChangeState(GameState newState)
    {
        if(CurrentState == newState) return;

        CurrentState = newState;
        OnStateChanged?.Invoke(newState);

        HandleStateTransition(newState);
    }

    /// <summary>
    /// Handles the state transition
    /// </summary>
    /// <param name="newState"> The new state </param>
    private void HandleStateTransition(GameState newState)
    {
        switch(newState)
        {
            case GameState.Lobby:
                SceneManager.LoadScene("Lobby");
                break;
            case GameState.Gameplay:
                SceneManager.LoadScene("Gameplay");
                break;
            case GameState.Lose:
                SceneManager.LoadScene("Lobby");
                break;
        }
    }
}
