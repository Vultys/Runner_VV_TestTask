using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstacleSpawner : IObstacleSpawner
{
    private readonly List<SpawnableItemConfig> _obstacleConfigs;

    private readonly DiContainer _container;

    public ObstacleSpawner(List<SpawnableItemConfig> obstacleConfigs, DiContainer container)
    {
        _obstacleConfigs = obstacleConfigs;
        _container = container;
    }

    /// <summary>
    /// Spawns an obstacle at the given spawn point
    /// </summary>
    /// <param name="spawnPoint"> The spawn point to spawn at </param>
    public void TrySpawn(Transform spawnPoint)
    {
        if(_obstacleConfigs.Count == 0)
        {
            return;
        }

        foreach (var obstacleConfig in _obstacleConfigs)
        {
            if(Random.value <= obstacleConfig.spawnChance)
            {
                _container.InstantiatePrefab(obstacleConfig.prefab, spawnPoint.position, Quaternion.identity, null);
                break;
            }
        }
    }
}
