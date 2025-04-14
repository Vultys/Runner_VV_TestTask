using System.Collections;
using UnityEngine;
using Zenject;

public class LoadingController : MonoBehaviour
{
    [Inject] private IGameStateMachine _gameState;

    [SerializeField] private float _delay = 2f;

    private void Start()
    {
        StartCoroutine(LoadGame(_delay));
    }

    /// <summary>
    /// Changes the GameStateMachine to the Lobby state after delay
    /// </summary>
    private IEnumerator LoadGame(float delay)
    {
        yield return new WaitForSeconds(delay);

        _gameState.ChangeState(GameState.Lobby);
    }
}
