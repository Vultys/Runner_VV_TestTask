using System;
using System.Collections.Generic;

[Serializable]
public class GameResult
{
    public string Date;

    public int TotalScore;

    public GameResult(int totalScore, Dictionary<string, int> fruits)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        TotalScore = totalScore;
    }
}
