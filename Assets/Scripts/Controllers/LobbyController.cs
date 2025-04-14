using UnityEngine;
using Zenject;

public class LobbyController : MonoBehaviour
{
    [Inject] private IGameStateMachine _gameState;

    [Inject] private LobbyRankUI _rankUI;

    /// <summary>
    /// Invokes by the UI button to start the game
    /// </summary>
    public void StartGame()
    {
        Time.timeScale = 1f;
        _gameState.ChangeState(GameState.Gameplay);
    }

    /// <summary>
    /// Invokes by the UI button to show the rank UI
    /// </summary>
    public void ShowRankUI()
    {
        _rankUI.Show();
    }
}
