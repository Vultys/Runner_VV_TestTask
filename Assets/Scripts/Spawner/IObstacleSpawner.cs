using UnityEngine;

public interface IObstacleSpawner
{
    void TrySpawnObstacle(Vector3 position);

    void Reset();
}
