using UnityEngine;
using Zenject;

public class FruitCollector : MonoBehaviour
{
    private IFruitScoreSystem _scoreSystem;

    private IGameState _gameState;

    [SerializeField] private LoseScreen _loseScreen;

    [Inject]
    public void Construct(IFruitScoreSystem scoreSystem, IGameState gameState)
    {
        _scoreSystem = scoreSystem;
        _gameState = gameState;
    }

    private void OnTriggerEnter(Collider other)
    {
        var fruit = other.GetComponent<Fruit>();
        if (fruit != null)
        {
            _scoreSystem.Collect(fruit.config);
            Destroy(fruit.gameObject);
        }

        if(other.gameObject.CompareTag("Obstacle"))
        {
            Time.timeScale = 0;
            _loseScreen.Show(() => _gameState.ChangeState(GameState.Lose));
        }
    }
}
