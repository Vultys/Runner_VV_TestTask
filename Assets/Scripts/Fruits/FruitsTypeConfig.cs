using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FruitsTypeConfig", menuName = "FruitsTypeConfig")]
public class FruitsTypeConfig : ScriptableObject
{
    public FruitsType type;
    public GameObject prefab;
    public int points = 1;
    [Range(0f, 1f)] public float spawnChance = 0.5f;
}

public enum FruitsType
{
    Carrot,
    BluePie,
    Kiwi,
    Banana
}
