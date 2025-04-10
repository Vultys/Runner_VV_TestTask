using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FruitsTypeConfig", menuName = "FruitsTypeConfig")]
public class FruitsTypeConfig : ScriptableObject
{
    public string id;
    public GameObject prefab;
    public int points = 1;
    [Range(0f, 1f)] public float spawnChance = 0.5f;
}
