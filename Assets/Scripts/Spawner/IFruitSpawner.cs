using UnityEngine;

public interface IFruitSpawner
{
    void TrySpawnFruits(Vector3 platformCenter);

    void Reset();
}
