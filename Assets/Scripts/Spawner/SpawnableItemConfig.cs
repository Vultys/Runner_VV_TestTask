using System;
using UnityEngine;

[Serializable]
public class SpawnableItemConfig
{
    public GameObject prefab;
    [Range(0f, 1f)] public float spawnChance = 0.5f;
}
