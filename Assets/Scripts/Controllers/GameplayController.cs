using UnityEngine;
using Zenject;

public class GameplayController : MonoBehaviour
{
    private IGameStateMachine _gameStateMachine;
    private LoseScreen _loseScreen;
    private IFruitScoreSystem _scoreSystem;
    private ISaveSystem _saveSystem;

    [Inject]
    public void Construct(IGameStateMachine gameStateMachine, LoseScreen loseScreen, IFruitScoreSystem scoreSystem, ISaveSystem saveSystem)
    {
        _gameStateMachine = gameStateMachine;
        _loseScreen = loseScreen;
        _scoreSystem = scoreSystem;
        _saveSystem = saveSystem;
    }

    /// <summary>
    /// Changes the GameStateMachine to the Loading state
    /// </summary>
    public void Lose()
    {
        Time.timeScale = 0f;
        _loseScreen.Show(OnLoseScreenClosed);
    }

    /// <summary>
    /// Collects the fruit
    /// </summary>
    /// <param name="fruit"> The fruit to collect </param>
    public void CollectFruit(Fruit fruit)
    {
        _scoreSystem.Collect(fruit.config);
    }

    /// <summary>
    /// Changes the GameStateMachine to the Lobby state
    /// </summary>
    private void OnLoseScreenClosed()
    {
        _saveSystem.SaveResult(new GameResult(_scoreSystem.TotalScore));
        _gameStateMachine.ChangeState(GameState.Lobby);
    }
}
