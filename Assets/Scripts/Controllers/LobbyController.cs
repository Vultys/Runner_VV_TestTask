using UnityEngine;
using Zenject;

public class LobbyController : MonoBehaviour
{
    [Inject] private IGameState _gameState;

    [Inject] private LobbyRankUI _rankUI;

    /// <summary>
    /// Invokes by the UI button
    /// </summary>
    public void StartGame()
    {
        Time.timeScale = 1f;
        _gameState.ChangeState(GameState.Gameplay);
    }

    public void ShowRankUI()
    {
        _rankUI.Show();
    }
}
