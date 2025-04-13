using System.Collections.Generic;

public interface ISaveSystem
{
    void SaveResult(GameResult results);
    List<GameResult> LoadResults();
}
