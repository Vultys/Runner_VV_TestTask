using UnityEngine;
using Zenject;

public class FruitCollector : MonoBehaviour
{   
    private static string _obstacleTag = "Obstacle";
    
    private GameplayController _gameplayController;

    [Inject]
    public void Construct(GameplayController gameplayController)
    {
        _gameplayController = gameplayController;
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleFruitColliding(other);
        HandleObstacleColliding(other);
    }

    /// <summary>
    /// Handles the fruit colliding with the player
    /// </summary>
    /// <param name="other"> The collider that triggered the event </param>
    private void HandleFruitColliding(Collider other)
    {
        var fruit = other.GetComponent<Fruit>();
        if (fruit != null)
        {
            _gameplayController.CollectFruit(fruit);
            Destroy(fruit.gameObject);
        }
    }

    /// <summary>
    /// Handles the obstacle colliding with the player
    /// </summary>
    /// <param name="other"> The collider that triggered the event </param>
    private void HandleObstacleColliding(Collider other)
    {
        if(other.gameObject.CompareTag(_obstacleTag))
        {
            _gameplayController.Lose();
        }
    }
}
