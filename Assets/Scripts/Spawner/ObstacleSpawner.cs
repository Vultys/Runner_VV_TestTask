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

    public void Reset()
    {
        throw new System.NotImplementedException();
    }

    public void TrySpawnObstacle(Transform spawnPoint)
    {
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
