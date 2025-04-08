using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FruitSpawner : IFruitSpawner
{
    private readonly List<SpawnableItemConfig> _fruitConfigs;

    private readonly DiContainer _container;

    public FruitSpawner(List<SpawnableItemConfig> fruitConfigs, DiContainer container)
    {
        _fruitConfigs = fruitConfigs;
        _container = container;
    }

    public void Reset()
    {
        throw new System.NotImplementedException();
    }

    public void TrySpawnFruits(Transform spawnPoint)
    {
        foreach (var fruitConfig in _fruitConfigs)
        {
            if(Random.value <= fruitConfig.spawnChance)
            {
                _container.InstantiatePrefab(fruitConfig.prefab, spawnPoint.position, Quaternion.identity, null);
                break;
            }
        }
    }
}
