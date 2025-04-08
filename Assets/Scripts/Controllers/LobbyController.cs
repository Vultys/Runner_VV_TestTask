using UnityEngine;
using Zenject;

public class LobbyController : MonoBehaviour
{
    [Inject] private IGameState _gameState;

    /// <summary>
    /// Invokes by the UI button
    /// </summary>
    public void StartGame()
    {
        _gameState.ChangeState(GameState.Gameplay);
    }
}
