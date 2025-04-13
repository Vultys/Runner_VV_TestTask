using UnityEngine;
using Zenject;

public class FruitCollector : MonoBehaviour
{   
    private GameplayController _gameplayController;

    [Inject]
    public void Construct(GameplayController gameplayController)
    {
        _gameplayController = gameplayController;
    }

    private void OnTriggerEnter(Collider other)
    {
        var fruit = other.GetComponent<Fruit>();
        if (fruit != null)
        {
            _gameplayController.CollectAndDestroy(fruit);
        }

        if(other.gameObject.CompareTag("Obstacle"))
        {
            _gameplayController.Lose();
        }
    }
}
