using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FruitSpawner : ISpawner
{
    private readonly List<FruitsTypeConfig> _fruitConfigs;

    private readonly DiContainer _container;

    public FruitSpawner(List<FruitsTypeConfig> fruitConfigs, DiContainer container)
    {
        _fruitConfigs = fruitConfigs;
        _container = container;
    }

    /// <summary>
    /// Spawns a fruit at the given spawn point
    /// </summary>
    /// <param name="spawnPoint"> The spawn point to spawn at </param>
    public void TrySpawn(Transform spawnPoint)
    {
        if(_fruitConfigs.Count == 0)
        {
            return;
        }

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
