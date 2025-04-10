using UnityEngine;
using Zenject;

public class FruitCollector : MonoBehaviour
{
    private IFruitScoreSystem _scoreSystem;

    [Inject]
    public void Construct(IFruitScoreSystem scoreSystem)
    {
        _scoreSystem = scoreSystem;
    }

    private void OnTriggerEnter(Collider other)
    {
        var fruit = other.GetComponent<Fruit>();
        if (fruit != null)
        {
            _scoreSystem.Collect(fruit.config);
            Destroy(fruit.gameObject);
        }
    }
}
