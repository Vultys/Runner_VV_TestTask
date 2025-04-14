using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlatformSpawner : IPlatformSpawner
{
    private readonly DiContainer _container;
    private readonly Transform _parent;
    private readonly GameObject _platformPrefab;

    private Queue<GameObject> _activePlatforms = new();

    private float _spawnZ = 0f;

    
    private readonly float _platformLength = 20f;
    private readonly int _maxPlatforms = 6;

    private readonly int _fruitsToSpawn = 3;
    private readonly int _obstaclesToSpawn = 1;

    private ISpawner _fruitSpawner;

    private IObstacleSpawner _obstacleSpawner;

    public float PlatformLength => _platformLength;

    [Inject]
    public PlatformSpawner(DiContainer container, PlatformSpawnerSettings settings, ISpawner fruitSpawner, IObstacleSpawner obstacleSpawner)
    {
        _container = container;
        _parent = settings.PlatformParent;
        _platformPrefab = settings.PlatformPrefab;

        _fruitSpawner = fruitSpawner;
        _obstacleSpawner = obstacleSpawner;
    }

    /// <summary>
    /// Spawns the next platform
    /// </summary>
    public void SpawnNext()
    {
        var platform = _container.InstantiatePrefab(_platformPrefab, _parent);
        platform.transform.position = new Vector3(0, 0, _spawnZ);
        _spawnZ += _platformLength;

        _activePlatforms.Enqueue(platform);

        var platformSegment = platform.GetComponent<PlatformSegment>();
        var usedSpawnPoints = new HashSet<int>();

        SpawnEntities(_fruitSpawner, platformSegment, _fruitsToSpawn, usedSpawnPoints);
        SpawnEntities(_obstacleSpawner, platformSegment, _obstaclesToSpawn, usedSpawnPoints);

        if(_activePlatforms.Count > _maxPlatforms)
        {
            var old = _activePlatforms.Dequeue();
            GameObject.Destroy(old);
        }
    }

    /// <summary>
    /// Spawns the given number of entities on the given platform
    /// </summary>
    /// <param name="spawner"> The spawner to use </param>
    /// <param name="platformSegment"> The platform segment to spawn on </param>
    /// <param name="count"> The number of entities to spawn </param>
    /// <param name="usedSpawnPoints"> The spawn points that have already been used </param>
    private void SpawnEntities(ISpawner spawner, PlatformSegment platformSegment, int count, HashSet<int> usedSpawnPoints)
    {
        int pointCount = platformSegment.SpawnPoints.Count;
        for(int i = 0; i <= count; i++)
        {  
            int index;
            do
            {
                index = Random.Range(0, pointCount);
            }
            while(!usedSpawnPoints.Add(index));
            
            spawner.TrySpawn(platformSegment.SpawnPoints[index]);
        }
    }
}
