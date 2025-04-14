using System;

[Serializable]
public class GameResult
{
    public string Date;

    public int TotalScore;

    public GameResult(int totalScore)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        TotalScore = totalScore;
    }
}
