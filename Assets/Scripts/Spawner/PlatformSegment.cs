using System.Collections.Generic;
using UnityEngine;

public class PlatformSegment : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;

    public List<Transform> SpawnPoints => _spawnPoints;

    public Transform GetRandomSpawnPoint()
    {
        if(_spawnPoints == null || _spawnPoints.Count == 0)
        {
            return transform;
        }

        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }
}
