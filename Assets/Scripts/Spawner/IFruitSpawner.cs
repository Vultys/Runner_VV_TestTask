using UnityEngine;

public interface IFruitSpawner
{
    void TrySpawnFruits(Transform spawnPoint);

    void Reset();
}
