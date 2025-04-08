using UnityEngine;

public interface IObstacleSpawner
{
    void TrySpawnObstacle(Transform spawnPoint);

    void Reset();
}
