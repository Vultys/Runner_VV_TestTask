using System.Collections.Generic;

public interface ISaveSystem
{
    void SaveResult(List<GameResult> results);
    List<GameResult> LoadResult();
}
