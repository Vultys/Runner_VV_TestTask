using System.Collections;
using UnityEngine;
using Zenject;

public class LoadingController : MonoBehaviour
{
    [Inject] private IGameState _gameState;

    private void Start()
    {
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(2f);

        _gameState.ChangeState(GameState.Lobby);
    }
}
