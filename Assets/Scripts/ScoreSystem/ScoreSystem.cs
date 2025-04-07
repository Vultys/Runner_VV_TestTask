using System.Collections.Generic;

public class ScoreSystem : IScoreSystem
{
    private Dictionary<string, int> _fruits = new();

    private int _totalScore = 0;

    public void AddFruit(string type, int points)
    {
        if(!_fruits.ContainsKey(type))
        {
            _fruits[type] = 0;
        }

        _fruits[type]++;
        _totalScore += points;
    }

    public int GetTotalScore() => _totalScore;

    public int GetFruitPoints(string type) => _fruits.TryGetValue(type, out int count) ? count : 0;

    public Dictionary<string, int> GetAllFruits() => new(_fruits);
}