using System.Collections.Generic;
using UnityEngine;

public class PlatformSegment : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;

    public List<Transform> SpawnPoints => _spawnPoints;
}
