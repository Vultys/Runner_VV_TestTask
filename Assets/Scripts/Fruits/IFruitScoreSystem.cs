using System;
using System.Collections.Generic;

public interface IFruitScoreSystem
{
    event Action OnScoreChanged;
    
    int TotalScore { get; }

    void Collect(FruitsTypeConfig fruitType);

    int GetCollectedCount(FruitsType fruitTypeId);

    IReadOnlyDictionary<FruitsType, int> GetCollectedCounts();
}
