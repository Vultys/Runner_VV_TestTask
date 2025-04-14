using UnityEngine;

public class Despawner : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private float _zDistance;

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        DespawnFruit(other);
        DespawnObstacle(other);        
    }

    /// <summary>
    /// Follows the player
    /// </summary>
    private void FollowPlayer()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _player.position.z - _zDistance);
    }

    /// <summary>
    /// Despawns the fruit
    /// </summary>
    /// <param name="other"> The collider that triggered the event </param>
    private void DespawnFruit(Collider other)
    {
        var fruit = other.GetComponent<Fruit>();
        if (fruit != null)
        {
            Destroy(fruit.gameObject);
        }
    }

    /// <summary>
    /// Despawns the obstacle
    /// </summary>
    /// <param name="other"> The collider that triggered the event </param>
    public void DespawnObstacle(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
    }
}
