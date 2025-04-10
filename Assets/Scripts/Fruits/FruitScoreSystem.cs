using System.Collections.Generic;
using UnityEngine;

public class FruitScoreSystem : IFruitScoreSystem
{
    private Dictionary<string, int> _fruitCounts = new();

    public int TotalScore => _totalScore;

    private int _totalScore = 0;

    public void Collect(FruitsTypeConfig fruitType)
    {
        if(!_fruitCounts.ContainsKey(fruitType.id))
        {
            _fruitCounts[fruitType.id] = 0;
        }

        _fruitCounts[fruitType.id]++;
        _totalScore += fruitType.points;
    }

    public int GetCollectedCount(string fruitTypeId) => _fruitCounts.TryGetValue(fruitTypeId, out var count) ? count : 0;

    public IReadOnlyDictionary<string, int> GetCollectedCounts() => _fruitCounts;
}
