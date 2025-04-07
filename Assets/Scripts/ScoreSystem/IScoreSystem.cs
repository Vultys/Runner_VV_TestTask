using System.Collections.Generic;

public interface IScoreSystem
{
    void AddFruit(string type, int points);
    int GetTotalScore();
    int GetFruitPoints(string type);
    Dictionary<string, int> GetAllFruits();
}
