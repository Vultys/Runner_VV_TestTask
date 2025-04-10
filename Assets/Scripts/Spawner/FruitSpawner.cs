using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FruitSpawner : IFruitSpawner
{
    private readonly List<FruitsTypeConfig> _fruitConfigs;

    private readonly DiContainer _container;

    public FruitSpawner(List<FruitsTypeConfig> fruitConfigs, DiContainer container)
    {
        _fruitConfigs = fruitConfigs;
        _container = container;
    }

    public void Reset()
    {
        
    }

    public void TrySpawnFruits(Transform spawnPoint)
    {
        foreach (var fruitConfig in _fruitConfigs)
        {
            if(Random.value <= fruitConfig.spawnChance)
            {
                Vector3 spawnPos = new Vector3(spawnPoint.position.x, fruitConfig.prefab.transform.position.y, spawnPoint.position.z);
                _container.InstantiatePrefab(fruitConfig.prefab, spawnPos, fruitConfig.prefab.transform.rotation, null);
                break;
            }
        }
    }
}
