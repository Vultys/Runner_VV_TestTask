using UnityEngine;
using Zenject;

public class GameplayController : MonoBehaviour
{
    private IGameState _gameState;

    private LoseScreen _loseScreen;

    private IFruitScoreSystem _scoreSystem;

    private ISaveSystem _saveSystem;

    [Inject]
    public void Construct(IGameState gameState, LoseScreen loseScreen, IFruitScoreSystem scoreSystem, ISaveSystem saveSystem)
    {
        _gameState = gameState;
        _loseScreen = loseScreen;
        _scoreSystem = scoreSystem;
        _saveSystem = saveSystem;
    }

    public void Lose()
    {
        Time.timeScale = 0f;
        _loseScreen.Show(OnLoseScreenClose);
    }

    public void CollectAndDestroy(Fruit fruit)
    {
        _scoreSystem.Collect(fruit.config);
        Destroy(fruit.gameObject);
    }

    private void OnLoseScreenClose()
    {
        _saveSystem.SaveResult(new GameResult(_scoreSystem.TotalScore, new(_scoreSystem.GetCollectedCounts())));
        _gameState.ChangeState(GameState.Lobby);
    }
}
