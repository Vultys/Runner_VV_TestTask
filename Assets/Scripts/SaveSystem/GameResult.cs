using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class GameResult
{
    public DateTime Date;

    public int TotalScore;

    public Dictionary<string, int> Fruits;

    public GameResult()
    {
        Fruits = new Dictionary<string, int>();
    }

    public GameResult(int totalScore, Dictionary<string, int> fruits)
    {
        Date = DateTime.Now;
        TotalScore = totalScore;
        Fruits = new Dictionary<string, int>(fruits);
    }

    public override string ToString()
    {
        string fruitsInfo = string.Join(", ", Fruits.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
        return $"Date: {Date}, Score: {TotalScore}, Fruits: {fruitsInfo}";
    }
}
