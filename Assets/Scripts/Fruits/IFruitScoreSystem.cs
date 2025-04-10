using System.Collections.Generic;

public interface IFruitScoreSystem
{
    int TotalScore { get; }

    void Collect(FruitsTypeConfig fruitType);

    int GetCollectedCount(string fruitTypeId);

    IReadOnlyDictionary<string, int> GetCollectedCounts();
}
