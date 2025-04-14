using System;
using System.Collections.Generic;

public class FruitScoreSystem : IFruitScoreSystem
{
    private Dictionary<FruitsType, int> _fruitCounts = new();

    private int _totalScore = 0;

    public int TotalScore => _totalScore;

    public event Action OnScoreChanged;
    
    /// <summary>
    /// Adds the fruit to the score and increases the total score
    /// </summary>
    /// <param name="fruitType"> The fruit type to collect </param>
    public void Collect(FruitsTypeConfig fruitType)
    {
        if(!_fruitCounts.ContainsKey(fruitType.type))
        {
            _fruitCounts[fruitType.type] = 0;
        }

        _fruitCounts[fruitType.type]++;
        _totalScore += fruitType.points;
        OnScoreChanged?.Invoke();
    }

    /// <summary>
    /// Returns the number of fruits of the given type
    /// </summary>
    /// <param name="fruitType"> The fruit type to get the count of </param>
    /// <returns> The number of fruits of the given type </returns>
    public int GetCollectedCount(FruitsType fruitType) => _fruitCounts.TryGetValue(fruitType, out var count) ? count : 0;

    /// <summary>
    /// Returns a dictionary of all the fruits and their counts
    /// </summary>
    /// <returns></returns>
    public IReadOnlyDictionary<FruitsType, int> GetCollectedCounts() => _fruitCounts;
}
