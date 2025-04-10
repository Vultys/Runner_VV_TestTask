using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlatformSpawner : IPlatformSpawner
{
    [Inject] private IFruitSpawner _fruitSpawner;

    [Inject] private IObstacleSpawner _obstacleSpawner;

    private readonly DiContainer _container;

    private readonly Transform _parent;
    
    private readonly GameObject _platformPrefab;

    private readonly int _initialCount = 5;

    private readonly float _platformLength = 20f;

    private readonly int _fruitsToSpawn = 3;

    private readonly int _obstaclesToSpawn = 2;

    private Queue<GameObject> _activePlatforms = new();

    private float _spawnZ = 0f;

    public PlatformSpawner(DiContainer container, PlatformSpawnerSettings settings)
    {
        _container = container;
        _parent = settings.PlatformParent;
        _platformPrefab = settings.PlatformPrefab;
    }

    public void SpawnInitial()
    {
        _spawnZ = 0f;
        for(int i = 0; i < _initialCount; i++)
        {
            SpawnNext();
        }
    }

    public void SpawnNext()
    {
        var platform = _container.InstantiatePrefab(_platformPrefab, _parent);
        platform.transform.position = new Vector3(0, 0, _spawnZ);
        _spawnZ += _platformLength;
        _activePlatforms.Enqueue(platform);

        var platformSegment = platform.GetComponent<PlatformSegment>();
        List<int> usedSpawnPoints = new();

        for(int i = 0; i < _fruitsToSpawn; i++)
        {
            int spawnPointIndex = Random.Range(0, platformSegment.SpawnPoints.Count);
            while(usedSpawnPoints.Contains(spawnPointIndex))
            {
                spawnPointIndex = Random.Range(0, platformSegment.SpawnPoints.Count);
            }
            usedSpawnPoints.Add(spawnPointIndex);
            _fruitSpawner.TrySpawnFruits(platformSegment.SpawnPoints[spawnPointIndex]);
        }

        for(int i = 0; i < _obstaclesToSpawn; i++)
        {  
            int spawnPointIndex = Random.Range(0, platformSegment.SpawnPoints.Count);
            while(usedSpawnPoints.Contains(spawnPointIndex))
            {
                spawnPointIndex = Random.Range(0, platformSegment.SpawnPoints.Count);
            }
            usedSpawnPoints.Add(spawnPointIndex);
            _obstacleSpawner.TrySpawnObstacle(platformSegment.SpawnPoints[spawnPointIndex]);
        }

        if(_activePlatforms.Count > 10)
        {
            var old = _activePlatforms.Dequeue();
            GameObject.Destroy(old);
        }
    }

    public void Reset()
    {
        foreach(var platform in _activePlatforms)
        {
            GameObject.Destroy(platform);
        }

        _activePlatforms.Clear();
        _spawnZ = 0f;
    }
}
